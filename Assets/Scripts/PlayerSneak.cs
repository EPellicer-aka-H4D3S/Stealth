using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSneak : MonoBehaviour
{   
    private bool isSneaking = false;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            isSneaking = true;
            ToggleSneakMode(isSneaking);
            Debug.Log("sigilo Miau");
        }
        else if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            isSneaking = false;
            ToggleSneakMode(isSneaking);
            Debug.Log("dejar de ser sigiloso");
        }
    }

    private void ToggleSneakMode(bool isSneaking)
    {

        ObjectSneak[] objects = FindObjectsOfType<ObjectSneak>();
        foreach (ObjectSneak obj in objects)
        {
            obj.gameObject.GetComponent<Collider2D>().enabled = !obj.gameObject.GetComponent<Collider2D>().enabled;
        }

    }

}
