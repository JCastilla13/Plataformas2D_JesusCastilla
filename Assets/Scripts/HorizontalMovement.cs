using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorizontalMovement : MonoBehaviour
{
    public SpriteRenderer sr;
    public Animator anim;
    public GroundDetector ground;
    public float speed = 5;
    public bool hit;
    public GameObject weaponVisible;
    public Rigidbody2D rb2D;


    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        ground = GetComponent<GroundDetector>();
        rb2D = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        anim.SetBool("Hit", hit);
    }

    private void FixedUpdate()
    {
        float horizontal = Input.GetAxis("Horizontal");
        transform.position += new Vector3(horizontal * speed * Time.fixedDeltaTime, 0, 0);
        if (horizontal > 0)
        {
            sr.flipX = false;
        }
        if (horizontal < 0)
        {
            sr.flipX = true;
        }
        anim.SetBool("Moving", horizontal != 0);
        anim.SetBool("Grounded", ground.grounded);

        if (weaponVisible != null)
        {
            weaponVisible.SetActive(false);
            if (hit = Input.GetMouseButton(0))
            {
                weaponVisible.SetActive(true);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "movementTrigger")
        {
            rb2D.gravityScale = 4; 
            GetComponent<VerticalMovement>().enabled = false;
            GetComponent<Jump>().enabled = true;

        }
    }
}
