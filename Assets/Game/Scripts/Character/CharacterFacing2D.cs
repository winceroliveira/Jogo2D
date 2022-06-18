using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class CharacterFacing2D : MonoBehaviour
{
    SpriteRenderer spriteRenderer;
    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateFacing(Vector2 movimentInput)
    {

        if (movimentInput.x > 0)
        {
            spriteRenderer.flipX = false;
        }
        else if (movimentInput.x < 0)
        {
            spriteRenderer.flipX = true;
        }
    }
}
