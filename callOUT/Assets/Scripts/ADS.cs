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
    void Update()
    {
        if (Input.GetMouseButton(1))
        {
            transform.localPosition = Vector3.Lerp(transform.localPosition, aimPosition.localPosition, Time.deltaTime * aimSpeed);
            playerCam.fieldOfView = Mathf.Lerp(playerCam.fieldOfView, aimFOV, Time.deltaTime * aimSpeedFOV);
            gunTip.localPosition = gunTipChange;
            propGun.localPosition = Vector3.Lerp(propGun.localPosition, propGunChange, Time.deltaTime * aimSpeed);
            cross.SetBool("ADS", true);
        }
        else if (transform.position != restPosition.position)
        {
            transform.localPosition = Vector3.Lerp(transform.localPosition, restPosition.localPosition, Time.deltaTime * aimSpeed);
            playerCam.fieldOfView = Mathf.Lerp(playerCam.fieldOfView, restingFOV, Time.deltaTime * aimSpeedFOV);
            gunTip.localPosition = gunTipStart;
            propGun.localPosition = Vector3.Lerp(propGun.localPosition, propGunStart, Time.deltaTime * aimSpeed);
             cross.SetBool("ADS", false);
        }
    }
}
