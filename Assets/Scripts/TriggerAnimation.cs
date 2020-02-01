using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TriggerAnimation : MonoBehaviour
{
    public Animator animator;
    public string animationTriggerEnter = "";
    public UnityEvent triggerEnterEvent;
    public string animationTriggerExit = "";
    public UnityEvent triggerExitEvent;
    public string triggerTag = "";
    private bool hasBeenTriggered = false;

    private void OnTriggerEnter(Collider other)
    {
        if (!hasBeenTriggered)
        {
            ManualTrigger(other);
        }
    }
    
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag(triggerTag))
        {
            hasBeenTriggered = false;

            animator.SetTrigger(animationTriggerExit);

            if (triggerExitEvent != null)
            {
                triggerExitEvent.Invoke();
            }
        }
    }

    public void ManualTrigger(Collider other)
    {
        hasBeenTriggered = true;
        if (other.CompareTag(triggerTag))
        {
            animator.SetTrigger(animationTriggerEnter);

            if (triggerEnterEvent != null)
            {
                triggerEnterEvent.Invoke();
            }
        }
    }
}
