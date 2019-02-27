﻿using UnityEngine;
using UnityEngine.UI;
public class Inventory : MonoBehaviour
{
    
    public static Inventory inventory;
    
    //Un tableau contient les instance de classe Item et l'autre contient les images
    public Image[] itemImages = new Image[numItemSlots];
    public Item[] items = new Item[numItemSlots];
    
    // Le nombre de slot est public pour qu'on puisse y acceder dans notre script inventoryEditor
    public const int numItemSlots = 4;
    
    
    void Awake()
    {
        // si "inventory" n'a pas encore été créé alors "inventory" = this et il sera conservé de scène en scène
        if (inventory == null)
        {
            //permet de conserver l'objet quand on passe de chaine en chaines, sans le détruire
            DontDestroyOnLoad(gameObject);
            inventory = this;
            
        }
        
        //si un objet "inventory" a déjà été créé avant celui là alors on le conserve et on détruit celui là
        else
        {
            if (inventory != this)
            {
                Destroy(gameObject);
            }
        }
        
    }
    
    public void AddItem(Item itemToAdd)
    {
        for (int i = 0; i < items.Length; i++)
        {
            if (items[i] == null)
            {
                items[i] = itemToAdd;
                itemImages[i].sprite = itemToAdd.sprite;
                
                //On avait mis ce parametre à faux de manière à ce qu'aucune image ne soit montrée dans le cas ou pas d'image dans cette case
                //Maintenant qu'on a un objet dedans, on le remet à vrai pour afficher l'image de l'objet
                //Par defaut si la case est vide et enable a vrai, il y aura un carré blanc et ce n'est pas ce qu'on veut, 
                //On veut que dans le cas où la case est vide, il y ai le background de l'item slot et pas ce carré blanc
                itemImages[i].enabled = true;
                return;
            }
        }
    }
    public void RemoveItem (Item itemToRemove)
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
}