using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationAudio : MonoBehaviour
{
    public AudioClip land;
    public AudioClip jump;
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

    public void Land()
    {
        source.PlayOneShot(land);
    }

    public void Jump()
    {
        source.PlayOneShot(jump);
    }
}
