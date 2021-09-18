using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    private AudioSource effectsSource;
    private AudioSource musicSource;
    private static AudioManager instance;
    public static AudioManager Instance { get { return instance; } }


    void Awake()
    {
        if (instance == null) {
            instance = this;
        }
        effectsSource = gameObject.AddComponent<AudioSource>() as AudioSource; 
        musicSource = gameObject.AddComponent<AudioSource>() as AudioSource;
    }

    public void PlayClip(AudioClip audioClip) {
        effectsSource.PlayOneShot(audioClip);
    }

    public void PlayRandomClip(AudioClip[] audioClips) {
        if (audioClips.Length > 0) {
            AudioClip clip = audioClips[Random.Range(0, audioClips.Length - 1)];
            if (clip != null) {
                effectsSource.PlayOneShot(clip);
            }
        }
    }
}
