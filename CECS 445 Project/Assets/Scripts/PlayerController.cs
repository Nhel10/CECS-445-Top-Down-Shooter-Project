using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float speed;
    public float rotateSpeed;

    public GunController weapon;
    //public ForceFieldController shield;

    private Rigidbody2D player;
    private Vector2 movement;
    private float rotation;

    public double currencyAmount; // for the test

    // Start is called before the first frame update
    void Start()
    {
        this.player = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // improve it ? readability

        // get movement of player
        movement =  new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")) * speed;
        // get rotation of player
        rotation = (Input.GetKey(KeyCode.Q) ? 1 : (Input.GetKey(KeyCode.E) ? -1 : 0)) * rotateSpeed;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            weapon.isFiring = true;
        }
        else if (Input.GetKeyUp(KeyCode.Space))
        {
            weapon.isFiring = false;
        }
    }

    private void FixedUpdate()
    {
        // transorm position and rotation of player according to inputs & speed
        transform.Translate(movement * Time.deltaTime);
        transform.Rotate(0, 0, rotation);

        // prevent player from reachign outer map
        Vector3 pos = Camera.main.WorldToViewportPoint(transform.position);
        pos.x = Mathf.Clamp01(pos.x);
        pos.y = Mathf.Clamp01(pos.y);
        transform.position = Camera.main.ViewportToWorldPoint(pos);

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision != null)
        {
            if (collision.gameObject.tag == "Asteroid" || collision.gameObject.tag == "Enemy")
            {
                collision.gameObject.GetComponent<HealthManager>().GetHurt(5); // need to define amount of damage dealth
                this.GetComponent<HealthManager>().GetHurt(5); // need to define amount of damage taken
            }
        }
    }

    public void pickUpCurrency(int currencyAmount)
    {
        this.currencyAmount += currencyAmount;
    }
}
    