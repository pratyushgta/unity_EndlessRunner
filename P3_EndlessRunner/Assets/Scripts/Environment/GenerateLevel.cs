using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateLevel : MonoBehaviour
{
    public GameObject[] section;
    public int zPos = 55;
    //to generate a section at particular intervals
    public bool creatingSection = false;
    public int section_num;

 

    // Update is called once per frame
    void Update()
    {
        if(creatingSection == false)
        {
            creatingSection = true;
            //coroutine is a method with a time delay
            StartCoroutine(GenerateSection());
        }
    }

    IEnumerator GenerateSection()
    {
        section_num = Random.Range(0, 3); //we have 3 sections to choose from
        Instantiate(section[section_num], new Vector3(0,0,zPos),Quaternion.identity);
        zPos += 55;
        yield return new WaitForSeconds(2); //create new section every 2 seconds
        creatingSection = false;

    }
}
