using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    Vector3 lastBulletImpact;
    [SerializeField]GameObject impactParticle;
    void OnCollisionEnter(Collision other)
    {
        lastBulletImpact = transform.position;
        impactParticle.GetComponent<ParticleSystemRenderer>().material = other.gameObject.GetComponent<Renderer>().material; 
        GameObject deez = Instantiate(impactParticle, lastBulletImpact, transform.rotation);
        deez.transform.Rotate(0f, 180f, 0f);
        Destroy(gameObject);
    }

    void Awake()
    {
        Destroy(gameObject, 15f);
    }
}
