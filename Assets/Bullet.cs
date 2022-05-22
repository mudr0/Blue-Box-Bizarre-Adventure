using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]

public class Bullet : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _lifeTime;
    [SerializeField] private float _damage;

    private Rigidbody2D _rigidBody;
    private float _currentTime;

    private void Awake()
    {
        _rigidBody = GetComponent<Rigidbody2D>();
    }

    public void MoveBullet(Vector2 direction)
    {
        _rigidBody.AddForce(direction * _speed, ForceMode2D.Impulse);
    }

    private void Update()
    {
        _currentTime += Time.deltaTime;
        if (_currentTime >= _lifeTime)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<PlayerHealthManager>().ChangeHealth(-_damage);
        }
        Destroy(gameObject);
    }

}
