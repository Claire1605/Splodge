using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Framerate : MonoBehaviour
{
    public int framerate = 8;

    void Start()
    {
        Application.targetFrameRate = framerate;
    }

}
