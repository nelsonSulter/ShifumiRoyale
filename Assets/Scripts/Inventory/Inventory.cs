using UnityEngine;
using UnityEngine.UI;
public class Inventory : MonoBehaviour
{
    public GameObject playerGameObject;
    

    
    //Un tableau contient les instance de classe Item et l'autre contient les images
    public Image[] itemImages = new Image[numItemSlots];
    public Gears[] items = new Gears[numItemSlots];
    
    // Le nombre de slot est public pour qu'on puisse y acceder dans notre script inventoryEditor
    public const int numItemSlots = 4;
    
    
    void Awake()
    {
       

        playerGameObject = GetComponent<GameObject>();
  
                
        
        
        //On recherche le playerGameObject qui correspond à celui du joueur courant pour ensuite utiliser sa position quand il va drop un objet
        //Pour chaque playerGameObject sur la carte, cherche celui dont je suis le propriétaire
        foreach (GameObject go in GameObject.FindGameObjectsWithTag("ItemSlot")) {
            {
                
                Debug.Log(go.name);
                switch (go.name)
                {
                    case "ItemImage0":
                        itemImages[0] = go.GetComponent<Image>();
                        break;
                    
                    case "ItemImage1":
                        itemImages[1] = go.GetComponent<Image>();
                        break;
                    
                    case "ItemImage2":
                        itemImages[2] = go.GetComponent<Image>();
                        break;
                    
                    case "ItemImage3":
                        itemImages[3] = go.GetComponent<Image>();
                        break;
                }
            }
        }
        
    }
    
    public void AddItem(Gears itemToAdd)
    {
        for (int i = 0; i < items.Length; i++)
        {
            if (items[i] == null)
            {
                items[i] = itemToAdd;
              
                itemImages[i].sprite = itemToAdd.image;
                
                //On avait mis ce parametre à faux de manière à ce qu'aucune image ne soit montrée dans le cas ou pas d'image dans cette case
                //Maintenant qu'on a un objet dedans, on le remet à vrai pour afficher l'image de l'objet
                //Par defaut si la case est vide et enable a vrai, il y aura un carré blanc et ce n'est pas ce qu'on veut, 
                //On veut que dans le cas où la case est vide, il y ai le background de l'item slot et pas ce carré blanc
                itemImages[i].enabled = true;
                
                return;
                
                
            }
        }
    }
    public void RemoveItem (Gears itemToRemove)
    {
        for (int i = 0; i < items.Length; i++)
        {
            if (items[i] == itemToRemove)
            {
                items[i] = null;
                itemImages[i].sprite = null;
                //On remet la parametre à faux pour ne pas avoir le carré blanc une fois que l'obet a été enlevé de l'inventaire
                itemImages[i].enabled = false;
                return;
            }
        }
    }
    
    
    //surcharge de la fonction RemoveItem, elle a une signature différente et permet de supprimer un objet directement à l'index que l'on choisit
    public void RemoveItem (int slotNumber)
    {
        
                Debug.Log("on retire l'objet");
                GetComponent<Inventory>().items[slotNumber].gameObject.SetActive(true);
                GetComponent<Inventory>().items[slotNumber].gameObject.transform.position = playerGameObject.transform.position;
                GetComponent<Inventory>().items[slotNumber].gameObject.GetComponent<Gears>().drop();
        
                items[slotNumber] = null;
                itemImages[slotNumber].sprite = null;
                //On remet la parametre à faux pour ne pas avoir le carré blanc une fois que l'obet a été enlevé de l'inventaire
                itemImages[slotNumber].enabled = false;
                Debug.Log("La fonction remove est utilisée, on arrive à la fin");
    }
        
    
}