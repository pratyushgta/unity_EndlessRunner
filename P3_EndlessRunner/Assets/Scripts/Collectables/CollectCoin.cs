using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollectCoin : MonoBehaviour
{
    public AudioSource coinFX;

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("OnTriggerEnter " + gameObject.name);
        if (other.gameObject.GetComponent<ObstacleCollision>() != null)
        {
            Destroy(gameObject);
            return;
        }
        Debug.Log("OnTriggerEnter 2" + gameObject.name);
        coinFX.Play();
        CollectableControl.coinCount += 1;
        StartCoroutine(PlayAudioAndDeactivate());
        //this.gameObject.SetActive(false);
    }

    IEnumerator PlayAudioAndDeactivate()
    {
        coinFX.Play();
        yield return new WaitForSeconds(0.18f);
        gameObject.SetActive(false);
    } 


}
