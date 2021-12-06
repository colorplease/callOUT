using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtHealth : MonoBehaviour
{
    public float health;
    public float damage;
    public bool isGunMan;
    [SerializeField]GameObject scaredOf;
    [SerializeField]float invincibilityFrames;
    [SerializeField]float invincibilityFramesTimer;
    [SerializeField]bool hit;

    void Start()
    {
        invincibilityFramesTimer = invincibilityFrames;
    }
    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == scaredOf.tag)
        {
            //cp drama/biopic/ray.txt drama/biopic/notorious.txt drama/historical/ come fucking on kyle
            hit = true;

        }
    }

    void Update()
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
