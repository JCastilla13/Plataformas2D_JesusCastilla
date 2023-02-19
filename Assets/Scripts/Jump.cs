using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour
{
    Rigidbody2D rb;
    public float force;
    GroundDetector ground;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        ground = GetComponent<GroundDetector>();
    }

    void Update()
    {
        if (!PauseMenu.instance.isPaused)
            if (ground.grounded == true && Input.GetButtonDown("Jump"))
            {
                rb.AddForce(Vector2.up * force);
            }
    }
}
