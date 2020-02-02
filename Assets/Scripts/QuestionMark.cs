using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestionMark : MonoBehaviour
{
    private Animator anim;
    private Repairable repairable;

    private bool visible = false;
    private bool complete = false;

    private void Start()
    {
        anim = GetComponent<Animator>();
        repairable = GetComponentInParent<Repairable>();
    }

    private void Update()
    {
        if (!complete)
        {
            if (repairable.inRange && !visible)
            {
                GrowQuestionMark();
            }
            else if (!repairable.inRange && visible)
            {
                ShrinkQuestionMark(false);
            }
        }
    }

    public void GrowQuestionMark()
    {
        visible = true;
        anim.SetTrigger("grow");
    }

    public void ShrinkQuestionMark(bool final)
    {
        if (final)
        {
            complete = true;
        }
        visible = false;
        anim.SetTrigger("shrink");
    }
}
