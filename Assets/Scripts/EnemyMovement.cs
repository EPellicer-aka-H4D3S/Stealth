using System;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 3f;
    [SerializeField] private Transform[] patrolPoints;
    private int currentPatrolIndex = 0;

    void Update()
    {

        if (patrolPoints.Length > 0) //Patrulla y logica
        {
            MoveTowards(patrolPoints[currentPatrolIndex].position);
            if (Vector2.Distance(transform.position, patrolPoints[currentPatrolIndex].position) < 0.1f)
            {
                currentPatrolIndex = (currentPatrolIndex + 1) % patrolPoints.Length;
            }
        }
    }
    private void MoveTowards(Vector3 targetPosition)
    {   //Mover hacia 
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);

        //Rotar
        Vector3 direction = (targetPosition - transform.position).normalized;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }

    internal void Patrol()
    {
        throw new NotImplementedException();
    }
}