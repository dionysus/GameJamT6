using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    [SerializeField] public bool isTouching = false;
    [SerializeField] public bool isHot = false;

    private void OnCollisionStay(Collision other) {
        isTouching = true;
    }

    private void OnCollisionExit(Collision other) {
        isTouching = false;
    }

}
