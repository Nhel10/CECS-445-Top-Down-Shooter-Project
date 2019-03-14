using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForceFieldController : MonoBehaviour
{

    public bool isDeployed;

    public float longevity;

    public ShieldManager shield;
    public Transform shieldCore;

    // Start is called before the first frame update
    void Start()
    {
        shield = Instantiate(shield, shieldCore.position, shieldCore.rotation) as ShieldManager;
        shield.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (isDeployed)
        {
            Vector3 newpos = GetComponentInParent<PlayerController>().gameObject.transform.position;
            shield.gameObject.transform.position = newpos;
            // prevent shield from colliding with the ship 
            Physics2D.IgnoreCollision(
                GetComponentInParent<PlayerController>().gameObject.transform.GetComponent<Collider2D>(),
                shield.gameObject.transform.GetComponent<Collider2D>()
                );

            shield.gameObject.SetActive(true);
            longevity -= Time.deltaTime;
            if (longevity <= 0)
            {
                Destroy(shield.gameObject);
            }
        }
        else
        {
            shield.gameObject.SetActive(false);
        }
    }
}
