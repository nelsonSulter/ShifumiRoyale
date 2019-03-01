using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gears : PickUpItems
{
    // Cette Classe concerne tous les objets de type équipement. Elle hérite de PickUpItem
    //elle gagne une fonction bonus pour appliquer les bonus à GameControl.player une fois l'objet équipé
    // et une fonction drop, qui une fois qu'on aura enlevé l'objet de l'inventaire, retirera les bonus de stat à GameControl.player
    public override void interact()
    {
        //permet d'inclure le code de la fonction du même nom de la classe dont on hérite, ici "PickUpItems"
        base.interact();
        
        Inventory.inventory.AddItem(this);
        bonus();


    }

    public virtual void bonus()
    {
        Debug.Log("j'applique un bonus");
    }
    
    public virtual void drop()
    {
        Debug.Log("On m'a jeté, le joueur ne profite plus de mon bonus.");
    }
}
