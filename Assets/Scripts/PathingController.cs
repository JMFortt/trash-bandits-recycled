using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PathingController : MonoBehaviour
{
    private float location1x = -15f;
    private float location1z = 15f;
    private float location2x = -12.5f;
    private float location2z = -5f;
    private float location3x = -5f;
    private float location3z = 15f;
    public int currentPos = 1;
    public Camera cam;
    public NavMeshAgent agent;

    // Start is called before the first frame update
    void Start()
    {
        agent.SetDestination(new Vector3(location1x, transform.position.y, location1z));
    }

    // Update is called once per frame
    void Update()
    {
        if ((currentPos == 1) && (transform.position.x == location1x) && (transform.position.z == location1z))
        {
            currentPos = 2;
            agent.SetDestination(new Vector3(location2x, transform.position.y, location2z));
        }
        else if ((currentPos == 2) && (transform.position.x == location2x) && (transform.position.z == location2z))
        {
            currentPos = 3;
            agent.SetDestination(new Vector3(location3x, transform.position.y, location3z));
        }
        else if ((currentPos == 3) && (transform.position.x == location3x) && (transform.position.z == location3z))
        {
            currentPos = 1;
            agent.SetDestination(new Vector3(location1x, transform.position.y, location1z));
        }
    }
}
