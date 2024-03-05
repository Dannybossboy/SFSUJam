using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Water : MonoBehaviour
{


    public void OnTriggerEnter2D(Collider2D collision)
    {
        collision.GetComponent<PlayerMovement>().SetWater(true);
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        collision.GetComponent<PlayerMovement>().SetWater(false);
    }
}
