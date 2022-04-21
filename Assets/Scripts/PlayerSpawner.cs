using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawner : MonoBehaviour
{

    [SerializeField]
    private GameObject _player;

    void Start()
    {
        Instantiate(_player);
    }
}
