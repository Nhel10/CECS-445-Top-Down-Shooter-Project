using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Float : MonoBehaviour
{
    public float speed = 3f;
    public RigidBody2D asteroid;

    //will be executed once at script start
    void Start()
    {
        asteroid = GetComponent<Rigidbody2D>();
        asteroid.velocity = speed * (new Vector3(0, -1, 0));
    }

    //will be executed if gameobject is not rendered anymore on screen 
    void Destroy()
    {
        //delete gameobject from scene
        Destroy(gameObject);
    }
    // Update is called once per frame
    void Update()
    {
        transform.Translate(-Input.GetAxis("Vertical") * speed * Time.deltaTime, 0, 0);
    }

}
