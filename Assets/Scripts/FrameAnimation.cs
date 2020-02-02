using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FrameAnimation : MonoBehaviour
{
    public float fps = 9.0f;
    public List<Texture2D> frames = new List<Texture2D>();
    private Material mat;
    private float t = 0;
    public int currentFrame = 0;

    void Start()
    {
        if (GetComponent<Renderer>())
        {
            mat = GetComponent<Renderer>().material;
        }
    }

    void Update()
    {
        t += Time.deltaTime;
        if (t > 1/fps)
        {
            t = 0;

            currentFrame += 1;
            if (currentFrame >= frames.Count)
            {
                currentFrame = 0;
            }

            mat.SetTexture("_MainTex", frames[currentFrame]);
        }
    }
}
