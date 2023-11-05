using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangePropSprite : MonoBehaviour
{
    public Sprite[] sprites;
    private int randomIndex;

    public void Start() {
        randomIndex = Random.Range(0, sprites.Length);
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = sprites[randomIndex];
    }
}
