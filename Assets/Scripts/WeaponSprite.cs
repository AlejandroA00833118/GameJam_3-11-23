using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSprite : MonoBehaviour
{
    public Sprite[] sprites;
    
    public void ChangeSprite(int index) {
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        Sprite newSprite = sprites[index];

        if (spriteRenderer != null && newSprite != null)
        {
            spriteRenderer.sprite = newSprite;
        }
    }
}
