using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioScript : MonoBehaviour
{
    private AudioSource aSource;
    public AudioClip slashAudio;

    void Start()
    {
        aSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        PlayerPress();
    }

    void PlayerPress()
    {
        if(Input.GetMouseButtonDown(0))
        {
            slashAudio.
            aSource.PlayOneShot(slashAudio, 0.5F);
        }
    }
}
