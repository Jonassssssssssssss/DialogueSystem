using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootEnemy : MonoBehaviour
{
    [SerializeField] GameObject _projectilePrefab;
    [SerializeField] float _attackSpeed;
    float reload;
    [SerializeField] float _firePower;

    [SerializeField] LookTowardsPlayer LTP;

    Transform _player;

    void Start()
    {
        _player = GameObject.Find("Player").GetComponent<Transform>();
    }

    void Update()
    {
        Aim();

        if (LTP._playerInProximity == true && reload <= 0f)
        {
            reload = _attackSpeed;
            Shoot();
        }

        if (reload > 0f) reload -= Time.deltaTime;
    }

    void Aim()
    {
        Vector2 lookDir = new Vector2(_player.position.x, _player.position.y) - new Vector2(transform.position.x, transform.position.y);
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;
        Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = q;
    }

    void Shoot()
    {
        GameObject projectile = Instantiate(_projectilePrefab, transform.position, transform.rotation);
        Rigidbody2D rb = projectile.GetComponent<Rigidbody2D>();
        rb.AddForce(transform.up * _firePower, ForceMode2D.Impulse);
    }
}
