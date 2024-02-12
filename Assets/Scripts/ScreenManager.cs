using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TileScreen : MonoBehaviour
{

    private float time;
    public GameObject player;
    public GameObject endingPoint;
    [SerializeField] private Text finalTimeText;
    [SerializeField] private Text timeText;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        endingPoint = GameObject.Find("Food");
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            SceneManager.LoadScene("Gameplay");
        }
        if (SceneManager.GetActiveScene().buildIndex==1)
        {
            time += Time.deltaTime;
            timeText.text = "Time: " + Math.Truncate((decimal)time) + " sec";
            if (endingPoint.GetComponent<Collider2D>().IsTouching(player.GetComponent<Collider2D>()))
            {
                SceneManager.LoadScene("Ending");
                finalTimeText.text = "You won in " + Math.Truncate((decimal)time) + " seconds";
            }
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Debug.Log("Escape working");
            Application.Quit();
        }
        
    }
}