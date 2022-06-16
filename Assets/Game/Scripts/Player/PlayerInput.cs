using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
   public Vector2 GetMovementInput()
    {
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        return new Vector2(horizontalInput,0);
    }

    public bool IsJumpButtonDown()
    {
        //retorna verdadeiro somente na primeira vez que aperta espaço
        return Input.GetKeyDown(KeyCode.Space);
    }
    public bool IsJumpButtonHeld()
    {
        //retorna verdadeiro enquanto estiver apertando o espaço
        return Input.GetKey(KeyCode.Space);
    }
}
