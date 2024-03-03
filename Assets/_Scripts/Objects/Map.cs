using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Map : MonoBehaviour
{
    public Tilemap mapTiles;
    public TilemapCollider2D mapCollider;

    public bool toggeled = false;

    private void Start()
    {
        if (toggeled)
        {
            mapTiles.color = new Color(1, 1, 1, 1);
            mapCollider.enabled = true;
        }
        else
        {
            mapTiles.color = new Color(1, 1, 1, .25f);
            mapCollider.enabled = false;
        }
    }

    public void ToggleMap()
    {
        if(toggeled)
        {
            mapTiles.color = new Color(1, 1, 1, .25f);
            mapCollider.enabled = false;
            toggeled = false;
        } else
        {
            mapTiles.color = new Color(1, 1, 1, 1);
            mapCollider.enabled = true;
            toggeled = true;
        }
    }
}
