using System.Collections;
using System.Collections.Generic;
using NUnit.Framework.Internal.Commands;
using UnityEngine;
using UnityEngine.AI;

public class PathingController : MonoBehaviour
{
    public float minX = -20f, maxX = 20f, minZ = -5f, maxZ = 30;
    public float currentX, currentZ;
    public float timer = 0f; 
    public float timerMax = 5f;
    public Animator animator;
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

        // sprite animation controller:
        if (!(transform.position.x == currentX) || !(transform.position.z == currentZ))
        {
            animator.Play("Walk");
        }
        else
        {
            animator.Play("Idle");
        }
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
