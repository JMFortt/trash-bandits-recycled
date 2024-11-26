using UnityEngine;
using UnityEngine.AI;

public class Cat : MonoBehaviour
{
    [SerializeField] public Collider cat_collider, human_collider;
    [SerializeField] public int caught = 0;
    [SerializeField] public float hold_time = 0, cooldown = 0,speed;
    [SerializeField] public NavMeshAgent human;
    private bool holding = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        speed = human.speed;
    }

    // Update is called once per frame
    void Update()
    {
        // ability timers
        if (holding)
        {
            hold_time += Time.deltaTime;
        }
        else
        {
            cooldown += Time.deltaTime;
        }

        // cancel ability early (lift key)
        if ((Input.GetKeyUp(KeyCode.RightShift)) && holding)
        {
            GameObject.FindGameObjectWithTag("manager").GetComponent<AudioManager>().Stop("cat_meow");
            holding = false;
            human.speed = speed;
            cooldown = 0;
        }
    }

    private void OnTriggerStay(Collider collider)
    {
        if (Input.GetKey(KeyCode.RightShift) && (collider.GetComponent<Collider>() == human_collider))
        {
            // initiate ability
            if (!holding)
            {
                if (cooldown >= 5)
                {
                    holding = true;
                    human.speed = 0;
                    hold_time = 0;
                }
            }
            // ability active
            else
            {
                // ability time not up (still going)
                if (hold_time < 3)
                {
                    GameObject.FindGameObjectWithTag("manager").GetComponent<AudioManager>().Play("cat_meow");
                }
                // ability time up (end)
                else
                {
                    holding = false;
                    human.speed = speed;
                    GameObject.FindGameObjectWithTag("manager").GetComponent<AudioManager>().Stop("cat_meow");
                    cooldown = 0;
                }
            }
        }
    }

    void OnTriggerExit(Collider collider)
    {
        // cancel ability early (leave LoS)
        if ((collider.GetComponent<Collider>() == human_collider) && holding)
        {
            holding = false;
            human.speed = speed;
            cooldown = 0;
            GameObject.FindGameObjectWithTag("manager").GetComponent<AudioManager>().Stop("cat_meow");
        }
    }

}
