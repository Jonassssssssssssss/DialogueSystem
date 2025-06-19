using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] GameObject Player;
    [SerializeField] float _maxX;
    [SerializeField] float _minX;

    void Update()
    {
        float PlayerX = Player.transform.position.x;
        if (PlayerX < _maxX && PlayerX > _minX) transform.position = new Vector3(Player.transform.position.x, transform.position.y, transform.position.z);
    }
}
