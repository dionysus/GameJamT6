using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawner : MonoBehaviour
{

    private GameObject playerCharacter;
    private const float respawnHeight = -10f;
    private Transform playerTransform;
    private Rigidbody playerRb;

    private HealthBar healthBar;
    // Start is called before the first frame update
    void Start()
    {
        SpawnPlayer();
    }

    // Update is called once per frame
    void Update()
    {
        if (playerTransform.position.y <= respawnHeight) {
            playerRb.transform.position = this.transform.position;
            playerRb.velocity = new Vector3(0,0,0);
        }
    }

    void SpawnPlayer() {
        playerCharacter = GameObject.Instantiate(Resources.Load("Player")) as GameObject;
        playerRb = playerCharacter.GetComponent<Rigidbody>();
        playerRb.velocity = new Vector3(0,0,0);
        playerTransform = playerCharacter.transform;
    }
}
