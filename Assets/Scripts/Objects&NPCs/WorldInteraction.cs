using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.UIElements;
using Debug = System.Diagnostics.Debug;

public class WorldInteraction : MonoBehaviour
{
    

    
    // Si dans la zone d'interaction du joueur il se trouve un objet "interactable" alors si il clique, la fonction getInteraction se lance
    void OnTriggerStay(Collider other)
    {
        
        if (other.gameObject.tag == "Interactable") {
            //Recupère l'input du joueur sur le clic gauche, et vérifie si notre clique est fait sur un élément UI de Unity
            //Si c'est le cas il n'enverra pas de raycast sur la map du jeu, c'est à dire que si un élément était caché derrière un bouton de l'UI
            //Uniy s'arrêtera au bouton, sans cette condition le personnage aurait aussi tenté de ramassé l'objet caché derrière l'interface UI
            if (Input.GetMouseButtonDown(0) && !UnityEngine.EventSystems.EventSystem.current.IsPointerOverGameObject())
            {
                getInteraction();
            }

        }
    }
    

    

    void getInteraction()
    {
        
        
        //On fait un jet de rayon à l'endroit où le joueur à cliqué 
        Ray interactionRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        
        //La variable qui va servire à récupérer les infos à propos de l'endroit où on a cliqué
        RaycastHit interactionInfo;
        
        //on vérifie si le rayon interactionRay a touché quelque chose, si oui rentre l'info dans interactionInfo
        if (Physics.Raycast(interactionRay, out interactionInfo, Mathf.Infinity))
        {
            GameObject interactedObject = interactionInfo.collider.gameObject;
            //On vérifie si c'est un objet avec lequel on peut interagir
            if (interactedObject.tag == "Interactable")
            {
                interactedObject.GetComponent<Interactable>().interact();
            }
        }

        
    }
    
}
