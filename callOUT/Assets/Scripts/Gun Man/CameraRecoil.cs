using System.Collections;
using System.Collections.Generic;
using UnityEngine;
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

    void Start()
    {
    }
    void Update()
    {
        targetRotation = Vector3.Lerp(targetRotation, Vector3.zero, returnSpeed * Time.deltaTime);
        currentRotation = Vector3.Slerp(currentRotation, targetRotation, snappiness * Time.fixedDeltaTime);
        transform.localRotation = Quaternion.Euler(currentRotation);
    }

    public void RecoilFire()
    {
            targetRotation += new Vector3(recoilX, Random.Range(-recoilY, recoilY), Random.Range(-recoilZ, recoilZ));
    }

    public void AimingFire()
    {
         targetRotation += new Vector3(aimingRecoilX, Random.Range(-aimingRecoilY, aimingRecoilY), Random.Range(-aimingRecoilZ, aimingRecoilZ));
    }

    
}
