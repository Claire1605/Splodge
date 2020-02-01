using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class TextToClay : MonoBehaviour
{
    public string TextToDisplay = "";
    public int growTextLength = 0;
    private string currentText = "";
    public AlphabetReference alphabetReference;
    public int rowLengthMax = 16;
    public List<string> rows = new List<string>();
    private string[] words;

    private bool growing = false;
    public float growDelay = 0.2f;
    private float growTime = 0.0f;

    void Update()
    {
        if (growing)
        {
            growTime += Time.deltaTime;

            if (growTime > growDelay)
            {
                growTime = 0.0f;
                growTextLength += 1;

                if (growTextLength >= TextToDisplay.Length)
                {
                    growing = false;
                }
            }
        }

        string showText = TextToDisplay + ' ';

        if (growing)
        {
            showText = showText.Substring(0, growTextLength) + ' ';
        }
        
        if (currentText != showText)
        {
            for (int child = 0; child < transform.childCount; child++)
            {
                if (child > showText.Length)
                {
                    transform.GetChild(child).gameObject.SetActive(false);
                }
                else
                {
                    transform.GetChild(child).gameObject.SetActive(true);
                }
            }
            
            words = showText.Split(' ');
            int charCounter = 0;
            int startFrom = 0;
            int currentRow = 0;
            rows.Clear();

            for (int i = 0; i < words.Length; i++)
            {
                if (charCounter + words[i].Length >= rowLengthMax)
                {
                    rows.Add("");
                    for (int j = startFrom; j < i; j++)
                    {
                        rows[currentRow] += words[j] + ' ';
                    }
                    currentRow += 1;
                    startFrom = i;
                    charCounter = 0;
                    charCounter += words[i].Length + 1;
                }
                else if (i == words.Length - 1)
                {
                    rows.Add("");

                    for (int j = startFrom; j <= i; j++)
                    {
                        rows[currentRow] += words[j] + ' ';
                    }
                }
                else
                {
                    charCounter += words[i].Length + 1;
                }
            }

            int letterIndex = 0;

            for (int i = 0; i < rows.Count; i++)
            {
                for (int j = 0; j < rows[i].Length; j++)
                {
                    GameObject newObject;

                    if (letterIndex < transform.childCount)
                    {
                        newObject = transform.GetChild(letterIndex).gameObject;
                    }
                    else
                    {
                        newObject = new GameObject();
                        newObject.transform.parent = gameObject.transform;
                        newObject.transform.SetSiblingIndex(letterIndex);
                        newObject.AddComponent<SpriteRenderer>();
                    }

                    newObject.GetComponent<SpriteRenderer>().sprite = alphabetReference.characterToClay(rows[i][j]);
                    newObject.name = rows[i][j].ToString().ToUpper();

                    newObject.transform.localPosition = new Vector3(j, i * -2, 0);
                    newObject.transform.localEulerAngles = Vector3.zero;

                    letterIndex += 1;
                }
            }
                
            currentText = showText;
        }
    }

    public void GrowText()
    {
        growTextLength = 0;
        growTime = 0.0f;
        growing = true;
    }

    public void SetText(string text)
    {
        TextToDisplay = text;
    }
}
