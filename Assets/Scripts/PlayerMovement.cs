using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public int playerNum;
    private Vector3 movementVec;
    private string leftCommand;
    private string rightCommand;
    private string upCommand;
    private string downCommand;
    public float speed;
    public Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        // define player input keys *TO CHANGE -> INPUT MANAGER
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
        // initialize movement vector
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
        rb.position += movementVec.normalized * Time.deltaTime * speed;
    }
}
