using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class EnemyChase : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 4f;
    private EnemyController enemyController;
    private bool isChasing = true;

    private void Awake ()
    {
        enemyController = GetComponent<EnemyController>();
    }

    public void Chase()
    {
        if (!isChasing) return;
        Vector3 direction = (enemyController.player.transform.position - transform.position).normalized; //dirección
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg; //calcula rotacion
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward); //aplica rotacion
        transform.position = Vector3.MoveTowards(transform.position, enemyController.player.transform.position, moveSpeed * Time.deltaTime); //mueve
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        ObjectSneak objectSneak = collision.gameObject.GetComponent<ObjectSneak>();
            if (objectSneak != null)
            {
                // no funciona esto
                isChasing = false;
            }
    }
}
