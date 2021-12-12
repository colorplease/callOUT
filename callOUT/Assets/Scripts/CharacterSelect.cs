using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using TMPro;


public class CharacterSelect : MonoBehaviour
{
    public TMP_Text text;

    public void SelectedVacuum()
    {
        PlayerPrefs.SetInt("playerCharacter", 0);
    }

    public void SelectedGun()
    {
       PlayerPrefs.SetInt("playerCharacter", 1);
    }

    public void StartRoom()
    {
         //if (PhotonNetwork.PlayerList.Length == 2)
        {
            PhotonNetwork.LoadLevel("TESTING");
            
        }
    }
}
