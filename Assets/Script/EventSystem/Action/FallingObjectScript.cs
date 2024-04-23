using System.Net.NetworkInformation;
using System.Runtime.ConstrainedExecution;
using UnityEngine;


enum TypeObject
{
    None,
    Ball,
    Coin,
    Heart
}

public class FallingObjectScript : SFXManager
{
    [Header("Components")]
    [SerializeField] private LayerMask CollisionMask;
    [SerializeField] private ParticleSystem _destroyParticle;
    [SerializeField] private Transform _newParent;

    [Header("Characteristics")]
    public float monitoringSpeed;
    public static float _speedFalling = 2;

    [Header("VariableObject")]
    [SerializeField] private TypeObject _typeObject = 0;

    public static bool FallingObjectIsActive = false;

    private Rigidbody _body;

    private void Start()
    {
        _body = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        monitoringSpeed = _speedFalling;

        if (FallingObjectIsActive == true)
        {
            Destroy(gameObject);
        }

        AdsResumeGame();
        MoveFallingObject();
    }

    private void MoveFallingObject()
    {
        _speedFalling = ComplicationOfBallSpeed();

        _body.velocity = Vector3.down * _speedFalling;
    }

    private void AdsResumeGame()
    {
        if (ButtonManagerMainGame._resume == true)
        {
            _destroyParticle.transform.SetParent(_newParent);
            Destroy(gameObject);
            _destroyParticle.Play();
            Destroy(_destroyParticle.gameObject, 1f);
            if (_typeObject == TypeObject.Coin)
            {
                PlaySFX(_allClips[0], destroy: true, pinch: 1.3f);
                Counter.CounterMoney++;
            }
            if (_typeObject == TypeObject.Ball)
            {
                PlaySFX(_allClips[0], destroy: true);
                Counter.CounterScore++;
            }
            if (_typeObject == TypeObject.Heart)
            {
                PlaySFX(_allClips[0], destroy: true, pinch: 1.3f);
                if (Counter.CounterHealth < 2)
                {
                    Counter.CounterHealth++;
                }
                else
                {
                    Counter.CounterScore++;
                    Counter.CounterHealth = Mathf.Max(Counter.CounterHealth, 2);
                }
            }
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
                PlaySFX(_allClips[0], destroy: true, pinch: 1.3f);
                Counter.CounterMoney++;
            }
            if (_typeObject == TypeObject.Ball)
            {
                PlaySFX(_allClips[0], destroy: true, pinch: 0.3f, pinchTwo: 0.6f, volume: 0.7f);
                Counter.CounterScore++;
            }
            if (_typeObject == TypeObject.Heart)
            {
                PlaySFX(_allClips[0], destroy: true, pinch: 1.3f);
                if (Counter.CounterHealth < 2)
                {
                    Counter.CounterHealth++;
                }
                else
                {
                    Counter.CounterScore++;
                    Counter.CounterHealth = Mathf.Max(Counter.CounterHealth, 2);
                }
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
                PlaySFX(_allClips[0], destroy: true);
                Counter.CounterMoney--;
            }
            if (_typeObject == TypeObject.Ball)
            {
                PlaySFX(_allClips[0], destroy: true);
                Counter.CounterHealth--;
            }
            if (_typeObject == TypeObject.Heart)
            {
                PlaySFX(_allClips[0], destroy: true);
                Counter.CounterScore--;
            }
        }
    }

    private float ComplicationOfBallSpeed()
    {
        if (_speedFalling < 6)
        {
            _speedFalling += 0.01f * Time.deltaTime;
        }
        else
        {
            _speedFalling = 6;
        }

        return _speedFalling;
    }
}
