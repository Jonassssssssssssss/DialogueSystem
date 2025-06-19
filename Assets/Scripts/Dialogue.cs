using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;
using TMPro;

public class Dialogue : MonoBehaviour
{
    public string[] _dialogue;
    [SerializeField] TextMeshProUGUI _text;
    int index;

    [SerializeField] GameObject _parent;

    void Start()
    {
        //StartText(_dialogue);
    }

    public void StartText(string[] newDialogue)
    {
        _parent.SetActive(true);
        _dialogue = newDialogue;
        index = 0;
        ChangeText();
    }

    public void ChangeText()
    {
        if (index == _dialogue.Length)
        {
            _parent.SetActive(false);
        }
        else
        {
            _text.text = _dialogue[index];
            index++;
        }
    }
}
