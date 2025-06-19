using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxBackgroundMovement : MonoBehaviour
{
    [SerializeField] GameObject Player;
    [SerializeField] float _parallaxStrength;
    [SerializeField] float _maxX;
    [SerializeField] float _minX;

    void Start()
    {
        Player = GameObject.Find("Player");

        transform.position = new Vector3(Player.transform.position.x / _parallaxStrength, transform.position.y, transform.position.z);
    }

    void Update()
    {
        float PlayerX = Player.transform.position.x;
        if (PlayerX < _maxX && PlayerX > _minX) transform.position = new Vector3(Player.transform.position.x / _parallaxStrength, transform.position.y, transform.position.z);
    }
}
