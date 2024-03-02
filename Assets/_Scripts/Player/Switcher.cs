using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Switcher : MonoBehaviour
{
    public Tilemap map_01;
    public TilemapCollider2D map_01Collider;
    public Tilemap map_02;
    public TilemapCollider2D map_02Collider;

    bool map_01_Active = true;
    // Start is called before the first frame update
    void Start() //Initilizes the map colors
    {
        if (map_01_Active)
        {
            map_01.color = new Color(1, 1, 1, 1f);
            map_02.color = new Color(1, 1, 1, .25f);
            map_01Collider.enabled = true;
            map_02Collider.enabled = false;
        }
        else
        {
            map_01.color = new Color(1, 1, 1, .25f);
            map_02.color = new Color(1, 1, 1, 1);
            map_01Collider.enabled = false;
            map_02Collider.enabled = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Mouse0))
        {
            SwitchMaps();
        }
    }

    public void SwitchMaps()
    {
        if (map_01_Active)
        {
            map_01.color = new Color(1, 1, 1, .25f);
            map_02.color = new Color(1, 1, 1, 1);

            map_01_Active = false;
            map_01Collider.enabled = false;
            map_02Collider.enabled = true;
        }
        else
        {
            map_01.color = new Color(1, 1, 1, 1);
            map_02.color = new Color(1, 1, 1, .25f);

            map_01_Active = true;
            map_01Collider.enabled = true;
            map_02Collider.enabled = false;
        }
    }


}
