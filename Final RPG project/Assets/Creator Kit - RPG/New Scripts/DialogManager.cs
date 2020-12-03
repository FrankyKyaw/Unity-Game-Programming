using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogManager : MonoBehaviour
{
    private Queue<string> sentences;
    void Start ()
    {
        sentences = new Queue<string>();
    }
    public void StartDialog(Dialog dialog)
    {
        Debug.Log("Starting conversation with" + dialog.name);

        sentences.Clear();

        foreach (string sentence in dialog.sentences)
        {
            sentences.Enqueue(sentence);
        }
    }
}
