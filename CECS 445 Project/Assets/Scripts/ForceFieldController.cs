using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForceFieldController : MonoBehaviour
{

    public bool isDeployed;

    public float longevity;

    public ShieldManager shield;

    // Start is called before the first frame update
    void Start()
    {
        Transform shipLocation = GetComponentInParent<PlayerController>().gameObject.transform;

        shield = Instantiate(shield, shipLocation.position, shipLocation.rotation) as ShieldManager;
        shield.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            isDeployed = true;
        }
        else if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            isDeployed = false;
        }

        if (isDeployed)
        {
            // set the position of the shield in the position of the ship (centered shield/deflector)
            Vector3 newpos = GetComponentInParent<PlayerController>().gameObject.transform.position;
            shield.gameObject.transform.position = newpos;

            // prevent shield from colliding with the ship 
            Collider2D shipCollider = GetComponentInParent<PlayerController>().gameObject.transform.GetComponent<Collider2D>();
            Collider2D forceFieldCollider = shield.gameObject.transform.GetComponent<Collider2D>();
                       
            Physics2D.IgnoreCollision(shipCollider, forceFieldCollider);

            // activing the shield once physics w/ ship is disabled
            shield.gameObject.SetActive(true);
            longevity -= Time.deltaTime;
            if (longevity <= 0)
            {
                Destroy(shield.gameObject);
                Destroy(gameObject);
            }
        }
        else
        {
            // when not using it, deactivate the shield (dont destroy it)
            shield.gameObject.SetActive(false);
        }
    }
}
