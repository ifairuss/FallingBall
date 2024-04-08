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
    [SerializeField] private int _value = 2;

    [Header("VariableObject")]
    [SerializeField] private TypeObject _typeObject = 0;

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
