using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DelayedDestroy : MonoBehaviour
{
    [SerializeField] private float _delayedDestroy;

    private void Awake()
    {
        Destroy(gameObject, _delayedDestroy);
    }
}
