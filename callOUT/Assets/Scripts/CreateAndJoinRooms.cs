using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;
using TMPro;

public class CreateAndJoinRooms : MonoBehaviourPunCallbacks
{
   public TMP_InputField createInput;
   public TMP_InputField joinInput;

   public void CreateRoom()
   {
       if(createInput.text.Length >= 1)
       {
           PhotonNetwork.CreateRoom(createInput.text, new RoomOptions(){MaxPlayers = 3});
       }
   }

   public void JoinRoom()
   {
       if(joinInput.text.Length >= 1)
       {
           PhotonNetwork.JoinRoom(joinInput.text);
       }
   }

   public override void OnJoinedRoom()
   {
       PhotonNetwork.LoadLevel("PlayerSelect");
   }
}
