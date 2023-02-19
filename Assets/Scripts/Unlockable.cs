using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unlockable : MonoBehaviour
{
    public GameObject key;
    public GameObject door;
    public float distance = 3f; 
    public KeyCode actionKey = KeyCode.E; 
    public AudioClip doorOpenSound; 
    public Animator doorAnimator; 

    private bool hasKey = false;
    private bool doorOpened = false;
    private BoxCollider2D doorCollider;

    private void Start()
    {
        doorCollider = door.GetComponent<BoxCollider2D>();
    }

    private void Update()
    {
        if (!doorOpened)
        {
            if (Vector3.Distance(transform.position, key.transform.position) < distance)
            {
                if (Input.GetKeyDown(actionKey))
                {
                    hasKey = true;
                    key.SetActive(false);
                }
            }

            if (Vector3.Distance(transform.position, door.transform.position) < distance)
            {
                if (Input.GetKeyDown(actionKey) && hasKey)
                {
                    doorCollider.enabled = false;

                    doorAnimator.SetTrigger("Open");
                    AudioSource.PlayClipAtPoint(doorOpenSound, transform.position);

                    doorOpened = true;
                }
            }
        }
    }
}
