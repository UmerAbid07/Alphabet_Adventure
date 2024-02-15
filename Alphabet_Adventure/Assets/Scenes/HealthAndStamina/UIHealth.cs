using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIHealth : MonoBehaviour
{
    private float health;
    public float maxHealth = 100;
    public Image frontHealthBar;
    public Image backHealthBar;
    public Image frontXp;
    public Image backXp;
    private float stamina;
    public float maxStamina=100f;
    public float lerpTimer;
    private PlayerController playerController;
    // Start is called before the first frame update
    void Start()
    {
        playerController=GetComponentInParent<PlayerController>();
        health = maxHealth;
    }
    

    // Update is called once per frame
    void Update()
    {
        health = Mathf.Clamp(health, 0, maxHealth);
        health=playerController.health;
        stamina=playerController.maxStamina;
        staminaXp();
        damageHealthUI();
    }

    void damageHealthUI()
    {
        //Debug.Log("Health: " + health);
        float fillF = frontHealthBar.fillAmount;
        float fillB = backHealthBar.fillAmount;
        float hFraction = health / maxHealth;
        if(fillB>hFraction)
        {
            frontHealthBar.fillAmount=hFraction;
            backHealthBar.color=Color.red;
            lerpTimer += Time.deltaTime;
            float percentComplete = lerpTimer / 2;
            percentComplete *= percentComplete;
            backHealthBar.fillAmount=Mathf.Lerp(fillB,hFraction,percentComplete);

        }
        if(fillF<hFraction)
        {
            backHealthBar.color = Color.green;
            backHealthBar.fillAmount=hFraction;
            lerpTimer += Time.deltaTime;
            float percentComplete = lerpTimer / 2;
            percentComplete = percentComplete * percentComplete;
            frontHealthBar.fillAmount=Mathf.Lerp(fillF,backHealthBar.fillAmount,percentComplete);
        }
            
    }
    void staminaXp()
    {
        //Debug.Log("Stamina: " + stamina);
        float fillF = frontXp.fillAmount;
        float fillB = backXp.fillAmount;
        float hFraction = stamina / maxStamina;
        if (fillB > hFraction)
        {
            frontXp.fillAmount = hFraction;
            //backHealthBar.color = Color.red;
            lerpTimer += Time.deltaTime;
            float percentComplete = lerpTimer / 2;
            percentComplete *= percentComplete;
            backXp.fillAmount = Mathf.Lerp(fillB, hFraction, percentComplete);

        }
        if (fillF < hFraction)
        {
            backXp.fillAmount = hFraction;
            lerpTimer += Time.deltaTime;
            float percentComplete = lerpTimer / 2;
            percentComplete = percentComplete * percentComplete;
            frontXp.fillAmount = Mathf.Lerp(fillF, backXp.fillAmount, percentComplete);
        }

    }
    void heal(float amount)
    {
        health += amount;
        stamina += amount;
        lerpTimer = 0;
    }
    
    void takeDamage(float damage)
    {
        health -= damage;
        stamina -= damage;
        lerpTimer = 0;
    }
}
