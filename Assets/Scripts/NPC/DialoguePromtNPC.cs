using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialoguePromtNPC : MonoBehaviour
{
    [SerializeField] GameObject _dialoguePromt;
    bool _inPlayerProximity;

    GameObject _Dialogue;

    [SerializeField] string[] _firstDialogue;
    [SerializeField] string[] _secondDialogue;

    [SerializeField] string[] _firstTaskDoneDialogue;
    [SerializeField] string[] _secondTaskDoneDialogue;

    bool _hasTalkedToPlayer;
    bool _hasThankedThePlayer;

    [SerializeField] Task task;

    void Start()
    {
        _Dialogue = GameObject.Find("Canvas");
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == "Player")
        {
            _inPlayerProximity = true;
            _dialoguePromt.SetActive(true);
        }
    }

    void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.tag == "Player")
        {
            _inPlayerProximity = false;
            _dialoguePromt.SetActive(false);
        }
    }

    void Update()
    {
        if (_inPlayerProximity && Input.GetKeyDown("e"))
        {
            Talk();
        }
    }

    void Talk()
    {
        if (task != null && task.TaskDone == true && !_hasThankedThePlayer)
        {
            _hasThankedThePlayer = true;
            _Dialogue.SetActive(true);
            _Dialogue.GetComponent<Dialogue>().StartText(_firstTaskDoneDialogue);
        }
        else if (task != null && task.TaskDone == true)
        {
            _Dialogue.SetActive(true);
            _Dialogue.GetComponent<Dialogue>().StartText(_secondTaskDoneDialogue);
        }
        else if (!_hasTalkedToPlayer)
        {
            _hasTalkedToPlayer = true;
            _Dialogue.SetActive(true);
            _Dialogue.GetComponent<Dialogue>().StartText(_firstDialogue);
        }
        else
        {
            _Dialogue.SetActive(true);
            _Dialogue.GetComponent<Dialogue>().StartText(_secondDialogue);
        }
    }
}
