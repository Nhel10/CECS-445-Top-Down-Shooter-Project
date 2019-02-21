using UnityEngine;
using System.Collections;

public class ShieldManager : MonoBehaviour
{
    private Rigidbody2D shield;

    // Use this for initialization
    void Start()
    {
        shield = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
    }
}
