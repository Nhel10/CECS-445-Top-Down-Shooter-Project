using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthManager : MonoBehaviour
{
    public float maxHealth;
    public float currentHealth;
    public SimpleHealthBar healthBar;
    public GameObject gameover;

    // Use this for initialization
    void Start()
    {
        currentHealth = maxHealth;
        healthBar.UpdateBar( currentHealth, maxHealth );
        gameover.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (currentHealth <= 0)
        {
            Destroy(gameObject);
            gameover.SetActive(true);
        }
    }

    public void GetHurt(float damage)
    {
        currentHealth -= damage;
        healthBar.UpdateBar( currentHealth, maxHealth );
    }
    public float getHP()
    {
        return currentHealth;
    }
}
