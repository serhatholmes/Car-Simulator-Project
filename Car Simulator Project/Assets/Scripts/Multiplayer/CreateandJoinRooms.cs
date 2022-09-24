using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;

public class CreateandJoinRooms : MonoBehaviourPunCallbacks
{
    
    public InputField createInpt;

    public InputField joinInpt;

    public void CreateRoom(){

        PhotonNetwork.CreateRoom(createInpt.text);
    }

    public void JoinRoom(){

        PhotonNetwork.JoinRoom(joinInpt.text);
    }

    public override void OnJoinedRoom()
    {
        PhotonNetwork.LoadLevel("Gameplay");
    }
}
