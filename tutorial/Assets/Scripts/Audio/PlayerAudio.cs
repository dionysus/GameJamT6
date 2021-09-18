using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class PlayerAudio : MonoBehaviour
{

    [SerializeField] AudioClip[] jumpClips;
    [SerializeField] string jumpClipsPath = "Audio/Effects/Jump";

    void Awake() {
        InputManager.PlayerJump.AddListener(Jump);
        GetAudioClips();
    }

    void Jump() {
        AudioManager.Instance.PlayRandomClip(jumpClips);
    }

    void GetAudioClips(){
        jumpClips = Resources.LoadAll(
            jumpClipsPath, typeof(AudioClip)).Cast<AudioClip>().ToArray();
    }

}
