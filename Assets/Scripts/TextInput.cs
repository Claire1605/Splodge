using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextInput : MonoBehaviour
{
    public AlphabetReference alphabetReference;
    public Sprite empty;
    public List<Image> letters = new List<Image>();
    private int numberOfLettersGuessed = 0;

    private char character;

    void Update()
    {
        if (Input.anyKeyDown)
        {
            for (int i = 97; i < 123; i++)
            {
                if (Input.GetKeyDown((KeyCode)i)) //which keycode it is
                {
                    character = (char)i;

                    for (int j = 0; j < letters.Count; j++)
                    {
                        if (letters[j].sprite == empty)
                        {
                            letters[j].sprite = alphabetReference.characterToClay(character);
                            numberOfLettersGuessed = j;
                            break;
                        }
                    }
                }
            }
        }

        if (Input.GetKeyDown(KeyCode.Return))
        {
            for (int i = 0; i < letters.Count; i++)
            {
                letters[i].sprite = empty;
            }
            numberOfLettersGuessed = 0;
        }
        
        if (Input.GetKeyDown(KeyCode.Backspace))
        {
            letters[numberOfLettersGuessed].sprite = empty;

            numberOfLettersGuessed -= 1;

            if (numberOfLettersGuessed < 0)
                numberOfLettersGuessed = 0;
        }
    }
}
