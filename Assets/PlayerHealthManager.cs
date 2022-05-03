using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthManager : MonoBehaviour
{
    [SerializeField] private float _maxHealth;

    private float _currentHealth;

    void Start()
    {
        _currentHealth = _maxHealth;
    }

    public void ChangeHealth(float healthPoints)
    {
        _currentHealth += healthPoints;
        if(_currentHealth > _maxHealth)
            _currentHealth = _maxHealth;
        Debug.Log("HP: " + _currentHealth);
    }

    void Update()
    {
        if (_currentHealth <= 0)
        {
            Destroy(gameObject);
            Debug.Log("Вы проиграли...");
        }
    }
}
