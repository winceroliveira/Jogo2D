using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Platformer2D.Character;

[RequireComponent(typeof(CharacterMovement2D))]
[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(PlayerInput))]
public class PlayerController : MonoBehaviour
{
    CharacterMovement2D playerMovement;
    SpriteRenderer spriteRenderer;
    PlayerInput playerInput;

    public Sprite crouchedSprit;
    public Sprite idleSprit;
    // Start is called before the first frame update
    void Start()
    {
        playerMovement = GetComponent<CharacterMovement2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        playerInput = GetComponent<PlayerInput>();
    }

    // Update is called once per frame
    void Update()
    {
        //Movimentação
        Vector2 movimentInput = playerInput.GetMovementInput();
        playerMovement.ProcessMovementInput(movimentInput);

        if (movimentInput.x > 0)
        {
            spriteRenderer.flipX = false;
        }
        else if (movimentInput.x < 0)
        {
            spriteRenderer.flipX = true;
        }

        //Pulo
        if (playerInput.IsJumpButtonDown())
        {
            playerMovement.Jump();
        }
        if (playerInput.IsJumpButtonHeld() == false)
        {
            playerMovement.UpdateJumpAbort();
        }

        //AGACHAR
        if (playerInput.IsCrouchButtonDown())
        {
            playerMovement.Crouch();

            //TODO: Remover quando adicionar animação
            spriteRenderer.sprite = crouchedSprit;
        }
        //LEVANTAR
        else if (playerInput.IsCrouchButtonUp())
        {

            playerMovement.UnCrouch();
            //TODO: Remover quando adicionar animação
            spriteRenderer.sprite = idleSprit;
        }
    }
}
