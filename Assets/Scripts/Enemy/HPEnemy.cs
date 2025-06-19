using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HPEnemy : MonoBehaviour
{
    [SerializeField] float _maxHP = 5f;
    [SerializeField] float _HP;

    [SerializeField] bool NoDie;
    [SerializeField] GameObject _parent;

    public bool _defeated;

    void Start()
    {
        _HP = _maxHP;
    }

    /*
    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == "OutOfWorld")
        {
            Death();
        }
    }
    */

    void Update()
    {
        if (_HP <= 0) Death();
    }

    public void TakeDamage(float damage)
    {
        _HP -= damage;
    }

    public void Death()
    {
        if (!NoDie)
        {
            Destroy(_parent);
        }
        else
        {
            _defeated = true;
        }
    }
}
