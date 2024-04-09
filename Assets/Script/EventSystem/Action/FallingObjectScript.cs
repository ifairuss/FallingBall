using System.Runtime.ConstrainedExecution;
using UnityEngine;


enum TypeObject
{
    None,
    Ball,
    Coin
}

public class FallingObjectScript : MonoBehaviour
{
    [Header("Components")]
    [SerializeField] private LayerMask CollisionMask;
    [SerializeField] private ParticleSystem _destroyParticle;
    [SerializeField] private Transform _newParent;

    [Header("Characteristics")]
    [SerializeField] private float _speedFalling = 2;

    [Header("VariableObject")]
    [SerializeField] private TypeObject _typeObject = 0;

    public static bool FallingObjectIsActive = false;

    private Rigidbody _body;
    private ObjectSpawner _spawner;

    private void Start()
    {
        _body = GetComponent<Rigidbody>();
        _spawner = FindObjectOfType<ObjectSpawner>();
    }

    private void Update()
    {
        if (FallingObjectIsActive == true)
        {
            Destroy(gameObject);
        }

        MoveFallingObject();
    }

    private void MoveFallingObject()
    {
        _speedFalling = ComplicationOfBallSpeed();

        _body.velocity = Vector3.down * _speedFalling;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (CollisionMask == (CollisionMask | (1 << collision.gameObject.layer)))
        {
            _destroyParticle.transform.SetParent(_newParent);
            Destroy(gameObject);
            _destroyParticle.Play();
            Destroy(_destroyParticle.gameObject, 1f);
            if (_typeObject == TypeObject.Coin)
            {
                Counter.CounterMoney++;
            }
            if (_typeObject == TypeObject.Ball)
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
            if (_typeObject == TypeObject.Coin)
            {
                Counter.CounterMoney--;
            }
            if (_typeObject == TypeObject.Ball)
            {
                Counter.CounterHealth--;
            }
        }
    }

    private float ComplicationOfBallSpeed()
    {
        if (_speedFalling < 5)
        {
            if (_spawner.Delay <= 2.5f) { _speedFalling = 4f;}
            if (_spawner.Delay <= 1.5f) { _speedFalling = 5f; }
        }
        else
        {
            _speedFalling = 5;
        }

        return _speedFalling;
    }
}
