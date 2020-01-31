using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class TextToClay : MonoBehaviour
{
    public string TextToDisplay = "";
    private string currentText = "";
    public AlphabetReference alphabetReference;

    void Update()
    {
        if (currentText != TextToDisplay)
        {
            foreach (var item in GetComponentsInChildren<Transform>())
            {
                if (item != gameObject.transform)
                {
                    if (!Application.isPlaying)
                    {
                        DestroyImmediate(item.gameObject);
                    }
                    else
                    {
                        Destroy(item.gameObject);
                    }
                }
            }
            foreach (var alph in TextToDisplay)
            {
                GameObject newObject = new GameObject();
                newObject.transform.parent = gameObject.transform;
                newObject.AddComponent<SpriteRenderer>();
                newObject.GetComponent<SpriteRenderer>().sprite = alphabetReference.characterToClay(alph);
                newObject.name = alph.ToString().ToUpper();
                newObject.transform.position = new Vector3(newObject.transform.GetSiblingIndex(), 0, 0);
            }
            currentText = TextToDisplay;
        }
    }
}
