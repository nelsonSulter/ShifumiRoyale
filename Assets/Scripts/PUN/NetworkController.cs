using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NetworkController : MonoBehaviour
{

    private String _gameVersion = "0.1";
    // Start is called before the first frame update
    void Start()
    {
        //Connexion au cloud Photon
        PhotonNetwork.ConnectUsingSettings(_gameVersion);
    }

    // Si et seulement si on a le callback "je viens de rejoindre le lobby", alors on permet de rejoindre une random room
    //Cette méthode est propre à photon
    void OnJoinedLobby()
    {
        
        //commande pour rejoindre une room random;
        PhotonNetwork.JoinRandomRoom();
    }

    void OnPhotonRandomJoinFailed()
    {
        Debug.Log("Impossible de rejoindre une random room -> Création d'une room.");
        PhotonNetwork.CreateRoom(null);
    }
}
