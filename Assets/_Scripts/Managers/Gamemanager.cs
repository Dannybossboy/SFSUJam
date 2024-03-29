using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gamemanager : MonoBehaviour
{
    public static Gamemanager instance;

    [Header("References")]
    public MapHolder mapHolder;
    public Transform levelSpawn;

    public PlayerMovement player;

    [Header("Private")]
    public Vector3 lastCheckPoint;

    public myDelegate GlobalSwitch;
    public delegate void myDelegate();

    private void Awake() //Sets the global static variable
    {
        if(instance == null)
        {
            instance = this;
        } else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        lastCheckPoint = levelSpawn.position;
        player.transform.position = lastCheckPoint;
    }

    public void Death()
    {
        player.transform.position = lastCheckPoint;
    }
}
