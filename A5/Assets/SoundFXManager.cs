using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundFXManager : MonoBehaviour
{
    public static SoundFXManager instance;
    [SerializeField] private AudioSource soundFXobject;

    private void Awake()
    {
        if (instance == null)
            instance = this;
    }

    public void PlayClip(AudioClip clip, Transform FXtransform, float volume)
    {
        //spawn in GO
        AudioSource audiosource = Instantiate(soundFXobject, FXtransform.position, Quaternion.identity);

        //set audio clip

        audiosource.clip = clip;

        //set volume
        audiosource.volume = volume;

        //play sound
        audiosource.Play();

        float clip_length = clip.length;

        Destroy(audiosource.gameObject, clip_length);

        //destroy gameobject
    }
}
