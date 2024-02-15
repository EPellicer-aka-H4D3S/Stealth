using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ScreenManager : MonoBehaviour
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
        if (SceneManager.GetActiveScene().name=="Ending") { finalTimeText.text = "You won in " + Math.Truncate((decimal)PlayerPrefs.GetFloat("time")) + " seconds"; }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            SceneManager.LoadScene("Gameplay");
        }
        if (SceneManager.GetActiveScene().name=="Gameplay")
        {
            time += Time.deltaTime;
            distance += player.GetComponent<Rigidbody2D>().velocity.magnitude * Time.deltaTime;
            timeText.text = "Time: " + Math.Truncate((decimal)time) + " sec";
            distanceText.text = "Distance: " + Math.Truncate((decimal)distance) + " units";
            if (endingPoint.GetComponent<Collider2D>().IsTouching(player.GetComponent<Collider2D>()))
            {
                PlayerPrefs.SetFloat("time", time);
                SceneManager.LoadScene("Ending");
                
                Debug.Log(finalTimeText);
            }
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Debug.Log("Escape working");
            Application.Quit();
        }
        
    }
}