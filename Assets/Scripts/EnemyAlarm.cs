using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAlarm : MonoBehaviour
{
    [SerializeField] private EnemyDetection enemyDetection;
    SpriteRenderer alarmRenderer;

    private void Awake()
    {   
        enemyDetection = GetComponentInParent<EnemyDetection>();
        alarmRenderer = GetComponent<SpriteRenderer>();
    }

     private void Update()
    {
        if (enemyDetection != null && enemyDetection.DetectPlayers().Length > 0)
        {
            PlayerDetected();
        }
        else
        {
            PlayerLeft();
        }
    }

    public void PlayerDetected()
    {
        ChangeColor(Color.red);
    }

    public void PlayerLeft()
    {
        ChangeColor(new Color(0,0,0,0));
    }

    private void ChangeColor(Color color)
    {
        if (alarmRenderer == null) alarmRenderer = GetComponent<SpriteRenderer>();

        alarmRenderer.color = color;
    }
}