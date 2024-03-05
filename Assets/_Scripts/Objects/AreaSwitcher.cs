using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaSwitcher : MonoBehaviour
{
    public CinemachineConfiner2D confiner;

    public PolygonCollider2D newArea;

    public Transform areaCheckpoint;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        confiner.m_BoundingShape2D = newArea;
        Gamemanager.instance.lastCheckPoint = areaCheckpoint.position;
    }
}
