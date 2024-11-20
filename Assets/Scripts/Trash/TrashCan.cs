using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TrashCan : MonoBehaviour
{
    [SerializeField] public int trash;
    [SerializeField] public TextMeshPro trash_number;

    [SerializeField] public GameObject progressbar, can_image;
    [SerializeField] public Image progress_im;
    [SerializeField] public bool empty = false;
    [SerializeField] private Material grey, red;

    void Start()
    {
        can_image.GetComponent<Renderer>().material = grey;

        trash = Random.Range(1, 5);
        trash_number.text = trash.ToString();
        progressbar.SetActive(false);
    }

    void Update()
    {
        trash_number.text = trash.ToString();

        if (trash == 0)
        {
            empty = true;
            can_image.GetComponent<Renderer>().material = red;
        }
    }

}
