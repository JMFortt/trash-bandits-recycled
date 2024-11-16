using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Raccoon : MonoBehaviour
{
    [SerializeField] public int trash = 0;
    [SerializeField] public Collider raccoon_collider, trash_collider, den_collider;
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
        TrashCan currentcan = trash_collider.GetComponent<TrashCan>();
        Den den = den_collider.GetComponent<Den>();

        if (Input.GetKeyUp(KeyCode.E))
        {
            trash_time = 0;
            currentcan.progress_im.fillAmount = 0;
            currentcan.progressbar.SetActive(false);
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        TrashCan currentcan = trash_collider.GetComponent<TrashCan>();
        Den den = den_collider.GetComponent<Den>();

        if (Input.GetKey(KeyCode.E) && (collision.collider == trash_collider) && !currentcan.empty)
        {
            trash_time += Time.deltaTime;
            currentcan.progressbar.SetActive(true);
            currentcan.progress_im.fillAmount = (trash_time / 3);

            if (trash_time >= 3)
            {
                CollectTrash();
            }
        }

        if (Input.GetKeyUp(KeyCode.E))
        {
            trash_time = 0;
            currentcan.progress_im.fillAmount = 0;
            currentcan.progressbar.SetActive(false);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.collider == den_collider)
        {
            TrashCan currentcan = trash_collider.GetComponent<TrashCan>();
            Den den = den_collider.GetComponent<Den>();

            if (trash > 0)
            {
                den.score += trash;
                trash = 0;
                movement.speed = 5f;
            }
        }
    }
    public void CollectTrash()
    {
        TrashCan currentcan = trash_collider.GetComponent<TrashCan>();
        trash += currentcan.trash;
        movement.speed = Mathf.Max((movement.speed - (trash * 0.5f)), 0.1f);
        currentcan.trash = 0;
        trash_time = 0;
    }
}
