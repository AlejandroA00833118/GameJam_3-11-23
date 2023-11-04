using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSprite : MonoBehaviour
{
    public Sprite[] sprites;

    void Start() {
        ChangeSprite(sprites[1]);
    }
    
    void ChangeSprite(Sprite newSprite)
    {
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        
        if (spriteRenderer != null && newSprite != null)
        {
            spriteRenderer.sprite = newSprite;
        }
    }
}
