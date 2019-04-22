
using System;
using System.IO;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using Random = UnityEngine.Random;


public class PlayerNetwork : MonoBehaviour
{

    public static PlayerNetwork instance;
    
    //on peut acceder au name de n'importe où mais on ne peut le changer que dans ce script (le setter est private)
    public string name { get; private set; }
    private PhotonView photonView;
    private int nbJoueurs;

    private PlayerMovement currentPlayer;
    
    
    
    
    
    private void Awake()
    {
        
        instance = this;
        name = "Piccolo#" + Random.Range(1000, 9999);
        
        PhotonNetwork.playerName = name;

        SceneManager.sceneLoaded += OnSceneFinishedLoading;

        photonView = GetComponent<PhotonView>();
        
        //On augmente le nombre de paquet envoyés pour éviter le delay en multi joueur, attention ça consomme plus de bande passante
        PhotonNetwork.sendRate = 60;
        PhotonNetwork.sendRateOnSerialize = 30;

    }

    private void OnSceneFinishedLoading(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == "GameEploration")
        {
            if (PhotonNetwork.isMasterClient)
            {
                masterLoadedGame();
            }
            else
            {
                nonMasterLoadedGame();
            }
        }
    }

    private void masterLoadedGame()
    {
        
        photonView.RPC("RPC_LoadedGameScene", PhotonTargets.MasterClient, PhotonNetwork.player);
        photonView.RPC("RPC_LoadGameOthers", PhotonTargets.Others);
    }
    
    private void nonMasterLoadedGame()
    {
        photonView.RPC("RPC_LoadedGameScene", PhotonTargets.MasterClient, PhotonNetwork.player);
    }

    [PunRPC]
    private void RPC_LoadGameOthers()
    {
        PhotonNetwork.LoadLevel(1);
    }

    [PunRPC]
    private void RPC_LoadedGameScene(PhotonPlayer unPhotonPlayer)
    {
        PlayerManagement.Instance.addPlayerStats(unPhotonPlayer);
        print("le joueur a été ajouté : " + unPhotonPlayer.ID);
        nbJoueurs = nbJoueurs + 1;

        if (nbJoueurs == PhotonNetwork.playerList.Length)
        {
            print("tous les joueurs ont rejoint la partie");
            photonView.RPC("RPC_CreatePlayer", PhotonTargets.All);
        }

    }

    public void newStoneDamage(PhotonPlayer unPhotonPlayer, float stoneDamage)
    {
        photonView.RPC("RPC_newStoneDamage", unPhotonPlayer, stoneDamage);
    }
    
    [PunRPC]
    private void RPC_newStoneDamage(int value)
    {
        currentPlayer.stoneDamage = value;
    }
    

    [PunRPC]
    private void RPC_CreatePlayer()
    {
        float randomValue = Random.Range(0f, 5f);
        GameObject obj = PhotonNetwork.Instantiate(Path.Combine("Prefabs", "AutoritairePLayer"), Vector3.up * randomValue,
            Quaternion.identity, 0);

        currentPlayer = obj.GetComponent<PlayerMovement>();
        
        
    }
    


 
}
