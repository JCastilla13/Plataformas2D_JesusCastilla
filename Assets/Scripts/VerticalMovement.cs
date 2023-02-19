using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VerticalMovement : MonoBehaviour
{
    public SpriteRenderer sr;
    public Animator anim;
    public GroundDetector ground;
    public float speed = 5;
    public Rigidbody2D rb2D;

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        ground = GetComponent<GroundDetector>();
        rb2D.gravityScale = 0;
    }

    void Update()
    {

    }

    private void FixedUpdate()
    {
        float vertical = Input.GetAxis("Vertical");
        transform.position += new Vector3(0, vertical * speed * Time.fixedDeltaTime, 0);

        anim.SetBool("Moving", vertical != 0);
        anim.SetBool("Grounded", ground.grounded);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "gravityMovement")
        {
            GetComponent<VerticalMovement>().enabled = true;
            GetComponent<Jump>().enabled = false;
        }
    }

    private void OnEnable()
    {
        rb2D.gravityScale = 0;
    }
}
