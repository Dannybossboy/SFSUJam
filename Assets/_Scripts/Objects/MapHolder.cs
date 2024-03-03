using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapHolder : MonoBehaviour
{

    public Map map1;
    public Map map2;

    public void Switch()
    {
        map1.ToggleMap();
        map2.ToggleMap();
    }

}
