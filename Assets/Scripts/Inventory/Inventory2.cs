using UnityEngine;
using UnityEngine.UI;
public class Inventory2 : MonoBehaviour
{
    
    public static Inventory2 inventory2;
    
    //Un tableau contient les instance de classe Item et l'autre contient les images
    public Image[] itemImages = new Image[numItemSlots];
    public Consumable[] items = new Consumable[numItemSlots];
    
    // Le nombre de slot est public pour qu'on puisse y acceder dans notre script inventoryEditor
    public const int numItemSlots = 4;
    
    
    void Awake()
    {
        // si "inventory" n'a pas encore été créé alors "inventory" = this et il sera conservé de scène en scène
        if (inventory2 == null)
        {
            //permet de conserver l'objet quand on passe de chaine en chaines, sans le détruire
            DontDestroyOnLoad(gameObject);
            inventory2 = this;
            
        }
        
        //si un objet "inventory" a déjà été créé avant celui là alors on le conserve et on détruit celui là
        else
        {
            if (inventory2 != this)
            {
                Destroy(gameObject);
            }
        }
        
    }
    
    public void AddItem(Consumable itemToAdd)
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
    public void useItem (Consumable itemToRemove)
    {
        for (int i = 0; i < items.Length; i++)
        {
            if (items[i] == itemToRemove)
            {
                items[i] = null;
                itemImages[i].sprite = null;
                //On remet la parametre à faux pour ne pas avoir le carré blanc une fois que l'obet a été enlevé de l'inventaire
                itemImages[i].enabled = false;
                Destroy(itemToRemove);
                return;
            }
        }
    }
    
    
    //surcharge de la fonction RemoveItem, elle a une signature différente et permet de supprimer un objet directement à l'index que l'on choisit
    public void RemoveItem (int slotNumber)
    {
                Debug.Log("on retire l'objet");
                Inventory.inventory.items[slotNumber].gameObject.SetActive(true);
                Inventory.inventory.items[slotNumber].gameObject.transform.position = GameControl.player.playerModel.transform.position;
        
                items[slotNumber] = null;
                itemImages[slotNumber].sprite = null;
                //On remet la parametre à faux pour ne pas avoir le carré blanc une fois que l'obet a été enlevé de l'inventaire
                itemImages[slotNumber].enabled = false;
                return;
                
    }
        
    
}