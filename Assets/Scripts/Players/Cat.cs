using UnityEngine;
using UnityEngine.AI;

public class Cat : MonoBehaviour
{
    [SerializeField] public Collider cat_collider, human_collider;
    [SerializeField] public int caught = 0;
    [SerializeField] public float hold_time = 0, speed;
    [SerializeField] public NavMeshAgent human;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        speed = human.speed;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.M))
        {
            hold_time = 0;
            human.speed = speed;
        }
    }

    private void OnTriggerStay(Collider collider)
    {
        if (Input.GetKey(KeyCode.RightShift) && (collider.GetComponent<Collider>() == human_collider))
        {
            hold_time += Time.deltaTime;

            if (hold_time < 3)
            {
                GameObject.FindGameObjectWithTag("manager").GetComponent<AudioManager>().Play("cat_meow");
                human.speed = 0;
            } 
            else 
            {
                human.speed = speed;
            }
        }
    }

    void OnTriggerExit(Collider collider)
    {
        if (collider.GetComponent<Collider>() == human_collider)
        {
            hold_time = 0;
            human.speed = speed;
            GameObject.FindGameObjectWithTag("manager").GetComponent<AudioManager>().Stop("cat_meow");
        }
    }

}
