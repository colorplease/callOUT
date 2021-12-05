using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ADS : MonoBehaviour
{
    [SerializeField]Transform aimPosition;
    [SerializeField]Transform restPosition;
    [SerializeField]Transform propGun;
    [SerializeField]Vector3 gunTipChange;
    [SerializeField]Vector3 gunTipStart;
    [SerializeField]Vector3 propGunChange;
    [SerializeField]Vector3 propGunStart;

    [SerializeField]Transform gunTip;
    [SerializeField]Animator cross;
    public float aimSpeed;
    public float aimSpeedFOV;
    public float restingFOV;
    public float aimFOV;
    public Camera playerCam;
    [SerializeField]WeaponSway swaying;
    [SerializeField]PlayerMovement snese;
    float senseChangeX;
    float senseChangeY;
    float senseStartX;
    float senseStartY;
    float startSway;
    float startMaxSpeed;
    float changedMaxSpeed;
    [SerializeField]float swayChange;
    public bool aiming;

    void Start()
    {
        senseChangeX = snese.sensitivityX - 20f; 
        senseChangeY = snese.sensitivityY - 20f; 
        senseStartX = snese.sensitivityX;
        senseStartY = snese.sensitivityY;
        startSway = swaying.swayMultiplier;
        startMaxSpeed = snese.maxSpeed;
        changedMaxSpeed = snese.maxSpeed * 0.5f;
    }
    void Update()
    {
        if (Input.GetMouseButton(1))
        {
            Aim();
        }
        else if (transform.position != restPosition.position)
        {
            NotAimed();
        }
    }
    void Aim()
{
            aiming = true;
            transform.localPosition = Vector3.Lerp(transform.localPosition, aimPosition.localPosition, Time.deltaTime * aimSpeed);
            playerCam.fieldOfView = Mathf.Lerp(playerCam.fieldOfView, aimFOV, Time.deltaTime * aimSpeedFOV);
            gunTip.localPosition = gunTipChange;
            propGun.localPosition = Vector3.Lerp(propGun.localPosition, propGunChange, Time.deltaTime * aimSpeed);
            cross.SetBool("ADS", true);
            snese.sensitivityX = senseChangeX;
            snese.sensitivityY= senseChangeY;
            swaying.swayMultiplier = swayChange;
            snese.maxSpeed = changedMaxSpeed;
}

    void NotAimed()
{
            aiming = false;
            transform.localPosition = Vector3.Lerp(transform.localPosition, restPosition.localPosition, Time.deltaTime * aimSpeed);
            playerCam.fieldOfView = Mathf.Lerp(playerCam.fieldOfView, restingFOV, Time.deltaTime * aimSpeedFOV);
            gunTip.localPosition = gunTipStart;
            propGun.localPosition = Vector3.Lerp(propGun.localPosition, propGunStart, Time.deltaTime * aimSpeed);
             cross.SetBool("ADS", false);
             snese.sensitivityX = senseStartX;
            snese.sensitivityY = senseStartY;
            swaying.swayMultiplier = startSway;
            snese.maxSpeed = startMaxSpeed;
}
}


