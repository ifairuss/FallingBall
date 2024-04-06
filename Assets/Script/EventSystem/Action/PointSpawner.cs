using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PointSpawner : MonoBehaviour
{
    [Header("Bonus")]
    [SerializeField] private List<GameObject> _allObject = new List<GameObject>();

    private GameObject _ball;

    private void Awake()
    {
        var ballValue = Random.Range(0, _allObject.Count);

        _ball = _allObject[ballValue];

        Instantiate(_ball, this.transform.position, Quaternion.identity);
    }
}
