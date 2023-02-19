using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundDetector : MonoBehaviour
{
    public bool grounded;
    public string tagPlatform = "PlataformaMovil";

    private Transform parentPlatform;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(tagPlatform))
        {
            parentPlatform = collision.transform;
            transform.SetParent(parentPlatform, true);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        grounded = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        grounded = false;

        if (collision.transform == parentPlatform)
        {
            transform.SetParent(null, true);
            parentPlatform = null;
        }
    }
}
