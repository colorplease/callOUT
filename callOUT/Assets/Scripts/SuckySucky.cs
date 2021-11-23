using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuckySucky : MonoBehaviour
{
    [SerializeField]bool sucking;
    bool playingStartSuck;
    public KeyCode suck;
    [SerializeField]float suckStrength;
    [SerializeField]float suckStrengthMultiplier;

    [SerializeField]float maxSuckStrength;
    [SerializeField]Transform suckPoint;
    [SerializeField]AudioSource vac;
    [SerializeField]AudioClip fullVac;
    [SerializeField]AudioClip stopVac;

    void Start()
    {
        vac = GameObject.Find("Sucky").GetComponent<AudioSource>();
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(suck))
        {
            sucking = true;
            playingStartSuck = true;
            SUCK();
        }
        if (Input.GetKeyDown(suck))
        {
            vac.Stop();
        }
        if (Input.GetKeyUp(suck))
        {
            sucking = false;
            suckStrength = 0;
            vac.Stop();
            if (playingStartSuck == true)
            {
                vac.PlayOneShot(stopVac);
                playingStartSuck = false;
            }
        }
    }

    void OnTriggerStay(Collider other)
    {
        if (other.tag == "Suckable")
        {
            if (sucking)
            {
                other.transform.position = Vector3.MoveTowards(other.transform.position, suckPoint.position, suckStrength * Time.deltaTime);
            }  
        }
    }

    void SUCK()
    {
        if (suckStrength <= maxSuckStrength)
        {
            suckStrength += suckStrengthMultiplier * Time.deltaTime;
        }
        if (!vac.isPlaying)
        {
            vac.PlayOneShot(fullVac);
        }
        
        
    }

}
