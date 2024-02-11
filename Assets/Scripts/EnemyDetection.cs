using UnityEngine;

public class EnemyDetection : MonoBehaviour
{
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
        return Physics2D.OverlapCircle(detectionPoint.position, detectionRadius, targetLayer) != null;
    }

    //Gizmo Radio
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(detectionPoint.position, detectionRadius);
    }
}