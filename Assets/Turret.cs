using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    [SerializeField] private float _reloadTime;
    [SerializeField] private Bullet _bullet;

    private float _time;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (_time >= _reloadTime && collision.gameObject.CompareTag("Player"))
        {
            _time = 0;
            var bullet = Instantiate(_bullet, transform);
            bullet.Target = collision.gameObject;
        }
    }

    // Update is called once per frame
    void Update()
    {
        _time += Time.deltaTime;
    }
}
