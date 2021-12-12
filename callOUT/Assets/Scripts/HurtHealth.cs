using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class HurtHealth : MonoBehaviour
{
    public float health;
    public float damage;
    public bool isGunMan;
    [SerializeField]GameObject scaredOf;
    [SerializeField]float invincibilityFrames;
    [SerializeField]float invincibilityFramesTimer;
    [SerializeField]bool hit;
    public PhotonView view;

    void Start()
    {
        invincibilityFramesTimer = invincibilityFrames;
        view = GetComponent<PhotonView>();
    }
    void OnCollisionEnter(Collision other)
    {
        if (view.IsMine)
        {
        if (other.gameObject.tag == scaredOf.tag)
        {
            //cp drama/biopic/ray.txt drama/biopic/notorious.txt drama/historical/ come fucking on kyle
            hit = true;

        }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (view.IsMine)
        {
         if (other.tag == scaredOf.tag && !isGunMan)
        {
            //cp drama/biopic/ray.txt drama/biopic/notorious.txt drama/historical/ come fucking on kyle
            hit = true;

        }
        }
    }

    void Update()
    {
        if (view.IsMine)
        {
        if (hit && invincibilityFramesTimer > 0 && health > 0)
        {
            invincibilityFramesTimer -= Time.fixedDeltaTime;
        }
        else if (invincibilityFramesTimer <= 0 && health > 0)
        {
            hit = false;
            health -= damage;
            invincibilityFramesTimer = invincibilityFrames;

        }
        else if (health <= 0)
        {
            gameObject.GetComponent<PlayerMovement>().enabled = false;
            gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
            gameObject.GetComponentInChildren<WeaponSway>().enabled = false;
            gameObject.GetComponentInChildren<ADS>().enabled = false;
            gameObject.GetComponentInChildren<ProjectileGunTutorial>().enabled = false;
        }
        }
    }
}
