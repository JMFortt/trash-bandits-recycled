using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody rb;
    public SpriteRenderer sprite;
    public Animator animator;
    private Vector3 movementVec;
    private string leftCommand;
    private string rightCommand;
    private string upCommand;
    private string downCommand;
    private bool defaultDirection = true;
    public int playerNum;
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        // define player input keys
        if (playerNum == 1)
        {
            leftCommand = "a";
            rightCommand = "d";
            upCommand = "w";
            downCommand = "s";
        }
        else if (playerNum == 2 || playerNum == 3)
        {
            leftCommand = "left";
            rightCommand = "right";
            upCommand = "up";
            downCommand = "down";
        }
    }

    // Update is called once per frame
    void Update()
    {
        // sprite direction controller:
        if ((rb.linearVelocity.x > 0) && (!defaultDirection))
        {
            sprite.flipX = false;
            defaultDirection = true;
        }
        else if ((rb.linearVelocity.x < 0) && (defaultDirection))
        {
            sprite.flipX = true;
            defaultDirection = false;
        }

        // sprite animation controller:
        if ((Input.GetKey(rightCommand)) || (Input.GetKey(leftCommand)) || (Input.GetKey(upCommand)) || (Input.GetKey(downCommand)))
        {
            animator.Play("Walk");
        }
        else
        {
            animator.Play("Idle");
        }

        // movement controller:
        movementVec = Vector3.zero;
        // right movement
        if (Input.GetKey(rightCommand))
        {
            movementVec += Vector3.right;
        }
        // left movement
        if (Input.GetKey(leftCommand))
        {
            movementVec += Vector3.left;
        }
        // upward movement
        if (Input.GetKey(upCommand))
        {
            movementVec += Vector3.forward;
        }
        // downward movement
        if (Input.GetKey(downCommand))
        {
            movementVec += Vector3.back;
        }

        //normalize and apply
        rb.position += movementVec.normalized * Time.deltaTime * speed/10;
        rb.linearVelocity = movementVec.normalized * speed;
    }
}
