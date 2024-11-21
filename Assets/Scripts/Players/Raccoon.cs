using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class Raccoon : MonoBehaviour
{
    [SerializeField] public int trash = 0;
    [SerializeField] public Collider raccoon_collider, trash_collider, den_collider, human_collider;
    [SerializeField] public Collision trash_collision;
    [SerializeField] public float trash_time = 0;
    [SerializeField] public PlayerMovement movement;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //TrashCan currentcan = trash_collider.GetComponent<TrashCan>();
        //Den den = den_collider.GetComponent<Den>();

        //if (Input.GetKeyUp(KeyCode.E))
        //{
        //    trash_time = 0;
        //    currentcan.progress_im.fillAmount = 0;
        //    currentcan.progressbar.SetActive(false);
        //}
    }

    private void OnCollisionStay(Collision collision)
    {
        collision.collider.TryGetComponent<TrashCan>(out TrashCan currentcan);
        //TrashCan currentcan = collision.collider.GetComponent<TrashCan>();
        Den den = den_collider.GetComponent<Den>();

        if (Input.GetKey(KeyCode.E) && (currentcan) && !currentcan.empty)
        {
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
            currentcan.progress_im.fillAmount = 0;
            currentcan.progressbar.SetActive(false);
        }
    }

    void OnTriggerEnter(Collider trigger)
    {
        if (trigger == human_collider)
        {
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
                movement.speed = 5f;
            }
        }
        if (collision.gameObject.GetType() == typeof(TrashCan))
        {
            GameObject.FindGameObjectWithTag("manager").GetComponent<AudioManager>().Play("trash");
        }
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
        EndScreen.Instance.trash += can.trash;
        EndScreen.Instance.trashcans += 1;

        trash += can.trash;
        movement.speed = Mathf.Max((movement.speed - (trash * 0.5f)), 0.1f);
        can.trash = 0;
        trash_time = 0;
        GameObject.FindGameObjectWithTag("manager").GetComponent<AudioManager>().Stop("trash");
    }
}
