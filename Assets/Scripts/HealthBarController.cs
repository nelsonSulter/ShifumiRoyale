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
        int index;
        index = PlayerManagement.Instance.listeInfoJoueurs.FindIndex(x => x.photonPlayerJoueur == PhotonNetwork.player);
        if (index != -1)
        {
            
            
            
            // La vie max est égale à la vie max du joueur que l'on va chercher dans GameControl.player
            // La barre de vie dépend des pv courants du joueur
            healthBar.value = PlayerManagement.Instance.listeInfoJoueurs[index].health;
            healthBar.maxValue = PlayerManagement.Instance.listeInfoJoueurs[index].maxHealth;

            // toutes les autres stats du HUD
            stoneDamage.text = "Stone Damage: " + PlayerManagement.Instance.listeInfoJoueurs[index].damageStone.ToString();
            scissorDamage.text = "Scissor Damage: " + PlayerManagement.Instance.listeInfoJoueurs[index].damageScissor.ToString();
            paperDamage.text = "Paper Damage: " + PlayerManagement.Instance.listeInfoJoueurs[index].damagePaper.ToString();
            movementSpeed.text = "Movement Speed: " +
                                 PlayerManagement.Instance.listeInfoJoueurs[index].movementSpeed.ToString();
            maxHealth.text = PlayerManagement.Instance.listeInfoJoueurs[index].health.ToString();
            currentHealth.text = PlayerManagement.Instance.listeInfoJoueurs[index].maxHealth.ToString();
        }

        else
        {
            print("l'HUD marche pas");
        }
    }
}
