using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem.LowLevel;

public class PaddleBehavior : MonoBehaviour
{
    private float move_speed = 5.0f;
    public KeyCode up_key = KeyCode.UpArrow;
    public KeyCode down_key = KeyCode.DownArrow;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
        
    }

    // Update is called once per frame
    private void Update()
    {
        float movement = 0.0f;

        if (Input.GetKey(up_key))
        {
            movement += move_speed;
        }

        if (Input.GetKey(down_key))
        {
            movement -= move_speed;
        }

        if (transform.position.y >= 3.5)
        {
            movement -= move_speed;
        }

        if (transform.position.y <= -3.5)
        {
            movement += move_speed;
        }
        movement *= Time.deltaTime;
        transform.Translate(0.0f, movement, 0.0f);
    }
}
