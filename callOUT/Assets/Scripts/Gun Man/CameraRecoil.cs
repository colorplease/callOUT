using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class CameraRecoil : MonoBehaviour
{
    [Header("Recoil")]
    private Vector3 currentRotation;
    private Vector3 targetRotation;

    [Header("Hipfire Recoil")]
    [SerializeField]float recoilX;
    [SerializeField]float recoilY;
    [SerializeField]float recoilZ; 

    [Header("Aiming Recoil")]
    [SerializeField]float aimingRecoilX;
    [SerializeField]float aimingRecoilY;
    [SerializeField]float aimingRecoilZ; 

    [Header("Settings")]
    [SerializeField]float snappiness;
    [SerializeField]float returnSpeed;
    PhotonView view;

    void Start()
    {
        view = GetComponentInParent<PhotonView>();
    }
    void Update()
    {
        if (view.IsMine)
        {
        targetRotation = Vector3.Lerp(targetRotation, Vector3.zero, returnSpeed * Time.deltaTime);
        currentRotation = Vector3.Slerp(currentRotation, targetRotation, snappiness * Time.fixedDeltaTime);
        transform.localRotation = Quaternion.Euler(currentRotation);
        }
    }

    public void RecoilFire()
    {
        if (view.IsMine)
        {
            targetRotation += new Vector3(recoilX, Random.Range(-recoilY, recoilY), Random.Range(-recoilZ, recoilZ));
        }
    }

    public void AimingFire()
    {
        if (view.IsMine)
        {
         targetRotation += new Vector3(aimingRecoilX, Random.Range(-aimingRecoilY, aimingRecoilY), Random.Range(-aimingRecoilZ, aimingRecoilZ));
        }
    }

    
}
