using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public GameObject projectile;

    public Transform projectileSpawn;

    private float nextShot;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.anyKey && Time.time > nextShot)
        {
            Instantiate(projectile, projectileSpawn.position, projectileSpawn.rotation);
        }
	}
}