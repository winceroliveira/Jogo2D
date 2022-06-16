using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerInput : MonoBehaviour
{
    private struct PlayerInputConstants
    {
        public const string Horizontal = "Horizontal";
        public const string Vertical = "Vertical";
        public const string Jump = "Jump";
    }
   public Vector2 GetMovementInput()
    {
        //input Teclado
        float horizontalInput = Input.GetAxisRaw(PlayerInputConstants.Horizontal);

        //input mobile
        if (Mathf.Approximately(horizontalInput,0.0f))
        {
            horizontalInput = CrossPlatformInputManager.GetAxisRaw(PlayerInputConstants.Horizontal);
        }
        return new Vector2(horizontalInput,0);
    }

    public bool IsJumpButtonDown()
    {
        //retorna verdadeiro somente na primeira vez que aperta espaço
        bool isKeyboardButtonDown = Input.GetKeyDown(KeyCode.Space);
        bool isMobileButtonDown = CrossPlatformInputManager.GetButtonDown(PlayerInputConstants.Jump);
        return isKeyboardButtonDown || isMobileButtonDown;
    }
    public bool IsJumpButtonHeld()
    {
        //retorna verdadeiro enquanto estiver apertando o espaço
        bool isKeyboardButtonHeld = Input.GetKey(KeyCode.Space);
        bool isMobileButtonHeld = CrossPlatformInputManager.GetButton(PlayerInputConstants.Jump);
        return isKeyboardButtonHeld || isMobileButtonHeld;
    }
    public bool IsCrouchButtonDown()
    {
        bool isKeyboradButtonDown = Input.GetKeyDown(KeyCode.S);
        bool isMobileButtonDown = CrossPlatformInputManager.GetAxisRaw(PlayerInputConstants.Vertical) < 0;
        return isKeyboradButtonDown || isMobileButtonDown;
    }
    public bool IsCrouchButtonUp()
    {
        bool isKeyboradButtonUp = Input.GetKey(KeyCode.S) == false;
        bool isMobileButtonUp = CrossPlatformInputManager.GetAxisRaw(PlayerInputConstants.Vertical) >= 0;
        return isKeyboradButtonUp && isMobileButtonUp;
    }
}
