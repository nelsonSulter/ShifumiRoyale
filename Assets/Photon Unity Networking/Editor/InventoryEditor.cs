using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

//On crée un editor, les MonoBehaviour sont fait pour être attachés à des games objects, ce n'est pas ce qu'on fait ici
//On veut modifier l'affichage de notre inventaire dans l'inspector

// le CustomEditor() permet de spécifié sur quel type d'objet on va travailler avec cet editor
//Ici on travail sur notre inventaire
[CustomEditor(typeof(Inventory))]
public class InventoryEditor : Editor
{
    
    private SerializedProperty itemImagesProperty;
    private SerializedProperty itemsProperty;
    
    //On utilise la constante de notre classe Inventory pour determiner la taille du tableau de bool
    //Ce tableau va faire en sorte que chaque itemslot dans l'inspector puisse être ouvert et ou fermé à la manière d'une arborescence
    private bool[] showItemSlots = new bool[Inventory.numItemSlots];
    
    //Ce sont les deux constante que l'ont va utilisé pour indiquer à Unity vers quels champs de notre classe inventaire doivent pointer nos property
    private const string inventoryPropItemImagesName = "itemImages";
    private const string inventoryPropItemsName = "items";

    
    //C'est ici que l'on précise vers quels champs de notre classe inventaire doivent pointer nos property
    private void OnEnable()
    {
        itemImagesProperty = serializedObject.FindProperty(inventoryPropItemImagesName);
        itemsProperty = serializedObject.FindProperty(inventoryPropItemsName);
    }

    public override void OnInspectorGUI()
    {
        //Permet de mettre à jour les information de notre serialized objet par rapport à l'inventory pour que l'on ai la même chose des deux coté
        serializedObject.Update();
        
        for (int i = 0; i < Inventory.numItemSlots; i++)
        {
            itemSlotGUI(i);
        }

        //Applique les changement que l'on a fait depuis notre serializedObject à notre inventaire
        serializedObject.ApplyModifiedProperties();

    }

    private void itemSlotGUI(int index)
    {
        
        //Affiche tous ce qui se trouve dans un itemslot s'affiche verticalement dans l'inspecteur et dans des boites.
        EditorGUILayout.BeginVertical(GUI.skin.box);

        EditorGUI.indentLevel++;
        
        showItemSlots[index] = EditorGUILayout.Foldout(showItemSlots[index], "Item slot " + index);
        
        //Si dans la case "index" de showItemSlots on a true, alors on déplie et affiche l'item et l'itemimage qui correspond au slot numero "index"
        //dans l'inspecteur
        if (showItemSlots[index])
        {
            EditorGUILayout.PropertyField (itemImagesProperty.GetArrayElementAtIndex (index));
            EditorGUILayout.PropertyField (itemsProperty.GetArrayElementAtIndex (index));
        }
        
        EditorGUI.indentLevel--;
        
        EditorGUILayout.EndVertical();

    }
}
