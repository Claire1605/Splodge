using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDetection : MonoBehaviour
{
    float emissionMax = 2.0f;
    float emissionNormal = 0.0f;

    public bool isWithinRangeOfCreature = false;


    public void OnTriggerEnter(Collider other)
    {
        //Debug.Log(other.gameObject.name);
        if (other.gameObject.GetComponent<Renderer>() && other.gameObject.GetComponent<Renderer>().material.HasProperty("_EmissionColor"))
        {
            Material mat = other.gameObject.GetComponent<Renderer>().material;
            mat.EnableKeyword("_EMISSION");
            mat.SetColor("_EmissionColor", Color.white * emissionMax);
            isWithinRangeOfCreature = true;
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.gameObject.GetComponent<Renderer>() && other.gameObject.GetComponent<Renderer>().material.HasProperty("_EmissionColor"))
        {
            Material mat = other.gameObject.GetComponent<Renderer>().material;
            mat.EnableKeyword("_EMISSION");
            mat.SetColor("_EmissionColor", Color.white * emissionNormal);
            isWithinRangeOfCreature = false;
        }
    }
}
