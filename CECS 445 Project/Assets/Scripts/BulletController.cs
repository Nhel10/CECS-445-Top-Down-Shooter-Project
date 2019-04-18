using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    public float speed;

    private Rigidbody2D bullet;

    public float damage;

    public bool enemyBullet;

    public bool playerBullet;

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
        if(playerBullet){
          if (collision != null &&
          (collision.gameObject.tag == "Enemy" || collision.gameObject.tag == "Asteroid"))
          {
              Debug.Log("Enemy was hit ");
              // remove 'damage' amount of life to the enemy
              collision.gameObject.GetComponent<HealthManager>().GetHurt(damage);
              Destroy(gameObject); // Destroys bullet object
          }
        }
        if(enemyBullet){
          //Debug.Log("This shit passes through the player");
          if (collision != null && (collision.gameObject.tag == "Player")){
              Debug.Log("Player was hit ");
              collision.gameObject.GetComponent<PlayerHealthManager>().GetHurt(damage);
              Destroy(gameObject);
          }
        }

        if (collision != null && (collision.gameObject.tag == "Bullet")){
            Debug.Log("Bullets Collide ");
            Destroy(gameObject);
        }


        // check if the 2D colliding object is an Enemy

    }
}
