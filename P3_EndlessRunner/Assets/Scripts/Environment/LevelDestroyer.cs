using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelDestroyer : MonoBehaviour
{
    public string parentName;
    public GameObject playerObject;

    void Start()
    {
        playerObject = GameObject.FindGameObjectWithTag("Player");
    }

    private void Update()
    {
        parentName = transform.name; //get name of object
        StartCoroutine(DestroyClone());
    }

    IEnumerator DestroyClone()
    {
        yield return new WaitForSeconds(10);
        if (parentName == "Section(Clone)")
        {
            // Check if the section is behind the player
            if (transform.position.z+55 < playerObject.transform.position.z)
            {
                Destroy(gameObject);
            }
        }
    }
}
