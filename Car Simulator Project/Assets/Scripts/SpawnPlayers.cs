using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class SpawnPlayers : MonoBehaviour
{
    public GameObject playerPrefab;
    public Transform spawnPos;
    private void Start() {
        // spawn selected prefab
        PhotonNetwork.Instantiate(playerPrefab.name, spawnPos.position,Quaternion.identity);
 
    }
}
