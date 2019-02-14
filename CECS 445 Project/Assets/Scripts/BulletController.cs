using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    public float speed;

    private Rigidbody2D bullet;

    // Start is called before the first frame update
    void Start()
    {
        bullet = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // just move forward in the direction of the ship
        transform.Translate(new Vector2(0,1) * speed * Time.deltaTime);
    }

    // destroy bullet when reaching outer screen
    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

    // destroy bullet when colliding any 2D collider or rigidbogy
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
    }
}
