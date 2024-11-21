using TMPro;
using UnityEngine;

public class EndScreen : MonoBehaviour
{
    [SerializeField] public TextMeshPro endtext;
    [SerializeField] public int trash = 0, trashcans = 0;
    public static EndScreen Instance;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Instance = this;

        endtext.text = "trash collected: \n " + trash.ToString() + "\ntrashcans robbed: \n" + trashcans.ToString() + "/6";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
