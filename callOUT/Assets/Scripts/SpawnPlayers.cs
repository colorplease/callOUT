using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class SpawnPlayers : MonoBehaviour
{
   public GameObject player;
   public Transform spawn;
   
   void Awake()
   {
       PhotonNetwork.Instantiate(player.name, spawn.position, Quaternion.identity);
   }
}
