using UnityEngine;

public class ChangeSpriteOnAnimationEnd : MonoBehaviour
{
    public Sprite newSprite; 

    private SpriteRenderer spriteRenderer; 
    private bool animationCompleted = false; 

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void LateUpdate()
    {
        if (animationCompleted && spriteRenderer.sprite != newSprite)
        {
            spriteRenderer.sprite = newSprite;
        }
    }

    public void OnAnimationEnd()
    {
        animationCompleted = true;
    }
}
