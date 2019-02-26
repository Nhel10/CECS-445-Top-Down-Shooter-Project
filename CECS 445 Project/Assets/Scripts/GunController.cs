using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour
{
    public bool isFiring;

    public BulletController bullet;

    public float speed;
    public float timeBetweenShot;
    private float shotCounter = 0;

    public Transform firePoint;

    // Start is called before the first frame update
    void Start()
    {   
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isFiring)
        {
            shotCounter -= Time.deltaTime;
            if (shotCounter <= 0)
            {
                shotCounter = timeBetweenShot;
                BulletController newBullet = Instantiate(bullet, firePoint.position, firePoint.rotation) as BulletController;

                // get the collider from the shield and the created bullet
                Collider2D bulletCollider = newBullet.gameObject.transform.GetComponent<Collider2D>();
                Collider2D shieldCollider = GetComponentInParent<PlayerController>().GetComponentInChildren<ForceFieldController>().shield.gameObject.transform.GetComponent<Collider2D>();
                // deactivate collision between both collider
                Physics2D.IgnoreCollision(bulletCollider, shieldCollider);

                //try ignore collision between two bullets

                newBullet.speed = speed;
            }
        }
        else
        {
            shotCounter = 0;
        }
    }
}
