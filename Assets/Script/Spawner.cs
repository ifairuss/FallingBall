using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using Unity.VisualScripting;
using UnityEditor;
using UnityEditor.iOS.Xcode;
using UnityEngine;
using UnityEngine.UI;
using static UnityEditor.Experimental.AssetDatabaseExperimental.AssetDatabaseCounters;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject[] _allSpawnPosition;
    [SerializeField] private GameObject[] _allBall;
    [SerializeField] private GameObject _spawnPosition;
    [SerializeField] private GameObject _ball;
    [SerializeField] private Text _timerSpawnBall;

    private Counter _counter;
    private GameObject Instance;

    [SerializeField] private float _delaySpawn;
    [SerializeField] private float _delay = 4f;

    private void Start()
    {
        _counter = FindObjectOfType<Counter>();
    }

    private void Update()
    {
        var spawnValue = Random.Range(0, _allSpawnPosition.Length);
        var ballValue = Random.Range(0, _allBall.Length);

        _timerSpawnBall.text = _delaySpawn.ToString();

        if (_delaySpawn <= 0f)
        {
            _ball = _allBall[ballValue];
            _spawnPosition = _allSpawnPosition[spawnValue];

            Instance = Instantiate(_ball, _spawnPosition.transform.position, Quaternion.identity);
            Instance.GetComponent<Ball>().Init(_counter);

            _delaySpawn = _delay;

        }
        else
        {
            _delaySpawn -= Time.deltaTime;
        }
    }
}
