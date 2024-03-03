using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationAudio : MonoBehaviour
{
    public AudioClip[] footsteps;
    AudioSource source;
    // Start is called before the first frame update
    void Start()
    {
        source = GetComponent<AudioSource>();
    }


    public void Footstep()
    {
        source.PlayOneShot(footsteps[Random.Range(0, footsteps.Length)]);
    }
}
