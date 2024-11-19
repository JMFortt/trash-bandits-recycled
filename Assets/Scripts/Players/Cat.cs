using UnityEngine;
using UnityEngine.AI;

public class Cat : MonoBehaviour
{
    [SerializeField] public Collider cat_collider, human_collider;
    [SerializeField] public int caught = 0;
    [SerializeField] public float hold_time = 0, speed;
    [SerializeField] public NavMeshAgent human;

    void Start()
    {
        speed = human.speed;
    }

    void Update()
    {
        
    }
    void OnCollisionEnter(Collision collision)
    {
        hold_time = 0;

        if (collision.collider == human_collider)
        {
            if (Input.GetKeyDown(KeyCode.M))
            {
                hold_time += Time.deltaTime;

                while (hold_time < 3)
                {
                    human.speed = 0;
                }

            }
            else if (Input.GetKeyUp(KeyCode.M))
            {
                hold_time = 0;
                human.speed = speed;
            }
        }
    }

}
