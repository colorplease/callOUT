using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using TMPro;

public class CharacterSelect : MonoBehaviour
{
    public int playerCharacter;
    public TMP_Text text;
    public void SelectedVacuum()
    {
        playerCharacter = 1;
        playerCharacter = (int)PhotonNetwork.LocalPlayer.CustomProperties["playerCharacter"]; 
    }

    public void SelectedGun()
    {
        playerCharacter = 0;
        playerCharacter = (int)PhotonNetwork.LocalPlayer.CustomProperties["playerCharacter"]; 
    }

    public void StartRoom()
    {
         if (PhotonNetwork.PlayerList.Length == 2)
        {
            PhotonNetwork.LoadLevel("TESTING");
        }
    }
}
