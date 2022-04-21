using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private float _speed;
    [SerializeReference]
    private float _jumpForce;
    [SerializeField]
    private LayerMask _groundLayerMask;
    

    private Vector2 vector;
    private Rigidbody2D rigidbody;
    private BoxCollider2D boxCollider;

    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        boxCollider = GetComponent<BoxCollider2D>();
    }

    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        vector.Set(horizontal, 0);
        transform.Translate(vector * Time.deltaTime * _speed);

        if (Input.GetKeyUp(KeyCode.Space) && IsGrounded())
        {
            rigidbody.AddForce(Vector2.up * _jumpForce, ForceMode2D.Impulse);
        }
    }

    private bool IsGrounded()
    {
        float distance = 1f;
        RaycastHit2D raycastHit = Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0f, Vector2.down, distance, _groundLayerMask);
        return raycastHit.collider != null;
    }
}
