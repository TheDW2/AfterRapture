using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "Instantiate", menuName = "ScriptableObjects/Instantiate")]
public class Instantiate : ScriptableObject
{
    [SerializeField] private GameObject book;
    [SerializeField] private GameObject box;

    public void InstantiateBook()
    {
        GameObject newBook = Instantiate(book, new Vector3(-53.1f, -12.6f, 0f), Quaternion.identity);
        newBook.transform.parent = box.transform;
        for (float i = 0; i < 2; i += Time.deltaTime) {
            while (i <1.5) {
                newBook.transform.position += new Vector3(0.2f, 0f, 0f);
            }
        }
    }
}
