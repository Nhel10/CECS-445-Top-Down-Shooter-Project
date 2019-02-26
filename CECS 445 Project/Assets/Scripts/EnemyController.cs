using UnityEngine;
using System.Collections;

public class EnemyController : MonoBehaviour
{
    const int basicAmount = 10;
    private float earning = 1.0f;

    public int level;

    public CurrencyController currency;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnDestroy()
    {
        CurrencyController newLoot = Instantiate(currency, gameObject.transform.position, gameObject.transform.rotation) as CurrencyController;
        float mult = Random.Range(level / 2f, level * earning);
        newLoot.SetCurrencyAmount(mult * basicAmount);
    }
}
