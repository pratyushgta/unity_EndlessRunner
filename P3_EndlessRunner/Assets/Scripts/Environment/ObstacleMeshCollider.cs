using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObstacleMeshCollision : MonoBehaviour
{
    public GameObject player;
    public GameObject charModel;
    public GameObject levelControl;

    // Reference to the Mesh Collider
    private MeshCollider meshCollider;

    void Start()
    {
        // Get the Mesh Collider component
        meshCollider = GetComponent<MeshCollider>();
        // Ensure that the Mesh Collider is set to trigger mode
        meshCollider.isTrigger = true;

        // Use FindGameObjectWithTag instead of FindGameObjectsWithTag
        player = GameObject.FindGameObjectWithTag("Player");
        charModel = GameObject.FindGameObjectWithTag("PlayerModel");
        levelControl = GameObject.FindGameObjectWithTag("Level");      
    }

    void OnTriggerEnter(Collider other)
    {
        // Disable the Mesh Collider
        meshCollider.enabled = false;

        // Disable player movement
        player.GetComponent<PlayerMove>().enabled = false;

        // Trigger hit animation
        charModel.GetComponent<Animator>().Play("Hit To Head");

        // Stop player movement
        PlayerMove.canMove = false;

        // Enable end run sequence
        levelControl.GetComponent<EndRunSequence>().enabled = true;
    }
}
