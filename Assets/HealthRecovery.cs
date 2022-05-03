using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthRecovery : MonoBehaviour
{
    [SerializeField] private float _healthPoints;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            var playerHealth = collision.GetComponent<PlayerHealthManager>();
            playerHealth.ChangeHealth(_healthPoints);
        }
        Destroy(gameObject);
    }
}
