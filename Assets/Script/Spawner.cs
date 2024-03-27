using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.UI;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject[] _allSpawnPosition;
    [SerializeField] private GameObject[] _allBall;
    [SerializeField] private GameObject _spawnPosition;
    [SerializeField] private GameObject _ball;
    [SerializeField] private Text _timerSpawnBall;

    [SerializeField] private float _delaySpawn;
    [SerializeField] private float _delay = 4f;

    private Counter _counter;

    private int _complication = 10;

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

            Instantiate(_ball, _spawnPosition.transform.position, Quaternion.identity);

            _delaySpawn = _delay;

        }
        else
        {
            _delaySpawn -= Time.deltaTime;
        }

        if(_counter._counter == _complication)
        {
            if(_delay > 0.5f)
            {
                _delay -= 0.2f;
                _complication += Random.Range(5, 10);

            }
            else
            {
                _delay = 0.5f;
            }
        }
    }
}
