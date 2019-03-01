using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    
    //C'est la classe mère dont toutes les classes concernant les choses avec lesquelles on peut interragir dans le jeu vont hériter
    //Grace à l'héritage on va appeler tous nos objet de la même manière et toujours utiliser cette fonction "interact"
    //Elle aura des fonctions différente en fonction de la classe fille, ça simplifie le code
    //Pas besoin de se soucier de l'objet avec lequel on est confronté, ce sont tous des "Interactable" !
    public virtual void interact()
    {
        
        Debug.Log("interact with an interactable object");
        
    }
}
