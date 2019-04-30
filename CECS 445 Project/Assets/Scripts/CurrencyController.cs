using UnityEngine;
using System.Collections;

public class CurrencyController : MonoBehaviour
{
    private int currencyAmount;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision != null && collision.tag == "Player")
        {
            SoundManagerScript.PlaySound("LP");
            collision.gameObject.GetComponent<PlayerController>().pickUpCurrency(currencyAmount);
            Destroy(gameObject);
        }
    }

    public void SetCurrencyAmount(float amount)
    {
        currencyAmount = Mathf.FloorToInt(amount);
    }
}
