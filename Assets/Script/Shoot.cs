using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shoot : MonoBehaviour
{
    [SerializeField] private GameObject _progectile;

    [SerializeField] private float _force;

    [SerializeField] private double _timerReloadGun = 1;

    [SerializeField] private Text _reloadTimerText;



    private void Update()
    {
        SpawnBullet();
    }

    private void SpawnBullet()
    {
        if (_timerReloadGun <= 0)
        {
            if (Input.GetMouseButtonDown(0))
            {
                var mousePos = Input.mousePosition;

                var ray = Camera.main.ScreenPointToRay(mousePos);

                var worldPos = Camera.main.ScreenToWorldPoint(mousePos);

                var projectileInstance = Instantiate(_progectile, worldPos, Quaternion.identity);

                var projectileRB = projectileInstance.GetComponent<Rigidbody>();

                if (projectileRB != null)
                {
                    projectileRB.AddForce(ray.direction * _force);
                }

                _timerReloadGun = 1d;
            }
        }
        else
        {
            _timerReloadGun -= Time.deltaTime;
        }

        if (_timerReloadGun < 0)
        {
            _timerReloadGun = 0;
        }

        _reloadTimerText.text = _timerReloadGun.ToString();
    }

 }
