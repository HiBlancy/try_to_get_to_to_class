using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedReduce : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            PlayerMovement.obj.speed = 2f;
        }
    }
}
