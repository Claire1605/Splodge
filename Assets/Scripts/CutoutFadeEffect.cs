using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutoutFadeEffect : MonoBehaviour
{
    public float speed = 1.0f;
    public AnimationCurve sinCurve;

    private Material mat;
    private float t = 0;

    void Start()
    {
        mat = GetComponent<Renderer>().material;
    }

    void Update()
    {
        t += Time.deltaTime * speed;
        if (t > 1)
        { t = 0; }
        mat.SetFloat("_Cutoff", sinCurve.Evaluate(t));
    }


}
