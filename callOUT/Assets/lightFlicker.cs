using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lightFlicker : MonoBehaviour
{
    public int lightNum;
    public GameObject lightCone;
    void Update()
    {
        lightNum = Random.Range(0, 10000);
        if (lightNum < 60)
        {
            StartCoroutine(turnOff());
        }
    }

    IEnumerator turnOff()
    {
        GetComponent<Light>().enabled = false;
        lightCone.SetActive(false);
        yield return new WaitForSeconds(1f);
        GetComponent<Light>().enabled = true;
        lightCone.SetActive(true);

    }
}
