using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem.LowLevel;

public class PaddleBehavior : MonoBehaviour
{
    [SerializeField] private float _speed = 5.0f;
    [SerializeField] private KeyCode _up_key = KeyCode.UpArrow;
    [SerializeField] private KeyCode _down_key = KeyCode.DownArrow;

    private Rigidbody2D _rb;
    private float _direction;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        _rb.linearVelocityY = _direction * _speed;
    }
    // Update is called once per frame
    private void Update()
    {
        _direction = 0.0f;

        if (Input.GetKey(_up_key))
        {
            _direction += 1.0f;
        }

        if (Input.GetKey(_down_key))
        {
            _direction -= 1.0f;
        }
    }
}
