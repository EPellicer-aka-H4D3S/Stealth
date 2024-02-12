using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSneak : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && collision is CircleCollider2D)
        {
            Physics2D.IgnoreCollision(GetComponent<Collider2D>(), collision, true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && collision is CircleCollider2D)
        {
            Physics2D.IgnoreCollision(GetComponent<Collider2D>(), collision, false);

        }
    }
}
