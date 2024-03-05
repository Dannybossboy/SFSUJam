using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Map : MonoBehaviour
{
    public Tilemap mapTiles;
    public TilemapCollider2D mapCollider;

    public Tilemap lavaTiles;
    public TilemapCollider2D lavaCollider;

    public Tilemap waterTiles;
    public TilemapCollider2D waterCollider;

    public bool toggeled = false;

    private void Start()
    {
        if (toggeled)
        {
            mapTiles.color = new Color(1, 1, 1, 1);
            mapCollider.enabled = true;

            lavaTiles.color = new Color(1, 1, 1, 1);
            lavaCollider.enabled = true;

            waterTiles.color = new Color(1, 1, 1, 1);
            waterCollider.enabled = true;
        }
        else
        {
            mapTiles.color = new Color(1, 1, 1, .25f);
            mapCollider.enabled = false;

            lavaTiles.color = new Color(1, 1, 1, .25f);
            lavaCollider.enabled = false;

            waterTiles.color = new Color(1, 1, 1, .25f);
            waterCollider.enabled = false;
        }
    }

    public void ToggleMap()
    {
        if(toggeled)
        {
            mapTiles.color = new Color(1, 1, 1, .25f);
            mapCollider.enabled = false;

            lavaTiles.color = new Color(1, 1, 1, .25f);
            lavaCollider.enabled = false;

            waterTiles.color = new Color(1, 1, 1, .25f);
            waterCollider.enabled = false;

            toggeled = false;
        } else
        {
            mapTiles.color = new Color(1, 1, 1, 1);
            mapCollider.enabled = true;

            lavaTiles.color = new Color(1, 1, 1, 1);
            lavaCollider.enabled = true;

            waterTiles.color = new Color(1, 1, 1, 1);
            waterCollider.enabled = true;

            toggeled = true;
        }
    }
}
