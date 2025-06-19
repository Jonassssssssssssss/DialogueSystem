using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorPuzzle : MonoBehaviour
{
    [SerializeField] GameObject[] _souls;
    [SerializeField] int _soulsActive = 0;
    [SerializeField] GameObject[] _lights;

    [SerializeField] GameObject _door;

    bool _puzzleSolved;

    void Update()
    {
        if (!_puzzleSolved) _soulsActive = UpdateSouls();

        if (Input.GetKeyDown("g")) _lights[0].SetActive(true);

        if (_soulsActive == _souls.Length && !_puzzleSolved)
        {
            SolvePuzzle();
        }
    }

    void SolvePuzzle()
    {
        _puzzleSolved = true;

        _door.SetActive(false);

        foreach (GameObject soul in _souls)
        {
            Destroy(soul);
        }

        UpdateSouls();
    }

    int UpdateSouls()
    {
        int _CheckSoulsActive = 0;

        foreach (GameObject soul in _souls)
        {
            if (soul.GetComponentInChildren<HPEnemy>()._defeated == true) _CheckSoulsActive++;
        }


        foreach (GameObject light in _lights)
        {
            light.SetActive(false);
        }

        for (int i = _CheckSoulsActive; i < 0; i--)
        {
            if (_CheckSoulsActive >= 1)
            {
                _lights[i].SetActive(true);
                Debug.Log("1");
            }
        }

        return _CheckSoulsActive;
    }
}
