using UnityEngine;
using System.Collections;


public class HealthManager : MonoBehaviour
{
    public float health;
    private float currentHealth;
    public int scoreValue;
   // public GameObject gameover;


    // Use this for initialization
    void Start()
    {
        currentHealth = health;
        //gameover.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (currentHealth <= 0)
        {
            //SoundManagerScript.PlaySound("PD");
          FindObjectOfType<GameSession>().AddToScore(scoreValue);
            //gameover.SetActive(true);
            Destroy(gameObject);
        }
    }

    public void GetHurt(float damage)
    {
        currentHealth -= damage;
    }
}
