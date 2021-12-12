using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class SpawnPlayers : MonoBehaviour
{
   public GameObject player;
   public Transform[] spawns;
   
   void Start()
   {
       int randomNumer = Random.Range(0, spawns.Length);
       Transform spawnPoint = spawns[randomNumer];
       PhotonNetwork.Instantiate(player.name, spawnPoint.position, Quaternion.identity);
   }
}
