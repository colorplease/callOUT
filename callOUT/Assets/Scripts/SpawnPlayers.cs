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
       Transform spawnPoint = spawns[PlayerPrefs.GetInt("playerCharacter")];
       GameObject playerToSpawn = players[PlayerPrefs.GetInt("playerCharacter")];
       PhotonNetwork.Instantiate(playerToSpawn.name, spawnPoint.position, Quaternion.identity);
   }
}
