using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogManager : MonoBehaviour
{
    private Queue<string> sentences;
    public TextMeshProUGUI dialogText;

    void Start ()
    {
        sentences = new Queue<string>();
    }

    public void StartDialog(Dialog dialog)
    {
        Debug.Log("Starting conversation with " + dialog.name);

        sentences.Clear();

        foreach (string sentence in dialog.sentences)
        {
            sentences.Enqueue(sentence);

        }
        DisplayNextSentence();
    }
    public void DisplayNextSentence()
    {
        if(sentences.Count == 0)
        {
            EndDialog();
            return;
        }

        string sentence = sentences.Dequeue();
        Debug.Log(sentence);
        dialogText.text = sentence;

    }
    void EndDialog()
    {
        Debug.Log("End of conversation");
    }
}
