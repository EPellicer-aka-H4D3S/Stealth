using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TileScreen : MonoBehaviour
{

    private float time;
    private float distance;
    public GameObject player;
    public GameObject endingPoint;
    [SerializeField] private Text timeText;
    [SerializeField] private Text distanceText;
    [SerializeField] private Text finalTimeText;
    
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
            distance += player.GetComponent<Rigidbody2D>().velocity.magnitude * Time.deltaTime;
            timeText.text = "Time: " + Math.Truncate((decimal)time) + " sec";
            distanceText.text = "Distance: " + Math.Truncate((decimal)distance) + " units";
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