using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private EnemyMovement movement; //Ref  al script de movimiento 
    [SerializeField] private EnemyDetection detection; //Ref al script de detecci�n 
    [SerializeField] private EnemyAnimation animation; //Ref script de animaci�n 

    void Update()
    {

        Vector3 targetDirection = detection.GetTargetDirection();


        animation.UpdateAnimation(targetDirection.magnitude > 0.1f);


        if (detection.TargetDetected())
        {
            movement.MoveTowards(targetDirection);
        }
        else
        {

            movement.Patrol();
        }
    }
}