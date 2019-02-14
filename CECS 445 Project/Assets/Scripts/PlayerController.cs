using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float speed;
    public float rotateSpeed;

    public GunController weapon;

    private Rigidbody2D player;
    private Vector2 movement;
    private float rotation;

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

        //weapon.isFiring = Input.GetKeyDown(KeyCode.Space);
        //weapon.isFiring = !Input.GetKeyUp(KeyCode.Space);
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
}
    