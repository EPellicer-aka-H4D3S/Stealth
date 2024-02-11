using System;
using UnityEngine;
using UnityEngine.UIElements;

public class EnemyPatrol : MonoBehaviour
{

    [SerializeField] private float moveSpeed = 3f;
    [SerializeField] private Transform[] patrolPoints;
    private int currentPatrolIndex = 1;

    public void Patrol()
    {
        if (patrolPoints.Length > 0)
        {
            transform.position = Vector2.MoveTowards(transform.position, patrolPoints[currentPatrolIndex].position, moveSpeed * Time.deltaTime);

            Vector2 direction = (patrolPoints[currentPatrolIndex].position - transform.position).normalized;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

            if (Vector2.Distance(transform.position, patrolPoints[currentPatrolIndex].position) < 0.1f)
            {
                currentPatrolIndex = (currentPatrolIndex + 1) % patrolPoints.Length;
            }
        }
    }
    /*
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
    */
}