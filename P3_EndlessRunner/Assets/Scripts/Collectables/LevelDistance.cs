using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class NewBehaviourScript : MonoBehaviour
{
    public GameObject distDisplay;
    public GameObject distEndDisplay;
    public int distRun;
    public bool addingDist = false;
    public float distDelay = 0.40f;

    // Update is called once per frame
    void Update()
    {
        if(addingDist == false && PlayerMove.canMove)
        {
            addingDist = true;
            StartCoroutine(AddingDistance());
        }
    }

    //coroutine
    IEnumerator AddingDistance()
    {
        distRun += 1;
        distDisplay.GetComponent<Text>().text = "" + distRun + " metres";
        distEndDisplay.GetComponent<Text>().text = "" + distRun + " metres";
        yield return new WaitForSeconds(distDelay);
        addingDist = false;
    }
}
