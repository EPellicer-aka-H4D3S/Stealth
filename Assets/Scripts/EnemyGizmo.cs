using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public class EnemyGizmo : MonoBehaviour
{
    [SerializeField] private float playerDistance;
    [SerializeField] private EnemyDetection enemyDetection;
    private Transform player;
    private float visionRange;

    public void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        visionRange = GetComponent<EnemyDetection>().detectionRange;
    }

    private void Update()
    {
        if (player != null)
        {
            playerDistance = Vector3.Distance(transform.position, player.position);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, visionRange);
        Gizmos.color = Color.yellow;
        if (player != null) Gizmos.DrawLine(transform.position, player.position);
        Gizmos.color = Color.white;
    }

    private float GetPlayerDistance(Transform transform)
    {
        float dist = 0.0f;
        if (player != null) Vector3.Distance(transform.position, player.position);
        return dist;
    }
}
