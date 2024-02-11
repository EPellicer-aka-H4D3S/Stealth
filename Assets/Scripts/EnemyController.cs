using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private EnemyDetection enemyDetection;
    [SerializeField] private EnemyChase enemyChase;
    [SerializeField] private EnemyPatrol enemyPatrol;
    public GameObject player;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        enemyChase = GetComponent<EnemyChase>();
        enemyPatrol = GetComponent<EnemyPatrol>();
        enemyDetection = GetComponent<EnemyDetection>();
    }

    void Update()
    {
        if (enemyDetection.DetectPlayers().Length > 0)
        {
            enemyChase.Chase();
        }
        else
        {
            enemyPatrol.Patrol();
        }
    }
        /*
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
        */
    }