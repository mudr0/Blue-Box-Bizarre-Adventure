using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CircleCollider2D))]

public class Turret : MonoBehaviour
{
    [SerializeField] private float _visionRadius;
    [SerializeField] private float _reloadTime;
    [SerializeField] private GameObject _bullet;
    [SerializeField] private GameObject _ammoHead;

    private CircleCollider2D _visionCollider;
    private Transform _playerPos;

    private float _currentTime;

    private void Awake()
    {
        _visionCollider = GetComponent<CircleCollider2D>();
    }

    private void Start()
    {
        _visionCollider.radius = _visionRadius;
    }

    void Update()
    {
        if (_playerPos != null)
        {
            _currentTime += Time.deltaTime;
            var rotDirection = _playerPos.position - _ammoHead.transform.position;
            _ammoHead.transform.right = rotDirection;
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            _playerPos = collision.transform;
        }

    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (_currentTime >= _reloadTime && collision.gameObject.CompareTag("Player"))
        {
            _currentTime = 0;
            var bullet = Instantiate(_bullet, _ammoHead.transform);
            bullet.GetComponent<Bullet>().MoveBullet(_playerPos.position - bullet.transform.position);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            _playerPos = null;
        }
    }


}
