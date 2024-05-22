using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUps : MonoBehaviour
{
    public GameObject pickupEffect;
    public float multiplier = 2f;
    /*private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player collided with power-up");
            StartCoroutine(Pickup(other));
        }
    }

    IEnumerator Pickup(Collider Player)
    {
        Instantiate(pickupEffect, transform.position, transform.rotation);
        Debug.Log("Power-up effect instantiated");
        //spawn a cool effect
        //Player.transform.localScale *= multiplier; //player gets 14% bigger
        PlayerMove player = Player.GetComponent<PlayerMove>();
        player.forwardSpeed *= multiplier;
        GetComponent<MeshRenderer>().enabled = false;
        GetComponent<Collider>().enabled = false;
        //reverse effect on player
        yield return new WaitForSeconds(4);
        player.forwardSpeed /= multiplier;
        //Destroy(gameObject);
    }*/
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player collided with power-up");
            Instantiate(pickupEffect, transform.position, transform.rotation);
            ApplyPowerUpEffect(other);
        }
    }

    void ApplyPowerUpEffect(Collider playerCollider)
    {
        // Apply power-up effects to the player
        PlayerMove player = playerCollider.GetComponent<PlayerMove>();
        player.forwardSpeed *= multiplier;

        // Disable the power-up object
        GetComponent<MeshRenderer>().enabled = false;
        GetComponent<Collider>().enabled = false;

        // Schedule the power-up effect to be removed after a delay
        StartCoroutine(RemovePowerUpEffect(player));
    }

    IEnumerator RemovePowerUpEffect(PlayerMove player)
    {
        // Wait for a specified duration
        yield return new WaitForSeconds(4);

        // Remove the power-up effect from the player
        player.forwardSpeed /= multiplier;

        // Destroy the power-up object
        Destroy(gameObject);
    }
}
