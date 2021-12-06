using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Radui : MonoBehaviour
{
   [SerializeField]float health = 5;
   [SerializeField]float easter;
   [SerializeField]AudioSource audioSource;

   void Start()
   {
       audioSource = gameObject.GetComponentInChildren<AudioSource>();
   }
   void OnCollisionEnter(Collision other)
   {
       if (other.gameObject.tag == "bullet" && health > 0)
       {
           health--;
           easter = Random.Range(0.5f, 3);
           print(audioSource.pitch);
           
       }
       else if (health <= 0)
       {
           audioSource.Stop();
           transform.DetachChildren();
       }
   }

   void Update()
   {
       if (audioSource.isPlaying)
       {
           audioSource.pitch = Mathf.Lerp(audioSource.pitch, easter , Time.deltaTime * 1f);
       }
   }
}
