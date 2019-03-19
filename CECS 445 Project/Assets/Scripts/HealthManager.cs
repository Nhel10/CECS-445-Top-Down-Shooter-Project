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
            if (gameObject.tag == "Enemy")
            {
                EnemyController enemy = gameObject.GetComponent<EnemyController>();
                CurrencyController newLoot = Instantiate(enemy.currency, gameObject.transform.position, gameObject.transform.rotation) as CurrencyController;
                float mult = Random.Range(enemy.level / 2f, enemy.level * enemy.GetEarning());
                newLoot.SetCurrencyAmount(mult * enemy.GetBasicAmount());
            }
            Destroy(gameObject);
        }
    }

    public void GetHurt(float damage)
    {
        currentHealth -= damage;
    }
}
