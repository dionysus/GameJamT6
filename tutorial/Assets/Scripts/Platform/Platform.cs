using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    [SerializeField] public bool isTouching = false;
    [SerializeField] public bool isHot = false;
    [SerializeField] public bool isCold = false;

    private void OnCollisionStay(Collision other) {
        isTouching = true;
    }

    private void OnCollisionExit(Collision other) {
        isTouching = false;
    }

    private void OnCollisionEnter(Collision other) {
        if (isHot) {
            Debug.Log("HOT PLATFORM!");
            PlayerAudio.Instance.PlayDamageAudio();
            // DAMAGE CHARACTER
        }

        if (isCold) {
            Debug.Log("COLD PLATFORM!");
            // Heal Character
        }
    }
}
