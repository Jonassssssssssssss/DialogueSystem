using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHP : MonoBehaviour
{
    Vector3 Spawnpoint;

    public float MaxHP = 10f;
    public float HP;

    void Start()
    {
        HP = MaxHP;
        Spawnpoint = transform.position;
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == "OutOfWorld")
        {
            Death();
        }
    }

    void Update()
    {
        if (HP <= 0) Death();
    }

    public void TakeDamage(float damage)
    {
        HP -= damage;
    }

    public void Death()
    {
        transform.position = Spawnpoint;
    }
}
