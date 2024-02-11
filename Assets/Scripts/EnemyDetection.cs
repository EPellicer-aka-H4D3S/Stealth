using System.Collections.Generic;
using UnityEngine;

public class EnemyDetection : MonoBehaviour
{
    public LayerMask whatIsPlayer;
    public LayerMask whatIsVisible;
    public float detectionRange;
    public float visionAngle;

    public Transform[] DetectPlayers()
    {
        List<Transform> players = new List<Transform>();

        if (PlayerInRange(ref players))
        {
            if (PlayerInAngle(ref players))
            {
                PlayerIsVisible(ref players);
            }
        }

        return players.ToArray();
    }

    private bool PlayerInRange(ref List<Transform> players)
    {
        Collider2D[] playerColliders = Physics2D.OverlapCircleAll(transform.position, detectionRange, whatIsPlayer);

        if (playerColliders.Length == 0)
        {
            return false;
        }

        foreach (var item in playerColliders)
        {
            players.Add(item.transform);
        }

        return true;
    }

    private bool PlayerInAngle(ref List<Transform> players)
    {
        for (int i = players.Count - 1; i >= 0; i--)
        {
            var angle = GetAngle(players[i]);

            if (angle > visionAngle / 2)
            {
                players.Remove(players[i]);
            }
        }

        return players.Count > 0;
    }

    private float GetAngle(Transform target)
    {
        Vector2 targetDir = target.position - transform.position;
        float angle = Vector2.Angle(targetDir, transform.right);
        angle = Mathf.Abs(angle);

        return angle;
    }

    private bool PlayerIsVisible(ref List<Transform> players)
    {
        for (int i = players.Count - 1; i >= 0; i--)
        {
            var isVisible = IsVisible(players[i]);

            if (!isVisible)
            {
                players.Remove(players[i]);
            }
        }

        return (players.Count > 0);
    }

    private bool IsVisible(Transform target)
    {
        Vector3 dir = target.position - transform.position;
        RaycastHit2D hit = Physics2D.Raycast(
           transform.position,
           dir,
           detectionRange,
           whatIsVisible
        );

        return (hit.collider.transform == target);
    }


    /*
    [SerializeField] private Transform detectionPoint;
    [SerializeField] private LayerMask targetLayer;
    [SerializeField] private float detectionRadius = 5f;

    // obtener dirección objetivo 
    public Vector3 GetTargetDirection()
    {
        Collider2D targetCollider = Physics2D.OverlapCircle(detectionPoint.position, detectionRadius, targetLayer);
        if (targetCollider != null)
        {
            Vector3 targetDirection = (targetCollider.transform.position - transform.position).normalized;
            return targetDirection;
        }
        else
        {
            return Vector3.zero;
        }
    }

    //  verificar si se detecto algo 
    public bool TargetDetected()
    {
        return Physics2D.OverlapCircle(detectionPoint.position, detectionRadius, targetLayer);
    }

    //Gizmo Radio
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(detectionPoint.position, detectionRadius);
    }
    */
}