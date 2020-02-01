using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDetection : MonoBehaviour
{
    public float emissionMax = 2.0f;
    public float emissionNormal = 0.0f;

    public bool isWithinRangeOfCreature = false;


    public void OnTriggerEnter(Collider other)
    {
        //Debug.Log(other.gameObject.name);
        if (other.gameObject.GetComponent<Repairable>())
        {
            if (other.gameObject.GetComponent<Repairable>().emissionPossible)
            {
                Material mat = other.gameObject.GetComponent<Renderer>().material;
                mat.EnableKeyword("_EMISSION");
                mat.SetColor("_EmissionColor", Color.white * emissionMax);
            }
          
            isWithinRangeOfCreature = true;
            other.gameObject.GetComponent<Repairable>().EnterRange();
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.gameObject.GetComponent<Repairable>())
        {
            if (other.gameObject.GetComponent<Repairable>().emissionPossible)
            {
                Material mat = other.gameObject.GetComponent<Renderer>().material;
                mat.EnableKeyword("_EMISSION");
                mat.SetColor("_EmissionColor", Color.white * emissionNormal);
            }
                
            isWithinRangeOfCreature = false;
            other.gameObject.GetComponent<Repairable>().ExitRange();
        }
    }
}
