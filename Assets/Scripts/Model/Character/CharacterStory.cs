using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class CharacterStory
{
    //put story object here
    public Location _storyLocation;
    public bool _finished;
    public bool presequite_decision; //if the story depends on what decision has been made before (it can be bool or int or other type depending on the complexity of the decision)
    public bool final_decision; //what decision is made in the story (it can be bool or int or other type depending on the complexity of the decision)
}
