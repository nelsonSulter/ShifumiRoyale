using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Consumable : PickUpItems
{
    // Cette Classe concerne tous les objets de type consommable. Elle hérite de PickUpItem
    //elle gagne une fonction bonus pour appliquer les bonus à GameControl.player une fois l'objet équipé
    // et une fonction drop, qui une fois qu'on aura enlevé l'objet de l'inventaire, retirera les bonus de stat à GameControl.player
    public override void interact(PhotonView unPhotonView)
    {
        //permet d'inclure le code de la fonction du même nom de la classe dont on hérite, ici "PickUpItems"
        base.interact(unPhotonView);
        
        //Inventory2.inventory2.AddItem(this);


    }

    public virtual void Use()
    {
        Debug.Log("j'utilise mon objet");
        
    }
    
    
}
