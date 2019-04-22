using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace PUN
{
    public class NetworkController : MonoBehaviour
    {

        public GameObject playerGameObject;
        public GameObject stats;
        public GameObject inventory;
        private int i;

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
            
            
            // On instancie un GameObject "GameControl" ce sont les stats du personnage
            PhotonNetwork.Instantiate("Prefabs/" + stats.name, stats.transform.position, Quaternion.identity, 0);
            
            
            //On instancie l'inventaire du joueur
            PhotonNetwork.Instantiate("Prefabs/" + inventory.name, inventory.transform.position, Quaternion.identity,
                0);
            
            
            foreach (GameObject inventaire in GameObject.FindGameObjectsWithTag("Inventory")) {
                if (inventaire.GetComponent<PhotonView>().owner == PhotonNetwork.player)
                {
                    

                    foreach (GameObject itemslot in GameObject.FindGameObjectsWithTag("ItemSlot"))
                    {
                        
                        switch (itemslot.name)
                        {
                            case "ItemImage0":
                                EventTrigger trigger0 = itemslot.GetComponent<EventTrigger>();
                                EventTrigger.Entry entry0 = new EventTrigger.Entry();
                                entry0.eventID = EventTriggerType.PointerClick;
                                entry0.callback.AddListener((data) =>
                                {
                                    inventaire.GetComponent<Inventory>().RemoveItem(0);
                                });
                                trigger0.triggers.Add(entry0);
                                break;
                    
                            case "ItemImage1":
                                EventTrigger trigger1 = itemslot.GetComponent<EventTrigger>();
                                EventTrigger.Entry entry1 = new EventTrigger.Entry();
                                entry1.eventID = EventTriggerType.PointerClick;
                                entry1.callback.AddListener((data) =>
                                {
                                    inventaire.GetComponent<Inventory>().RemoveItem(1);
                                });
                                trigger1.triggers.Add(entry1);
                                break;
                    
                            case "ItemImage2":
                                EventTrigger trigger2 = itemslot.GetComponent<EventTrigger>();
                                EventTrigger.Entry entry2 = new EventTrigger.Entry();
                                entry2.eventID = EventTriggerType.PointerClick;
                                entry2.callback.AddListener((data) =>
                                {
                                    inventaire.GetComponent<Inventory>().RemoveItem(2);
                                });
                                trigger2.triggers.Add(entry2);
                                break;
                    
                            case "ItemImage3":
                                EventTrigger trigger3 = itemslot.GetComponent<EventTrigger>();
                                EventTrigger.Entry entry3 = new EventTrigger.Entry();
                                entry3.eventID = EventTriggerType.PointerClick;
                                entry3.callback.AddListener((data) =>
                                {
                                    inventaire.GetComponent<Inventory>().RemoveItem(3);
                                });
                                trigger3.triggers.Add(entry3);
                                break;
                        }
                       
                    }
                }


            }
 
        }
    }
}
