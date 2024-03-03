using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Switcher : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Gamemanager.instance.mapHolder.Switch();
    }


}
