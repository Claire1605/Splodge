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
    private string guess = "";

    private char character;

    public GameObject bottomBar;
    public GameObject topBar;
    public GameObject spaceBar;
    public GameObject flashingCursor;
    bool showing = false;

    private void Start()
    {
        bottomBar.SetActive(false);
        topBar.SetActive(false);
        spaceBar.SetActive(false);
        flashingCursor.SetActive(false);
    }

    void Update()
    {
        if (showing)
        {
            if (Input.anyKeyDown)
            {
                for (int i = 97; i < 123; i++)
                {
                    if (Input.GetKeyDown((KeyCode)i)) //which keycode it is
                    {
                        character = (char)i;
                        guess += character;

                        for (int j = 0; j < letters.Count; j++)
                        {
                            if (letters[j].sprite == empty)
                            {
                                letters[j].sprite = alphabetReference.characterToClay(character);
                                numberOfLettersGuessed = j;
                                flashingCursor.SetActive(false);
                                break;
                            }
                        }
                    }
                }
            }

            if (Input.GetKeyDown(KeyCode.Backspace))
            {
                letters[numberOfLettersGuessed].sprite = empty;

                numberOfLettersGuessed -= 1;

                if (numberOfLettersGuessed < 0)
                    numberOfLettersGuessed = 0;

                if (numberOfLettersGuessed == 0)
                {
                    flashingCursor.SetActive(true);
                }

                guess = guess.Substring(0, numberOfLettersGuessed);
            }
        }
    }
    
    public string CurrentGuess()
    {
        return guess;
    }

    public void Show()
    {
        showing = true;
        bottomBar.SetActive(true);
        topBar.SetActive(true);
        spaceBar.SetActive(false);
        flashingCursor.SetActive(true);

        for (int i = 0; i < letters.Count; i++)
        {
            letters[i].sprite = empty;
        }
        numberOfLettersGuessed = 0;
        guess = "";
    }

    public void Hide()
    {
        showing = false;
        bottomBar.SetActive(false);
        topBar.SetActive(false);
        spaceBar.SetActive(true);
        flashingCursor.SetActive(false);
    }
}
