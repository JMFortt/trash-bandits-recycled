using TMPro;
using UnityEngine;

public class Den : MonoBehaviour
{
    [SerializeField] public int score = 0;
    [SerializeField] public TextMeshPro score_number;
    public static Den Instance;
    void Awake()
    {
        Instance = this;
    }
    void Start()
    {
        Instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        score_number.text = score.ToString();
    }
}
