using UnityEngine;

public class ControlFlow : MonoBehaviour
{
    public bool flag = true;
    public int powersOfTwo = 10;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if(flag)
        {
            Debug.Log("Boolean flag is set");
        } else
        {
            Debug.Log("Boolean flag isn't set");
        }

        float result;
        for(int i = 1; i <= powersOfTwo; i++)
        {
            result = Mathf.Pow(2, i);
            Debug.LogFormat("The {0} power of 2 is {1}.", i, result);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
