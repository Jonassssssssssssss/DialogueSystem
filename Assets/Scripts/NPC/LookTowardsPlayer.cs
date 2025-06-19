using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookTowardsPlayer : MonoBehaviour
{
    GameObject Player;
    [SerializeField] GameObject _artSprite;
    
    public bool _playerInProximity;
    [SerializeField] bool _lookWhenPlayerIsInProximity;

    bool _NPCsInitialDirection;

    void Start()
    {
        Player = GameObject.Find("Player");
        _NPCsInitialDirection = _artSprite.GetComponent<SpriteRenderer>().flipX;
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == "Player")
        {
            _playerInProximity = true;
        }
    }

    void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.tag == "Player")
        {
            _playerInProximity = false;
        }
    }

    void Update()
    {
        if (_lookWhenPlayerIsInProximity)
        {
            if (_playerInProximity)
            {
                UpdateDirection();
            }
            else
            {
                _artSprite.GetComponent<SpriteRenderer>().flipX = _NPCsInitialDirection;
            }
        }
        else
        {
            UpdateDirection();
        }
    }

    void UpdateDirection()
    {
        if (Player.transform.position.x < _artSprite.transform.position.x)
        {
            _artSprite.GetComponent<SpriteRenderer>().flipX = false;
        }
        else
        {
            _artSprite.GetComponent<SpriteRenderer>().flipX = true;
        }
    }
}
