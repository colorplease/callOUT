using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class SpawnPlayers : MonoBehaviour
{
   public GameObject[] players;
   public Transform[] spawns;
   
   void Start()
   {
       Transform spawnPoint = spawns[(int)PhotonNetwork.LocalPlayer.CustomProperties["playerCharacter"]];
       GameObject playerToSpawn = players[(int)PhotonNetwork.LocalPlayer.CustomProperties["playerCharacter"]];
       PhotonNetwork.Instantiate(playerToSpawn.name, spawnPoint.position, Quaternion.identity);
   }
}
