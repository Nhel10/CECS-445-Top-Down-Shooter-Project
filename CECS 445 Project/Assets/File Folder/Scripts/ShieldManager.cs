using UnityEngine;
using System.Collections;

public class ShieldManager : MonoBehaviour
{
    private Rigidbody2D shield;

    // Use this for initialization
    void Start()
    {
        shield = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision != null && (collision.gameObject.tag != "Player" || collision.gameObject.tag != "ForceField"))
        {
            collision.gameObject.GetComponent<HealthManager>().GetHurt(5); // need to define amount of damage dealth
        }
    }
}
