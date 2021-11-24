using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuckySucky : MonoBehaviour
{
    [Header("Suck Logic")]
    [SerializeField]bool sucking;
    [SerializeField]bool canSuck = true;
    [SerializeField]float startingPower;
    public float remainingPower;
    [SerializeField]float coolDownTimer;
    [SerializeField]float startingCoolDownTimer;
    [SerializeField]float overheatTimer;
    [SerializeField]float overheatTimerLimit;
    bool playingStartSuck;
    [Header("Keybinds")]
    public KeyCode suck;
    [Header("Suck Settings")]
    [SerializeField]float suckStrength;
    [SerializeField]float suckStrengthMultiplier;

    [SerializeField]float maxSuckStrength;
    [Header("Other")]

    [SerializeField]Transform suckPoint;
    bool playOff;
    [Header("Audio")]
    [SerializeField]AudioSource vac;
    [SerializeField]AudioClip fullVac;
    [SerializeField]AudioClip stopVac;
    [Header("VFX")]
    [SerializeField]ParticleSystem suckyAir;
    [SerializeField]MeshRenderer vacuumTip;
    [SerializeField]float heatValue = 1f;
    [SerializeField]Color startingColor;
    [SerializeField]Color endingColor;

    void Start()
    {
        //Define Vacuum Audio Source
        vac = GameObject.Find("Sucky").GetComponent<AudioSource>();
        vacuumTip = GameObject.Find("Vacuum Tip").GetComponent<MeshRenderer>();
        coolDownTimer = startingCoolDownTimer;
        startingColor = vacuumTip.material.color;
    }
    // Update is called once per frame
    void Update()
    {
        HeatEffect();
        if (Input.GetKey(suck))
        {
            //When Sucking, execute
            if (canSuck && sucking)
            {
            SUCK();
            overheatTimer += Time.deltaTime;
            vacuumTip.material.color = Color.Lerp(vacuumTip.material.color, endingColor, 0.1f * Time.deltaTime);
            if (heatValue > 0)
            {
                heatValue -= Time.deltaTime * 0.2f; 
            }
            }
        }
        else
        {
            if (overheatTimer > 0)
            {
                overheatTimer -= Time.deltaTime;
            }
            if (heatValue < 1)
            {
                heatValue += Time.deltaTime * 0.3f; 
                vacuumTip.material.color = Color.Lerp(vacuumTip.material.color, startingColor, 0.5f * Time.deltaTime);
            }

        }
        if (Input.GetKeyDown(suck))
        {
            //When Sucking, execute ONCE
            if (canSuck)
            {
            sucking = true;
            vac.Stop();
            suckyAir.Play();
            playingStartSuck = true;
            }
        }
        if (Input.GetKeyUp(suck))
        {
            if (canSuck)
            {
                STOPSUCK();
            }
            
        }
        if (overheatTimer >= overheatTimerLimit)
        {
            canSuck = false;
            STOPSUCK();
            overheatTimer = 0;
        }
        if (!canSuck)
        {
            if(coolDownTimer > 0)
            {
                coolDownTimer -= Time.deltaTime;
            }
            else
            {
                canSuck = true;
                coolDownTimer = startingCoolDownTimer;
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

    void STOPSUCK()
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

    void HeatEffect()
    {
        vacuumTip.material.SetFloat("_Metallic", heatValue);
        vacuumTip.material.SetFloat("_Glossiness", heatValue);   
    }

}
