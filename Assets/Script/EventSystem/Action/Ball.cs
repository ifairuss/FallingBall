using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] private LayerMask CollisionMask;
    [SerializeField] private ParticleSystem _destroyParticle;
    [SerializeField] private Transform _newParent;

    private Rigidbody _body;
    private Counter _counter;

    private void Start()
    {
        _body = GetComponent<Rigidbody>();
        _counter = FindObjectOfType<Counter>();

        _body.drag = Random.Range(0f, 3f);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (CollisionMask == (CollisionMask | (1 << collision.gameObject.layer)))
        {
            _destroyParticle.transform.SetParent(_newParent);
            Destroy(gameObject);
            _destroyParticle.Play();
            Destroy(_destroyParticle.gameObject, 1f);
            _counter.CounterScore++;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("GameOver"))
        {
            _destroyParticle.transform.SetParent(_newParent);
            Destroy(gameObject);
            _destroyParticle.Play();
            Destroy(_destroyParticle.gameObject, 1f);
            _counter.CounterHealth--;
        }
    }
}
