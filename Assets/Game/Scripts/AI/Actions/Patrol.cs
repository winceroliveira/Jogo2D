using Pada1.BBCore;
using Pada1.BBCore.Framework;
using Pada1.BBCore.Tasks;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Platformer2D.Character;

[Action("Game/Patrol")]
public class Patrol : BasePrimitiveAction
{
    [InParam("AIController")]
    private EnemyAIController aiController;

    [InParam("PatrolSpeed")]
    private float patrolSpeed;

    [InParam("CharacterMoviment")]
    private CharacterMovement2D charMovement;
    public override void OnStart()
    {
        base.OnStart();
        Debug.Log("Patrol: On start");
        aiController.StartCoroutine(Temp_Walk());
        charMovement.MaxGroundSpeed = patrolSpeed;
    }
    public override TaskStatus OnUpdate()
    {
        Debug.Log("Patrol: On Update");
        return TaskStatus.RUNNING;
    }
    public override void OnAbort()
    {
        base.OnAbort();

        //TODO: Remover Depois
        aiController.StopAllCoroutines();
    }
    IEnumerator Temp_Walk()
    {
        while (true)
        {
            aiController.movementInput.x = 1;
            yield return new WaitForSeconds(1.0f);
            aiController.movementInput.x = 0;
            yield return new WaitForSeconds(2.0f);
            aiController.movementInput.x = -1;
            yield return new WaitForSeconds(1.0f);
            aiController.movementInput.x = 0;
            yield return new WaitForSeconds(2.0f);
        }
    }
}
