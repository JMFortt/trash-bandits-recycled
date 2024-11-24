using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PathingController : MonoBehaviour
{
    public float minX = -20f, maxX = 20f, minZ = -5f, maxZ = 30;
    public float currentX, currentZ;
    public float timer = 0f; 
    public float timerMax = 5f;
    //public float location1x = -20f;
    //public float location1z = 0.5f;
    //public float location2x = -30f;
    //public float location2z = -0.5f;
    //public float location3x = -30f;
    //public float location3z = -10f;
    //public int currentPos = 1;
    public Camera cam;
    public NavMeshAgent agent;

    // Start is called before the first frame update
    void Start()
    {
        currentX = Random.Range(minX, maxX);
        currentZ = Random.Range(minZ, maxZ);
        agent.SetDestination(new Vector3(currentX, transform.position.y, currentZ));
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= timerMax || ((transform.position.x == currentX) && (transform.position.z == currentZ)))
        {
            timer = 0f;
            timerMax = 7.5f;
            currentX = Random.Range(minX, maxX);
            currentZ = Random.Range(minZ, maxZ);
            agent.SetDestination(new Vector3(currentX, transform.position.y, currentZ));
        }

        //if ((currentPos == 1) && (transform.position.x == location1x) && (transform.position.z == location1z))
        //{
        //    currentPos = 2;
        //    agent.SetDestination(new Vector3(location2x, transform.position.y, location2z));
        //}
        //else if ((currentPos == 2) && (transform.position.x == location2x) && (transform.position.z == location2z))
        //{
        //    currentPos = 3;
        //    agent.SetDestination(new Vector3(location3x, transform.position.y, location3z));
        //}
        //else if ((currentPos == 3) && (transform.position.x == location3x) && (transform.position.z == location3z))
        //{
        //    currentPos = 1;
        //    agent.SetDestination(new Vector3(location1x, transform.position.y, location1z));
        //}
    }

    public void investigateNoise(float investigateX, float investigateZ)
    {
        currentX = investigateX;
        currentZ = investigateZ;
        agent.SetDestination(new Vector3(investigateX, transform.position.y, investigateZ));
        timer = 0f;
        timerMax = 15f;
    }
}
