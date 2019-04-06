using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float speed;
    public float rotateSpeed;

    public GunController weapon;
    public ForceFieldController forceField;

    private Rigidbody2D player;
    private Vector2 movement;
    private float rotation;

    //customized key input for control
    public KeyCode forward;
    public KeyCode backward;
    public KeyCode left;
    public KeyCode right;
    public KeyCode shoot;
    public KeyCode shield;
    public KeyCode toggle;

    public double currencyAmount; // for the test

    public GameObject ScoreboardController;

    // Start is called before the first frame update
    void Start()
    {
        this.player = GetComponent<Rigidbody2D>();
        ScoreboardController.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

        movement = new Vector2(0, Input.GetKey(forward) ? 1 : Input.GetKey(backward) ? -1 : 0) * speed;
        // get rotation of player
        rotation = (Input.GetKey(left) ? 1 : (Input.GetKey(right) ? -1 : 0)) * rotateSpeed;

        if (Input.GetKeyDown(shoot))
        {
            weapon.isFiring = true;
        } else if (Input.GetKeyUp(shoot))
        {
            weapon.isFiring = false;
        }

        if (Input.GetKeyDown(shield))
        {
            forceField.isDeployed = true;
        } else if (Input.GetKeyUp(shield))
        {
            forceField.isDeployed = false;
        }
        if (Input.GetKeyDown(toggle))
        {
            ScoreboardController.SetActive(true);
        }
        if (Input.GetKeyUp(toggle))
        {
            ScoreboardController.SetActive(false);
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
                //collision.gameObject.GetComponent<PlayerHealthManager>().GetHurt(5); // need to define amount of damage dealth
                this.GetComponent<PlayerHealthManager>().GetHurt(5); // need to define amount of damage taken
            }
        }
    }

    public void pickUpCurrency(int currencyAmount)
    {
        this.currencyAmount += currencyAmount;
    }
}
