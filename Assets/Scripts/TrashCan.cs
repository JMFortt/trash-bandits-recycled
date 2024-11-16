using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TrashCan : MonoBehaviour
{
    [SerializeField] public int trash;
    [SerializeField] public TextMeshPro trash_number;
    //[SerializeField] public MeshRenderer trash_rend;

    [SerializeField] public GameObject progressbar;
    [SerializeField] public Image progress_im;
    [SerializeField] public bool empty = false;

    void Start()
    {
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
        }
    }

}
