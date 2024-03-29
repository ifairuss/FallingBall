using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.PackageManager.UI;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] private LayerMask _ball;
    [SerializeField] private ParticleSystem _destroyParticle;
    [SerializeField] private Transform _newParent;

    private Rigidbody _body;

    private bool _destroyTheBallWithSpikes = false;
    private bool _destroyTheBallWithBullet = false;

    private void Start()
    {
        _body = GetComponent<Rigidbody>();

        _body.drag = Random.Range(0f, 3f);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (_ball == (_ball | (1 << collision.gameObject.layer)))
        {
            _destroyTheBallWithBullet = true;
            _destroyParticle.transform.SetParent(_newParent);
            Destroy(gameObject);
            _destroyParticle.Play();
            Destroy(_destroyParticle.gameObject, 1f);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("GameOver"))
        {
            _destroyTheBallWithSpikes = true;
            _destroyParticle.transform.SetParent(_newParent);
            Destroy(gameObject);
            _destroyParticle.Play();
            Destroy(_destroyParticle.gameObject, 1f);
        }
    }
 
    public void Init(Counter _counter)
    {
        _counter.CounterHealth--;
    }
}
