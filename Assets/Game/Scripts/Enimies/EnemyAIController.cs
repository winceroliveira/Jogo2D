using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Platformer2D.Character;

[RequireComponent(typeof(CharacterMovement2D))]
public class EnemyAIController : MonoBehaviour
{

    CharacterMovement2D enemyMovement;
    Vector2 movementInput;
    private void Start()
    {
        enemyMovement = GetComponent<CharacterMovement2D>();
        StartCoroutine("Temp_Walk");
    }
    private void Update()
    {
        enemyMovement.ProcessMovementInput(movementInput);
    }
    IEnumerator Temp_Walk()
    {
        while (true)
        {
            movementInput.x = 1;
            yield return new WaitForSeconds(1.0f);
            movementInput.x = 0;
            yield return new WaitForSeconds(2.0f);
            movementInput.x = -1;
            yield return new WaitForSeconds(1.0f);
            movementInput.x = 0;
            yield return new WaitForSeconds(2.0f);
        }
    }
}
