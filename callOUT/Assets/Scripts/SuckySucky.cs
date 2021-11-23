using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuckySucky : MonoBehaviour
{
    [Header("Suck Logic")]
    [SerializeField]bool sucking;
    bool playingStartSuck;
    [Header("Keybinds")]
    public KeyCode suck;
    [Header("Suck Settings")]
    [SerializeField]float suckStrength;
    [SerializeField]float suckStrengthMultiplier;

    [SerializeField]float maxSuckStrength;
    [Header("Other")]
    [SerializeField]Transform suckPoint;
    [Header("Audio")]
    [SerializeField]AudioSource vac;
    [SerializeField]AudioClip fullVac;
    [SerializeField]AudioClip stopVac;
    [Header("VFX")]
    [SerializeField]ParticleSystem suckyAir;

    void Start()
    {
        //Define Vacuum Audio Source
        vac = GameObject.Find("Sucky").GetComponent<AudioSource>();
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(suck))
        {
            //When Sucking, execute
            sucking = true;
            playingStartSuck = true;
            SUCK();
        }
        if (Input.GetKeyDown(suck))
        {
            //When Sucking, execute ONCE
            vac.Stop();
            suckyAir.Play();
        }
        if (Input.GetKeyUp(suck))
        {
            //When no longer sucking, execute
            sucking = false;
            suckStrength = 0;
            vac.Stop();
            suckyAir.Stop(true, ParticleSystemStopBehavior.StopEmitting);
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
                //object attraction when sucking
                Vector3 movePos = other.transform.position;
                movePos.x = Mathf.MoveTowards(other.transform.position.x, suckPoint.position.x, suckStrength * Time.deltaTime / other.attachedRigidbody.mass);
                movePos.y = Mathf.MoveTowards(other.transform.position.y, suckPoint.position.y, suckStrength * Time.deltaTime / other.attachedRigidbody.mass);
                movePos.z = Mathf.MoveTowards(other.transform.position.z, suckPoint.position.z, suckStrength * Time.deltaTime / other.attachedRigidbody.mass);
                other.attachedRigidbody.MovePosition(movePos);


            }  
        }
    }

    void SUCK()
    {
        if (suckStrength <= maxSuckStrength)
        {
            //suck strength
            suckStrength += suckStrengthMultiplier * Time.deltaTime;
        }
        if (!vac.isPlaying)
        {
            vac.PlayOneShot(fullVac);
        }
        
        
    }

}
