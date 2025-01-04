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
        // initialize camera position
        transform.position = new Vector3(((player1.transform.position.x + player2.transform.position.x) / 2), 25.0f, ((player1.transform.position.z + player2.transform.position.z) / 2));
        GetComponent<Camera>().orthographicSize = 20f;
    }

    // Update is called once per frame
    void Update()
    {
        if (cameraMovementEnabled)
        {
            // get distance between players
            float distance = Vector3.Distance(player1.transform.position, player2.transform.position);

            // zoom out (static)
            if (distance > 30)
            {
                GetComponent<Camera>().orthographicSize = Mathf.Lerp(GetComponent<Camera>().orthographicSize, 30f, 0.01f);
                transform.position = Vector3.Lerp(transform.position, new Vector3(0.0f, 25.0f, 15.0f), 0.05f);

            }
            // zoom in (follow)
            else
            {
                GetComponent<Camera>().orthographicSize = Mathf.Lerp(GetComponent<Camera>().orthographicSize, 15f, 0.01f);
                transform.position = Vector3.Lerp(transform.position, new Vector3(((player1.transform.position.x + player2.transform.position.x) / 2), 25.0f, ((player1.transform.position.z + player2.transform.position.z) / 2)), 0.05f);
            }
        }
    }
}
