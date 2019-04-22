using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PickUpItems : Interactable
{
    //C'est la classe qui hérite de Interactable et dont toutes les classes concernant les objets que l'on peut RAMASSER du jeu vont hériter
    //De ce fait elle se différencie de la classe Interactable par son attribut Sprite qui sera affiché dans l'un des deux inventaire et par son game object
    //la fonction interact est réécrite, ce que tous les objets que l'on peut ramasser ont en commun, c'est qu'ils disparaitront après avoir été ramassés.
    

    
    public Sprite image;

    [SerializeField]
    private GameObject model;
   
    
    public override void interact(PhotonView unPhotonView)
    {
        print("on desactive l'item");
        model.SetActive(false);
        
    }
}
