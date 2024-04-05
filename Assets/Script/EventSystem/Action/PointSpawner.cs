using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointSpawner : MonoBehaviour
{
    [Header("Ball")]
    [SerializeField] private GameObject[] _allBall;

    private GameObject _ball;

    private void Awake()
    {
        var ballValue = Random.Range(0, _allBall.Length);

        _ball = _allBall[ballValue];

        Instantiate(_ball, this.transform.position, Quaternion.identity);
    }
}
