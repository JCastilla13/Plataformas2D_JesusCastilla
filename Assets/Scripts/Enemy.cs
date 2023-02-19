using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject Target;
    public float speed;
    private SpriteRenderer spriteRenderer;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        if (Target != null)
        {
            Vector2 direction = Target.transform.position - transform.position;
            transform.position = Vector2.MoveTowards(transform.position, Target.transform.position, speed * Time.deltaTime);

            if (direction.x > 0)
            {
                spriteRenderer.flipX = false; 
            }
            else if (direction.x < 0)
            {
                spriteRenderer.flipX = true; 
            }
        }
    }
}
