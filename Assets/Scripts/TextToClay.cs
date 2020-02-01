using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class TextToClay : MonoBehaviour
{
    public string TextToDisplay = "";
    private string currentText = "";
    public AlphabetReference alphabetReference;
    public int rowLengthMax = 16;
    public List<string> rows = new List<string>();
    private string[] words;

    void Update()
    {
        if (currentText != TextToDisplay)
        {
            if (transform.childCount > 0)
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
            }
            else
            {
                TextToDisplay += ' ';
                words = TextToDisplay.Split(' ');
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
                            rows[currentRow] += words[j];
                        }
                    }
                    else
                    {
                        charCounter += words[i].Length + 1;
                    }
                }

                for (int i = 0; i < rows.Count; i++)
                {
                    for (int j = 0; j < rows[i].Length; j++)
                    {
                        GameObject newObject = new GameObject();
                        newObject.transform.parent = gameObject.transform;
                        newObject.AddComponent<SpriteRenderer>();
                        newObject.GetComponent<SpriteRenderer>().sprite = alphabetReference.characterToClay(rows[i][j]);
                        newObject.name = rows[i][j].ToString().ToUpper();

                        newObject.transform.localPosition = new Vector3(j, i * -2, 0);
                        newObject.transform.localEulerAngles = Vector3.zero;
                    }
                }
                
                currentText = TextToDisplay;
            }
        }
    }
}
