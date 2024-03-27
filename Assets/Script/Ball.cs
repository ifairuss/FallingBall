using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Balls : MonoBehaviour
{
    [SerializeField] private LayerMask _ball;
    [SerializeField] private ParticleSystem _destroyParticle;

    public float _speedBall = 2f;

    public Counter _count;
    public Rigidbody _body;

    private void Start()
    {
        _body = GetComponent<Rigidbody>();
        _count = FindObjectOfType<Counter>();

        _body.drag = Random.Range(0f, 3f);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (_ball == (_ball | (1 << collision.gameObject.layer)))
        {
            Instantiate(_destroyParticle, _body.transform.position, Quaternion.identity);

            Destroy(gameObject);

            _count._counter++;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("GameOver"))
        {
            Destroy(gameObject);

            _count._health--;
        }
    }

}
