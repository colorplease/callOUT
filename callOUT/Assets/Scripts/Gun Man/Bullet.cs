using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    Vector3 lastBulletImpact;
    [SerializeField]GameObject impactParticle;
    [SerializeField]GameObject bloodParticle;
    public float damage;
    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag != "Player" && other.gameObject.tag != "Kazoo" && other.gameObject.tag != "KazooDeath")
        {
        lastBulletImpact = transform.position;
        impactParticle.GetComponent<ParticleSystemRenderer>().material = other.gameObject.GetComponent<Renderer>().material; 
        GameObject deez = Instantiate(impactParticle, lastBulletImpact, transform.rotation);
        deez.transform.Rotate(0f, 180f, 0f);
        Destroy(gameObject);
        }
        else if (other.gameObject.tag == "Player")
        {
            Destroy(gameObject);
        }
        else if (other.gameObject.tag == "Kazoo")
        {
            other.gameObject.GetComponent<KazooManAI>().health -= damage;
            lastBulletImpact = transform.position;
            GameObject deez = Instantiate(bloodParticle, lastBulletImpact, transform.rotation);
            deez.transform.Rotate(0f, 180f, 0f);
            Destroy(gameObject);
            Destroy(gameObject);
        }
        else if (other.gameObject.tag == "KazooDeath")
        {
        lastBulletImpact = transform.position;
        GameObject deez = Instantiate(bloodParticle, lastBulletImpact, transform.rotation);
        deez.transform.Rotate(0f, 180f, 0f);
        Destroy(gameObject);
        }
    }

    void Awake()
    {
        Destroy(gameObject, 15f);
    }
}
