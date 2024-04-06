using UnityEngine;

public class FallingObjectScript : MonoBehaviour
{
    [Header("Components")]
    [SerializeField] private LayerMask CollisionMask;
    [SerializeField] private ParticleSystem _destroyParticle;
    [SerializeField] private Transform _newParent;

    [Header("Characteristics")]
    [SerializeField] private int _value = 2;
    [SerializeField] private bool _isCoin = false;
    [SerializeField] private bool _isHearth = false;

    public static bool FallingObjectIsActive = false;

    private Rigidbody _body;
    private ObjectSpawner _spawner;

    private void Start()
    {
        _body = GetComponent<Rigidbody>();
        _spawner = FindObjectOfType<ObjectSpawner>();

        _value = ComplicationOfBallSpeed();
        _body.drag = _value;
    }

    private void Update()
    {
        if (FallingObjectIsActive == true)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (CollisionMask == (CollisionMask | (1 << collision.gameObject.layer)))
        {
            _destroyParticle.transform.SetParent(_newParent);
            Destroy(gameObject);
            _destroyParticle.Play();
            Destroy(_destroyParticle.gameObject, 1f);
            if (_isCoin == true)
            {
                Counter.CounterMoney++;
            }
            else if (_isHearth == true)
            {
                Counter.CounterHealth++;
            }
            else
            {
                Counter.CounterScore++;
            }

        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("GameOver"))
        {
            _destroyParticle.transform.SetParent(_newParent);
            Destroy(gameObject);
            _destroyParticle.Play();
            Destroy(_destroyParticle.gameObject, 1f);
            if (_isCoin == true)
            {
                Counter.CounterMoney--;
            }
            else
            {
                Counter.CounterHealth--;
            }
        }
    }

    private int ComplicationOfBallSpeed()
    {
        if (_value > 1)
        {
            if (_spawner.Delay <= 2.5f) { _value = 2;}
            if (_spawner.Delay <= 1.5f) { _value = 1; }
        }
        else
        {
            _value = 1;
        }

        return _value;
    }
}
