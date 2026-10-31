using UnityEngine;

public class BallBehavior : MonoBehaviour
{
    [SerializeField] private float _launchForce = 8.0f;
    [SerializeField] private float _paddleInfluence = 0.4f;
    [SerializeField] private float _speedMultiplier = 1.1f;

    private Rigidbody2D _rb;

    private AudioSource _source;
    [SerializeField] private AudioClip _wallHit;
    [SerializeField] private AudioClip _paddleHit;
    [SerializeField] private AudioClip _scorePoint;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _source = GetComponent<AudioSource>();
        
        ResetBall();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Paddle"))
        {
            if(!Mathf.Approximately(collision.rigidbody.linearVelocityY, 0.0f))
            {
                Vector2 direction = _rb.linearVelocity * (1.0f - _paddleInfluence) + collision.rigidbody.linearVelocity * _paddleInfluence;
                _rb.linearVelocity = _rb.linearVelocity.magnitude * direction.normalized * _speedMultiplier;
            }
            _source.PlayOneShot(_paddleHit);
        } 
        else
        {
            _source.pitch = Random.Range(0.9f, 1.1f);
            _source.volume = Random.Range(0.8f, 1.0f);
            
            _source.clip = _wallHit;
            _source.Play();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameBehavior.Instance.ScorePoint(transform.position.x < 0 ? 1 : 0);

        _source.PlayOneShot(_scorePoint);

        ResetBall();
    }
    private void ResetBall()
    {
        _rb.linearVelocity = Vector2.zero;
        transform.position = Vector3.zero;

        Vector2 direction = Random.insideUnitCircle;

        if (Mathf.Abs(direction.x) < 0.25)
        {
            direction.x += 0.5f * Mathf.Sign(direction.y);
        }
        
        _rb.AddForce(direction.normalized * _launchForce, ForceMode2D.Impulse);
    }
}
