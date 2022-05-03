using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _lifeTime;
    [SerializeField] private float _damage;

    private GameObject _target;
    private Vector2 _position;
    private float _time;

    public GameObject Target { get => _target; set => _target = value; }

    private void Start()
    {
        _position = Target.transform.position;
    }

    void Update()
    {
        _time += Time.deltaTime;
        transform.position = Vector2.MoveTowards(transform.position, _position, _speed * Time.deltaTime);
        if(_time>= _lifeTime)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            var playerHealth = collision.GetComponent<PlayerHealthManager>();
            playerHealth.ChangeHealth(-_damage);
        }
        Destroy(gameObject);
    }
}
