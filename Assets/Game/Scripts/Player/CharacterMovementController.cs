using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Platformer2D.Character;

public static class CharacterMovementAnimationKeys
{
    public const string IsCrouchhing = "isCrouch";
    public const string HorizontalSpeed = "HorizontalSpeed";
    public const string VerticalSpeed = "VerticalSpeed";
    public const string IsGrounded = "IsGrounded";
}
public static class EnemyAnimationKeys
{
    public const string IsChaseing = "IsChasing";
}
public class CharacterMovementController : MonoBehaviour
{
    
    Animator animator;
    CharacterMovement2D playerMovement;
    EnemyAIController aiController;
    PlayerController playerController;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        playerMovement = GetComponent<CharacterMovement2D>();
        aiController = GetComponent<EnemyAIController>();
        playerController = GetComponent<PlayerController>();
    }
    private void Update()
    {
        animator.SetFloat(CharacterMovementAnimationKeys.HorizontalSpeed, playerMovement.CurrentVelocity.x/playerMovement.MaxGroundSpeed);
        if (playerController != null)
        {
            animator.SetBool(CharacterMovementAnimationKeys.IsCrouchhing, playerMovement.IsCrouching);
            animator.SetFloat(CharacterMovementAnimationKeys.VerticalSpeed, playerMovement.CurrentVelocity.y / playerMovement.JumpSpeed);
            animator.SetBool(CharacterMovementAnimationKeys.IsGrounded, playerMovement.IsGrounded);
        }
        if(aiController != null)
        {
            animator.SetBool(EnemyAnimationKeys.IsChaseing, aiController.isChasing);
        }

    }
}
