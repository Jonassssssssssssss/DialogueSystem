using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementPlayer : MonoBehaviour
{
    [SerializeField] float Speed = 1f;
    [SerializeField] float _jumpHeight = 10f;
    Rigidbody2D RB;

    [SerializeField] Transform _groundPoint;
    [SerializeField] float _groundDistance = 0.4f;
    [SerializeField] LayerMask _groundLayer;

    [SerializeField] SpriteRenderer _artSprite;

    void Start()
    {
        RB = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        float speed = Speed * Time.deltaTime;

        if (Input.GetKey("a")) Move(-speed);
        if (Input.GetKey("d")) Move(speed);

        if (Input.GetKeyDown(KeyCode.Space)) Jump();
    }

    void Move(float X)
    {
        transform.position = new Vector2(transform.position.x + X, transform.position.y);
        if (X < 0)
        {
            //_artSprite.flipX = true;
            transform.localScale = new Vector3(-1f, 1f, 1f);
        }
        else
        {
            //_artSprite.flipX = false;
            transform.localScale = new Vector3(1f, 1f, 1f);
        }
    }

    void Jump()
    {
        if (GroundCheck() == true) RB.velocity = new Vector2(0f, _jumpHeight);
    }

    bool GroundCheck()
    {
        bool _groundCheck = false;

        _groundCheck = Physics2D.OverlapCircle(_groundPoint.position, _groundDistance, _groundLayer);

        return _groundCheck;
    }
}
