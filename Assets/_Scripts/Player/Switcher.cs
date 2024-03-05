using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Switcher : MonoBehaviour
{
    public AudioClip switchSound;

    private AudioSource source;
    private Animator animator;


    private void Start()
    {
        animator = GetComponent<Animator>();
        source = GetComponent<AudioSource>();

        Gamemanager.instance.GlobalSwitch += VisualSwitch;
    }

    private void OnDestroy()
    {
        Gamemanager.instance.GlobalSwitch -= VisualSwitch;
    }

    public void VisualSwitch()
    {
        animator.SetTrigger("Switch");
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Gamemanager.instance.GlobalSwitch.Invoke();
        Gamemanager.instance.mapHolder.Switch();
        source.PlayOneShot(switchSound);
    }


}
