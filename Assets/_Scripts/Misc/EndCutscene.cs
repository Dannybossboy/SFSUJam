using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndCutscene : MonoBehaviour
{
    public CinemachineVirtualCamera endCam;
    public CinemachineVirtualCamera playerCam;
    public Animator knightAnimator;
    public GameObject text;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Gamemanager.instance.player.ResetMovement();
        endCam.m_Priority = 10;
        playerCam.m_Priority = 9;
        Invoke("Mad", 2f);
        text.SetActive(false);
    }

    private void Mad()
    {
        Gamemanager.instance.player.animator.SetTrigger("Mad");
        knightAnimator.SetTrigger("Sad");
    }
}
