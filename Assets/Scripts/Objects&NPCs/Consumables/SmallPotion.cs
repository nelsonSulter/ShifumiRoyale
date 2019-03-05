using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmallPotion : Consumable
{
    // Start is called before the first frame update
    public override void interact()
    {
        //permet d'inclure le code de la fonction du même nom de la classe dont on hérite, ici "PickUpItems"
        base.interact();


    }

    public override void Use()
    {
        if (GameControl.player.health + 30 > GameControl.player.maxHealth)
        {
            GameControl.player.health = GameControl.player.maxHealth;
        }

        else
        {
            GameControl.player.health += 30;
        }
        
        Inventory2.inventory2.useItem(this);
        

    }
    
}
