using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthManager : MonoBehaviour
{
    public float maxHealth;
    public float currentHealth;
    public SimpleHealthBar healthBar;


    // Use this for initialization
    void Start()
    {
        currentHealth = maxHealth;
        healthBar.UpdateBar(currentHealth,maxHealth);
    }

    // Update is called once per frame
    void Update()
    {
        if (currentHealth <= 0)
        {
            Destroy(gameObject);
        }
    }

    public void GetHurt(float damage)
    {
        currentHealth -= damage;
        healthBar.UpdateBar(currentHealth,maxHealth);
    }
}
