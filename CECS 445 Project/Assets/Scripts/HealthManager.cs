using UnityEngine;
using System.Collections;


public class HealthManager : MonoBehaviour
{
    public float health;
    private float currentHealth;
  


    // Use this for initialization
    void Start()
    {
        currentHealth = health;
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
    }
}
