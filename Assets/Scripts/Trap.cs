using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : MonoBehaviour
{
    [SerializeField]
    private GameObject _respawnPoint;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        collision.gameObject.transform.position = _respawnPoint.transform.position;
    }
}
