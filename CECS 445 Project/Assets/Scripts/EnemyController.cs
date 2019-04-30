using UnityEngine;
using System.Collections;

public class EnemyController : MonoBehaviour
{
    const int basicAmount = 10;
    private float earning = 1.0f;

    private bool quit = false;

    public int level;
    public float speed;

    public CurrencyController currency;

    private Rigidbody2D enemy;
    // Use this for initialization
    void Start()
    {
        this.enemy = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector2(0, 1) * speed * Time.deltaTime);
    }

    void OnApplicationQuit()
    {
        quit = true;
    }

    private void OnDestroy()
    {
        if (quit)
        {
            return;
        }
        SoundManagerScript.PlaySound("ED");
        CurrencyController newLoot = Instantiate(currency, gameObject.transform.position, gameObject.transform.rotation) as CurrencyController;
        float mult = Random.Range(level / 2f, level * earning);
        newLoot.SetCurrencyAmount(mult * basicAmount);
    }
}
