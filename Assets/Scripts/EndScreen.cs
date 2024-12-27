using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndScreen : MonoBehaviour
{
    [SerializeField] public TextMeshPro endtext;
    public static EndScreen Instance;

    void Awake()
    {
        Instance = this;
    }
    void Start()
    {
        endtext.text = "trash collected: \n " + Den.Instance.score.ToString() + "\ntrashcans robbed: \n" + Raccoon.Instance.trashcans.ToString() + "/6";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void EnterScene(string scenename)
    {
        SceneManager.LoadScene(scenename);
    }

}
