using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{

    private float inputDirection;
    private float verticalVelocity;
    private float speed = 5.0f;
    private float gravity = 1.0f;
    private float jumpForce = 20.0f;
    private bool secondJumptAvail = false;
    private float coinCollected = 0f;
    private Vector3 moveVector;
    private Vector3 lastMotion;
    private CharacterController controller;
    public Text textScore;

    // Use this for initialization
    void Start()
    {
        controller = GetComponent<CharacterController>();
        InvokeRepeating("Timer", 1, 1);
    }

    // Update is called once per frame
    void Update()
    {
        moveVector = Vector3.zero;
        inputDirection = Input.GetAxis("Horizontal") * speed;

        if (IsControllerGrounded())
        {
            verticalVelocity = 0;
            if (Input.GetKeyDown(KeyCode.Space))
            {
                // Make the player jump
                verticalVelocity = jumpForce;
                secondJumptAvail = true;
            }
            moveVector.x = inputDirection;
        }
        else
        {
            verticalVelocity -= gravity;
            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (secondJumptAvail)
                    verticalVelocity = jumpForce;
                secondJumptAvail = false;
            }

            verticalVelocity -= gravity * Time.deltaTime;
            moveVector.x = lastMotion.x;
        }


        moveVector.y = verticalVelocity;
        // moveVector = new Vector3 (inputDirection, verticalVelocity, 0);
        controller.Move(moveVector * Time.deltaTime);
        lastMotion = moveVector;
    }

    private bool IsControllerGrounded()
    {
        Vector3 leftRayStart;
        Vector3 rightRayStart;
        // set the start point to the center of the controller object
        leftRayStart = controller.bounds.center;
        rightRayStart = controller.bounds.center;

        // bounds.extents.x is the radius of the controller - being a spherical object
        leftRayStart.x -= controller.bounds.extents.x; // subtract the radius
        rightRayStart.x += controller.bounds.extents.x; // add the radius

        Debug.DrawRay(leftRayStart, Vector3.down, Color.red);
        Debug.DrawRay(rightRayStart, Vector3.down, Color.grey);

        if (Physics.Raycast(leftRayStart, Vector3.down, (controller.height / 2) + 0.1f))
            return true;
        if (Physics.Raycast(rightRayStart, Vector3.down, (controller.height / 2) + 0.1f))
            return true;

        return false;
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (controller.collisionFlags == CollisionFlags.Sides)
        {
            // Debug.Log("Hit sides of something");
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Debug.DrawRay(hit.point, hit.normal, Color.red, 2.0f);
                moveVector = hit.normal * speed;
                verticalVelocity = jumpForce;
                secondJumptAvail = true;
            }
        }

        // Collectables
        switch (hit.gameObject.tag)
        {
            case "Coin":
                coinCollected = coinCollected + 1;
                Debug.Log("coins collected = " + coinCollected);
                textScore.text = "Score = " + coinCollected;
                Destroy(hit.gameObject);
                break;
            case "JumpPad":
                verticalVelocity = jumpForce * 2;
                break;
            default:
                break;
        }
                           

    }



    private void Timer()
    {
        coinCollected -= 0.1f; 
        textScore.text = "Score = " + coinCollected;
    }


}