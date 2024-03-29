using UnityEngine;
using UnityEngine.UI;

public class Shot : MonoBehaviour
{
    [SerializeField] private GameObject _bullet;

    [SerializeField] private float _force;

    [SerializeField] private float _timerReloadGun = 1;

    [SerializeField] private Text _reloadTimerText;



    private void Update()
    {
        BulletSpawnProces();
    }

    private void BulletSpawnProces()
    {
        if (_timerReloadGun <= 0)
        {
            if (Input.GetMouseButtonDown(0))
            {
                var mousePos = Input.mousePosition;

                var ray = Camera.main.ScreenPointToRay(mousePos);

                var worldPos = Camera.main.ScreenToWorldPoint(mousePos);

                var bulletInstantiate = Instantiate(_bullet, worldPos, Quaternion.identity);

                var bulletRB = bulletInstantiate.GetComponent<Rigidbody>();

                if (bulletRB != null)
                {
                    bulletRB.AddForce(ray.direction * _force);
                }

                _timerReloadGun = 1f;
            }
        }
        else
        {
            _timerReloadGun -= Time.deltaTime;
            _timerReloadGun = Mathf.Max(_timerReloadGun, 0f);
        }

        _reloadTimerText.text = _timerReloadGun.ToString();
    }

 }
