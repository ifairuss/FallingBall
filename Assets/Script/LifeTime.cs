using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeTime : MonoBehaviour
{
    [SerializeField] private float _lifeTime;

    private void Update()
    {
        Destroy(gameObject, _lifeTime);
    }
}
