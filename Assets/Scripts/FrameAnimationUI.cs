using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FrameAnimationUI : MonoBehaviour
{
    public float fps = 9.0f;
    public List<Sprite> frames = new List<Sprite>();
    private Image image;
    private SpriteRenderer sprite;
    private float t = 0;
    public int currentFrame = 0;

    void Start()
    {
        if (GetComponent<Image>())
        {
            image = GetComponent<Image>();
        }
        else if (GetComponent<SpriteRenderer>())
        {
            sprite = GetComponent<SpriteRenderer>();
        }
    }

    void Update()
    {
        t += Time.deltaTime;
        if (t > 1 / fps)
        {
            t = 0;

            currentFrame += 1;
            if (currentFrame >= frames.Count)
            {
                currentFrame = 0;
            }

            if (GetComponent<Image>())
            {
                GetComponent<Image>().sprite = frames[currentFrame];
            }
           else if (GetComponent<SpriteRenderer>())
            {
                GetComponent<SpriteRenderer>().sprite = frames[currentFrame];
            }
        }
    }
}
