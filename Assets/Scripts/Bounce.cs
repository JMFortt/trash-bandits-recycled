using UnityEngine;

public class Bounce : MonoBehaviour
{
    private float X, Y, Z;
    private int position = 0;
    private float timer = 1;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        X = -11.5f;
        Y = transform.position.y;
        Z = transform.position.z;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        // every second, move to other position
        if (timer > 1)
        {
            if (position == 0) 
            { 
                X = -11.5f;
                timer = 0f;
                position = 1;
            }

            else if (position == 1) 
            { 
                X = -8.5f;
                timer = 0f;
                position = 0;
            }
        }
        Debug.Log(X);
        GetComponent<Transform>().position = new Vector3(Mathf.Lerp(GetComponent<Transform>().position.x, X, 0.01f), Y, Z);
    }
}
