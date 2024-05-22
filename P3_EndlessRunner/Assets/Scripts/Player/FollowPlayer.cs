using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    //move camera with each frame
    //snap camera back to it original position
    public Transform player;
    public Vector3 offset;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.position = player.position + offset;
        //x=0 y=2.5 z=-5.5 rotation x=20
    }
}
