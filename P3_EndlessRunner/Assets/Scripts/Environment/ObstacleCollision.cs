using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObstacleCollision : MonoBehaviour
{
    public GameObject player;
    public GameObject charModel;
    public GameObject levelControl;
    void OnTriggerEnter(Collider other)
    {
        this.gameObject.GetComponent<BoxCollider>().enabled = false;
        player.GetComponent<PlayerMove>().enabled = false;
        charModel.GetComponent<Animator>().Play("Hit To Head");
        PlayerMove.canMove = false;
        levelControl.GetComponent<EndRunSequence>().enabled = true;
    }
}
