using TMPro;
using UnityEngine;

public class Den : MonoBehaviour
{
    [SerializeField] public int score = 0;
    [SerializeField] public TextMeshPro score_number;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        score_number.text = score.ToString();
    }
}
