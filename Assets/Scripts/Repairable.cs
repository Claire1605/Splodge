using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class Repairable : MonoBehaviour
{
    public bool inRange = false;
    bool repairing = false;
    bool repaired = false;
    public bool emissionPossible = true;

    public List<string> repairWords = new List<string>();

    private TextInput textInput;

    public UnityEvent successEvent;
    public UnityEvent delayedSuccessEvent;
    public float delayedSuccessDelay = 5.0f;
    public Animator[] successAnimators;
    public string successAnimationTrigger;

    public int nextSceneBuildIndex;
    public float loadSceneDelay = 5.0f;
    private float loadSceneTimer = 0.0f;
    private PlayerMovement playerMovement;

    private void Start()
    {
        textInput = FindObjectOfType<TextInput>();
        playerMovement = FindObjectOfType<PlayerMovement>();
    }

    void Update()
    {
        if (repaired == false)
        {
            if (repairing && Input.GetButtonDown("Repair"))
            {
                TryToRepair();
            }
            else
            {
                if (inRange && Input.GetButtonDown("Repair"))
                {
                    StartRepairing();
                }
            }
        }
        else
        {
            loadSceneTimer += Time.deltaTime;

            if (loadSceneTimer > loadSceneDelay)
            {
                SceneManager.LoadScene(nextSceneBuildIndex);
            }
        }
    }

    public void EnterRange()
    {
        inRange = true;
    }

    public void ExitRange()
    {
        inRange = false;
    }

    public void StartRepairing()
    {
        repairing = true;

        Debug.Log("start repairing");

        textInput.Show();

        playerMovement.canMove = false;
    }

    public void DelayedSuccess()
    {
        if (delayedSuccessEvent != null)
        {
            delayedSuccessEvent.Invoke();
        }
    }

    public void TryToRepair()
    {
        repairing = false;

        textInput.Hide();

        playerMovement.canMove = true;

        if (repairWords.Contains(textInput.CurrentGuess()))
        {
            Debug.Log("success");

            repaired = true;

            emissionPossible = false;

            GetComponent<Renderer>().material.EnableKeyword("_EMISSION");
            GetComponent<Renderer>().material.SetColor("_EmissionColor", Color.white * 0);

            if (successEvent != null)
            {
                successEvent.Invoke();
            }

            if (delayedSuccessEvent != null)
            {
                Invoke("DelayedSuccess", delayedSuccessDelay);
            }

            foreach (Animator animator in successAnimators)
            {
                animator.SetTrigger(successAnimationTrigger);
            }
        }
    }
}

