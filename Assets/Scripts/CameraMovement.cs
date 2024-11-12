using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public bool cameraMovementEnabled = false;
    public GameObject player1;
    public GameObject player2;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (cameraMovementEnabled)
        {
            transform.position = new Vector3(((player1.transform.position.x + player2.transform.position.x) / 2), 25.0f, ((player1.transform.position.z + player2.transform.position.z) / 2));
        }
    }
}
