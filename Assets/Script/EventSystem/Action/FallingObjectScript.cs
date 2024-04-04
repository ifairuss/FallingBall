using UnityEngine;

public class FallingObjectScript : MonoBehaviour
{
    [Header("Components")]
    [SerializeField] private LayerMask CollisionMask;
    [SerializeField] private ParticleSystem _destroyParticle;
    [SerializeField] private Transform _newParent;

    [Header("Characteristics")]
    [SerializeField] private int _value = 3;
    [SerializeField] private bool _isCoin = false;


    private Rigidbody _body;
    private Counter _counter;
    private ObjectSpawner _spawner;

    private void Start()
    {
        _body = GetComponent<Rigidbody>();
        _counter = FindObjectOfType<Counter>();
        _spawner = FindObjectOfType<ObjectSpawner>();

        ComplicationOfBallSpeed();

        _body.mass = _value;
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
                _counter.CoutnerMoney++;
            }
            else
            {
                _counter.CounterScore++;
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
                _counter.CoutnerMoney--;
            }
            else
            {
                _counter.CounterHealth--;
            }
        }
    }

    private void ComplicationOfBallSpeed()
    {
        if (_value > 14)
        {
           switch (_spawner.Delay)
           {
                case 3f:
                    _value = 4;
                    break;
                case 2.5f:
                    _value = 6;
                    break;
                case 2f:
                    _value = 8;
                    break;
                case 1.5f:
                    _value = 10;
                    break;
                case 1f:
                    _value = 12;
                    break;
                case 0.8f:
                    _value = 14;
                    break;
            }
        }
        else
        {
            _value = 14;
        }
    }
}
