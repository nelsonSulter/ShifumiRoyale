using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarController : MonoBehaviour
{
    [SerializeField]
    private Slider healthBar;
    
    [SerializeField]
    private Text stoneDamage;
    
    [SerializeField]
    private Text scissorDamage;
    
    [SerializeField]
    private Text paperDamage;
    
    [SerializeField]
    private Text movementSpeed;
    
    [SerializeField]
    private Text maxHealth;
    
    [SerializeField]
    private Text currentHealth;
    
    
    // Start is called before the first frame update
    void Awake()
    {
        healthBar = GetComponent<Slider>();
    }

    // Update is called once per frame
    void Update()
    {
        // La vie max est égale à la vie max du joueur que l'on va chercher dans GameControl.player
        // La barre de vie dépend des pv courants du joueur
        healthBar.value = GameControl.player.health;
        healthBar.maxValue = GameControl.player.maxHealth;
        
        // toutes les autres stats du HUD
        stoneDamage.text = "Stone Damage: " + GameControl.player.damageStone.ToString();
        scissorDamage.text ="Scissor Damage: " + GameControl.player.damageScissor.ToString();
        paperDamage.text ="Paper Damage: " + GameControl.player.damagePaper.ToString();
        movementSpeed.text ="Movement Speed: " + GameControl.player.movementSpeed.ToString();
        maxHealth.text = GameControl.player.maxHealth.ToString();
        currentHealth.text = GameControl.player.health.ToString();
    }
}
