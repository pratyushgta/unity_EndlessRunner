using System.Collections;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float forwardSpeed = 5;
    public float sideSpeed = 4;
    public float upSpeed = 5;
    public float laneChangeDuration = 0.2f;

    public GameObject playerObject;

    static public bool canMove = false;
    private bool isJumping = false;
    private bool comingDown = false;
    private GameObject player;
    private int currentLane = 1; // Default middle lane
    private int targetLane = 1;
    private float[] lanePositions = { -2f, 0f, 2f };
    private Vector2 touchStartPos;

    void Start()
    {
        player = gameObject;
    }

    void Update()
    {
        // forward movement
        transform.Translate(Vector3.forward * Time.deltaTime * forwardSpeed, Space.World);

        if (canMove == true)
        {
            // Handle touch input
            if (Input.touchCount > 0)
            {
                Touch touch = Input.GetTouch(0);
                switch (touch.phase)
                {
                    case TouchPhase.Began:
                        touchStartPos = touch.position;
                        break;
                    case TouchPhase.Ended:
                        Vector2 touchEndPos = touch.position;
                        Vector2 swipeDirection = touchEndPos - touchStartPos;

                        if (Mathf.Abs(swipeDirection.x) > Mathf.Abs(swipeDirection.y))
                        {
                            if (swipeDirection.x > 0)
                            {
                                MoveRight();
                            }
                            else
                            {
                                MoveLeft();
                            }
                        }
                        else
                        {
                            if (swipeDirection.y > 0)
                            {
                                Jump();
                            }
                        }
                        break;
                }
            }
            else
            {

                // Handle keyboard input
                if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
                {
                    // Move left if not in the leftmost lane
                    MoveLeft();
                }
                if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
                {
                    // Move right if not in the rightmost lane
                    MoveRight();
                }
                transform.position = new Vector3(lanePositions[currentLane], transform.position.y, transform.position.z);
                if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.UpArrow))
                {
                    Jump();
                }
            }
        }

        if (isJumping == true)
        {
            if (comingDown == false)
            {
                transform.Translate(Vector3.up * Time.deltaTime * upSpeed, Space.World);
            }
            if (comingDown == true)
            {
                transform.Translate(Vector3.down * Time.deltaTime * upSpeed, Space.World);
            }
        }
    }

    private void MoveLeft()
    {
        if (currentLane > 0)
        {
            targetLane = currentLane - 1;
            StartCoroutine(MoveToLane(targetLane));
        }
    }

    private void MoveRight()
    {
        if (currentLane < lanePositions.Length - 1)
        {
            targetLane = currentLane + 1;
            StartCoroutine(MoveToLane(targetLane));
        }
    }

    private void Jump()
    {
        if (isJumping == false)
        {
            isJumping = true;
            playerObject.GetComponent<Animator>().Play("Jump");
            StartCoroutine(JumpSequence());
        }
    }

    IEnumerator JumpSequence()
    {
        yield return new WaitForSeconds(0.45f);
        comingDown = true;
        yield return new WaitForSeconds(0.45f);
        isJumping = false;
        comingDown = false;
        playerObject.GetComponent<Animator>().Play("Standard Run");
        transform.position = new Vector3(transform.position.x, 1.6f, transform.position.z);
    }

    IEnumerator MoveToLane(int targetLane)
    {
        float elapsedTime = 0f;
        Vector3 startPos = transform.position;
        Vector3 targetPos = new Vector3(lanePositions[targetLane], transform.position.y, transform.position.z);

        while (elapsedTime < laneChangeDuration)
        {
            transform.position = Vector3.Lerp(startPos, targetPos, elapsedTime / laneChangeDuration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        transform.position = targetPos;
        currentLane = targetLane;
    }
}
