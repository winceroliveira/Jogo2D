using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Platformer2D.Character;

[RequireComponent(typeof(CharacterMovement2D))]
[RequireComponent(typeof(PlayerInput))]
[RequireComponent(typeof(CharacterFacing2D))]
public class PlayerController : MonoBehaviour
{
    CharacterMovement2D playerMovement;
    CharacterFacing2D characterFacing2D;
    PlayerInput playerInput;

    [Header ("Camera")]
    public Transform cameraTarget;
    [Range(0.0f,5.0f)]
    public float cameraTargetOffsetX = 2.0f;
    [Range(0.5f,50.0f)]
    public float cameraTargetFlipSpeed = 2.0f;
    [Range(0.0f,5.0f)]
    public float characterSpeedInfluence = 2.0f;

    // Start is called before the first frame update
    void Start()
    {
        playerMovement = GetComponent<CharacterMovement2D>();
        playerInput = GetComponent<PlayerInput>();
        characterFacing2D = GetComponent<CharacterFacing2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //Movimenta??o
        Vector2 movimentInput = playerInput.GetMovementInput();
        playerMovement.ProcessMovementInput(movimentInput);
        characterFacing2D.UpdateFacing(movimentInput);
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
        }
        //LEVANTAR
        else if (playerInput.IsCrouchButtonUp())
        {
            playerMovement.UnCrouch();
        }
    }

    private void FixedUpdate()
    {
        //controle do target da camera dependendo da dire??o do sprite e da velocidade do jogador
        bool isFacingRight = characterFacing2D.IsFacingRight();
        float targetOffsetX = isFacingRight ? cameraTargetOffsetX : -cameraTargetOffsetX;
        float currentOffsetX = Mathf.Lerp(cameraTarget.localPosition.x, targetOffsetX, Time.fixedDeltaTime * cameraTargetFlipSpeed);
        currentOffsetX += playerMovement.CurrentVelocity.x * Time.fixedDeltaTime * characterSpeedInfluence;
        cameraTarget.localPosition = new Vector3(currentOffsetX, cameraTarget.localPosition.y, cameraTarget.localPosition.z);
    }

    
}
