using System;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class Raccoon : MonoBehaviour
{
    [SerializeField] public int trash = 0, trashcans = 0, total_trash = 0;
    [SerializeField] public Collider raccoon_collider, trash_collider, den_collider, human_collider;
    [SerializeField] public Collision trash_collision;
    [SerializeField] public float trash_time = 0, speed;
    [SerializeField] public PlayerMovement movement;
    [SerializeField] public TextMeshProUGUI tracker_text;
    [SerializeField] public TextMeshPro can1, can2, can3, can4, can5, can6;
    [SerializeField] public SpriteRenderer raccoon_render;
    [SerializeField] public Sprite raccoon_left, raccoon_right;

    public GameObject Homeowner;
    private bool isDead = false;
    public static Raccoon Instance;
    void Awake()
    {
        Instance = this;
        speed = movement.speed;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        isDead = false;
        tracker_text.text = "Trashcans Left: \n" + (6 - trashcans).ToString() + "/6";
        total_trash = Convert.ToInt32(can1.text) + Convert.ToInt32(can2.text) + Convert.ToInt32(can3.text)
            + Convert.ToInt32(can4.text) + Convert.ToInt32(can5.text) + Convert.ToInt32(can6.text);
    }

    // Update is called once per frame
    void Update()
    {
        if (Den.Instance.score == total_trash)
        {
            GameObject.FindGameObjectWithTag("manager").GetComponent<AudioManager>().Play("game_over_win");
            SceneManager.LoadScene("VictoryScreen");
        }
        //TrashCan currentcan = trash_collider.GetComponent<TrashCan>();
        //Den den = den_collider.GetComponent<Den>();

        //if (Input.GetKeyUp(KeyCode.E))
        //{
        //    trash_time = 0;
        //    currentcan.progress_im.fillAmount = 0;
        //    currentcan.progressbar.SetActive(false);
        //}
        if (Input.GetKeyDown(KeyCode.D))
        {
            raccoon_render.sprite = raccoon_right;
        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            raccoon_render.sprite = raccoon_left;
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        collision.collider.TryGetComponent<TrashCan>(out TrashCan currentcan);
        //TrashCan currentcan = collision.collider.GetComponent<TrashCan>();
        Den den = den_collider.GetComponent<Den>();

        if (Input.GetKey(KeyCode.E) && (currentcan) && !currentcan.empty && !isDead)
        {
            GameObject.FindGameObjectWithTag("manager").GetComponent<AudioManager>().Play("trash");
            Homeowner.GetComponent<PathingController>().investigateNoise(transform.position.x, transform.position.z);
            trash_time += Time.deltaTime;
            currentcan.progressbar.SetActive(true);
            currentcan.progress_im.fillAmount = (trash_time / 3);

            if (trash_time >= 3)
            {
                CollectTrash(currentcan);
                currentcan.progressbar.SetActive(false);
            }

            if (currentcan.empty) currentcan.progressbar.SetActive(false);
        }

        if (Input.GetKeyUp(KeyCode.E))
        {
            trash_time = 0;
            if (currentcan)
            {
                currentcan.progress_im.fillAmount = 0;
                currentcan.progressbar.SetActive(false);
            }
        }
    }

    void OnTriggerEnter(Collider trigger)
    {
        if (trigger == human_collider)
        {
            Debug.Log("collided with human");
            isDead = true;
            GameObject.FindGameObjectWithTag("manager").GetComponent<AudioManager>().Stop("trash");
            GameObject.FindGameObjectWithTag("manager").GetComponent<AudioManager>().Play("game_over_lose");
            SceneManager.LoadScene("EndScreen");
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        collision.collider.TryGetComponent<TrashCan>(out TrashCan currentcan);
        if (collision.collider == den_collider)
        {
            Den den = den_collider.GetComponent<Den>();

            if (trash > 0)
            {
                den.score += trash;
                trash = 0;
                movement.speed = speed;
                GameObject.FindGameObjectWithTag("manager").GetComponent<AudioManager>().Stop("trash");
            }
        }
        // if (currentcan)
        // {
        //     GameObject.FindGameObjectWithTag("manager").GetComponent<AudioManager>().Play("trash");
        // }
    }

    void OnCollisionExit(Collision collision) {

        collision.collider.TryGetComponent<TrashCan>(out TrashCan currentcan);

        if (currentcan) {
            GameObject.FindGameObjectWithTag("manager").GetComponent<AudioManager>().Stop("trash");
            currentcan.progress_im.fillAmount = 0;
            currentcan.progressbar.SetActive(false);
        }

        trash_time = 0;

    }
    public void CollectTrash(TrashCan can)
    {
        trash += can.trash;
        trashcans += 1;
        movement.speed = Mathf.Max((movement.speed - (trash * 0.2f)), 2f);
        tracker_text.text = "Trashcans Left: \n" + (6 - trashcans).ToString() + "/6";

        can.trash = 0;
        trash_time = 0;
        GameObject.FindGameObjectWithTag("manager").GetComponent<AudioManager>().Stop("trash");
    }
}
