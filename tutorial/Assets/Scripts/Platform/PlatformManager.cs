using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformManager : MonoBehaviour
{

    [SerializeField] public Platform[] platforms;
    [SerializeField] public bool playerGrounded;

    private static PlatformManager instance;
    public static PlatformManager Instance { get { return instance; } }

    void Awake() {
        if (instance == null) {
            instance = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        platforms = GameObject.FindObjectsOfType<Platform>();
    }

    void Update()
    {
        bool platformTouched = false;
        for (int i = 0; i < platforms.Length; i++) {
            if (platforms[i].isTouching) {
                platformTouched = true;
                break;
            }
        }
        playerGrounded = platformTouched;
    }
}
