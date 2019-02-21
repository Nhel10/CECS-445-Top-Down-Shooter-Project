using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    public float speed;

    private Rigidbody2D bullet;

    public float damage;

    // Start is called before the first frame update
    void Start()
    {
        bullet = GetComponent<Rigidbody2D>();
        // prevent bullet from colliding with shield
        Physics2D.IgnoreCollision(
            gameObject.transform.GetComponent<Collider2D>(),
            GetComponentInParent<GunController>().GetComponentInParent<PlayerController>().GetComponentInChildren<ForceFieldController>().shield.transform.GetComponent<Collider2D>()
           );

        //prevent bullet from colliding with another one
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
        // check if the 2D colliding object is an Enemy
        if (collision != null && 
        (collision.gameObject.tag == "Enemy" || collision.gameObject.tag == "Asteroid"))
        {
            // remove 'damage' amount of life to the enemy
            collision.gameObject.GetComponent<HealthManager>().GetHurt(damage);
            Destroy(gameObject);
        }
    }
}
