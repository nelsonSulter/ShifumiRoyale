using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IwaRing : Gears
{
    
    // C'est notre premier anneau ! 
    // Il augmente de 10 les dégats de pierre
    //Pour se faire on a réécrit les fonctions bonus et drop que l'on a hérité de la classe Gears !
    public override void interact()
    {
        base.interact();
    }

    public override void bonus()
    {
        GameControl.player.damageStone += 10;
    }
    
    public override void drop()
    {
        GameControl.player.damageStone -= 10;
    }
}
