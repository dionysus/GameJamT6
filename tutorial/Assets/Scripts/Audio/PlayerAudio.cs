using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class PlayerAudio : MonoBehaviour
{

    [SerializeField] string jumpClipsPath = "Audio/Effects/Jump";
    [SerializeField] string damageClipsPath = "Audio/Effects/Damage";

    private AudioClip[] jumpClips;
    private AudioClip[] damageClips;

    private static PlayerAudio instance;
    public static PlayerAudio Instance { get { return instance; } }

    void Awake() {
        if (instance == null) {
            instance = this;
        }
        InputManager.PlayerJump.AddListener(PlayJumpAudio);
        GetAudioClips();
    }

    void PlayJumpAudio() {
        AudioManager.Instance.PlayRandomClip(jumpClips);
    }

    // Can be called from other scripts: PlayerAudio.Instance.PlayDamageAudio()
    // Right now it is hooked up to Fire (Right Trigger)
    public void PlayDamageAudio() {
        AudioManager.Instance.PlayRandomClip(damageClips);
    }

    void GetAudioClips(){
        jumpClips = Resources.LoadAll(
            jumpClipsPath, typeof(AudioClip)).Cast<AudioClip>().ToArray();

        damageClips = Resources.LoadAll(
            damageClipsPath, typeof(AudioClip)).Cast<AudioClip>().ToArray();
    }

}
