using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class EnemyChase : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 6f;
    private EnemyController enemyController;

    private void Awake ()
    {
        enemyController = GetComponent<EnemyController>();
    }

    public void Chase()
    {
        transform.LookAt(enemyController.player.transform.position);
        transform.position = Vector2.MoveTowards(transform.position,enemyController.player.transform.position , moveSpeed * Time.deltaTime);
    }
}