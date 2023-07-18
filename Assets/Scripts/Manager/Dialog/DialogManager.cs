using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Ink.Runtime;

public class DialogManager : MonoBehaviour
{
    public TextAsset inkFile;
    public GameObject textBox;
    public GameObject customButton;
    public GameObject optionPanel;
    public bool isTalking = false;

    private static Story story;
    private Text nametag;
    private Text message;
    private List<string> tags;
    private static Choice choiceSelected;
    private string currentSentence;

    // Start is called before the first frame update
    void Start()
    {
        story = new Story(inkFile.text);
        nametag = textBox.transform.GetChild(0).GetComponent<Text>();
        message = textBox.transform.GetChild(1).GetComponent<Text>();
        tags = new List<string>();
        choiceSelected = null;
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            if(isTalking)
            {
                if(message.text != currentSentence)
                {
                    StopAllCoroutines();
                    message.text = currentSentence;
                }
            }
            //Is there more to the story?
            if(story.canContinue)
            {
                AdvanceDialogue();

                //Are there any choices?
                if (story.currentChoices.Count != 0)
                {
                    StartCoroutine(ShowChoices());
                }
            }
            else
            {
                FinishDialogue();
            }
        }
    }

    // Finished the Story (Dialogue)
    private void FinishDialogue()
    {
        Debug.Log("End of Dialogue!");
    }

    // Advance through the story 
    void AdvanceDialogue()
    {
        currentSentence = story.Continue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(currentSentence));
    }

    // Type out the sentence letter by letter and make character idle if they were talking
    IEnumerator TypeSentence(string sentence)
    {
        isTalking = true;
        message.text = "";
        foreach(char letter in sentence.ToCharArray())
        {
            message.text += letter;
            yield return null;
        }

        isTalking = false;

        yield return null;
    }

    // Create then show the choices on the screen until one got selected
    IEnumerator ShowChoices()
    {
        List<Choice> _choices = story.currentChoices;

        for (int i = 0; i < _choices.Count; i++)
        {
            GameObject temp = Instantiate(customButton, optionPanel.transform);
            temp.transform.GetChild(0).GetComponent<Text>().text = _choices[i].text;
            temp.AddComponent<Decision>();
            temp.GetComponent<Decision>().element = _choices[i];
            temp.GetComponent<Button>().onClick.AddListener(() => { temp.GetComponent<Decision>().Decide(); });
        }

        optionPanel.SetActive(true);

        yield return new WaitUntil(() => { return choiceSelected != null; });

        AdvanceFromDecision();
    }

    // Tells the story which branch to go to
    public static void SetDecision(object element)
    {
        choiceSelected = (Choice)element;
        story.ChooseChoiceIndex(choiceSelected.index);
    }

    // After a choice was made, turn off the panel and advance from that choice
    void AdvanceFromDecision()
    {
        optionPanel.SetActive(false);
        for (int i = 0; i < optionPanel.transform.childCount; i++)
        {
            Destroy(optionPanel.transform.GetChild(i).gameObject);
        }
        choiceSelected = null; // Forgot to reset the choiceSelected. Otherwise, it would select an option without player intervention.
        AdvanceDialogue();
    }
}
