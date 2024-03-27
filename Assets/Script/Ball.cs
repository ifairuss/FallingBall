using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.PackageManager.UI;
using UnityEngine;

public class Balls : MonoBehaviour
{
    [SerializeField] private LayerMask _ball;
    [SerializeField] private ParticleSystem _destroyParticle;
    [SerializeField] private Transform _newParent;

    private Rigidbody _body;
    private Counter _counter;


    private void Start()
    {
        _body = GetComponent<Rigidbody>();
        _counter = GetComponentInParent<Counter>();

        _body.drag = Random.Range(0f, 3f);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (_ball == (_ball | (1 << collision.gameObject.layer)))
        {
            _destroyParticle.transform.SetParent(_newParent);
            Destroy(gameObject);
            _destroyParticle.Play();
            Destroy(_destroyParticle.gameObject, 1f);
            _counter._counter++;
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
            _counter._health--;
        }
    }

}
