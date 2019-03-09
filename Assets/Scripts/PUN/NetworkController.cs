using System;
using UnityEngine;

namespace PUN
{
    public class NetworkController : MonoBehaviour
    {

        public GameObject playerGameObject;

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
            
            Debug.Log("On tente de rejoindre une room aléatoire.");
        
            //commande pour rejoindre une room random;
            PhotonNetwork.JoinRandomRoom();
        }

        void OnPhotonRandomJoinFailed()
        //Le callback dans le cas où on arrive pas à rejoindre de room au hasard, on en crée une.
        {
            Debug.Log("Impossible de rejoindre une random room -> Création d'une room.");
            PhotonNetwork.CreateRoom(null);
        }

        void OnJoinedRoom()
        //Une fois qu'on est dans une room, on instancie le joueur de manière à ce que tout le monde puisse le voir.
        {
            Debug.Log("On vient de rejoindre une room");
            // On instancie le joueur, en récupérant le prefab, sa position et sa rotation
            PhotonNetwork.Instantiate("Prefabs/" + playerGameObject.name, playerGameObject.transform.position,
                Quaternion.identity, 0);
        }
    }
}
