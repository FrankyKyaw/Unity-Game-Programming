using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogManager : MonoBehaviour
{
    private Queue<string> sentences;
    private Queue<string> responses;
    public TextMeshProUGUI dialogText;
    public GameObject response1;
    public GameObject response2;
    private bool Haschoosen = false;

    void Start ()
    {
        
        
        response1.SetActive(false);
        response2.SetActive(false);
    }

    public void StartDialog(Dialog dialog)
    {
        sentences = new Queue<string>();
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
            ShowResponse();
            return;
        }

        string sentence = sentences.Dequeue();
        Debug.Log(sentence);
        dialogText.text = sentence;

    }
    void ShowResponse()
    {
        response1.SetActive(true);
        response2.SetActive(true);
    }
    public void ChooseResponse(Dialog dialog)
    {  
        if (Haschoosen == false)
        {
            responses = new Queue<string>();
            foreach (string sentence in dialog.responses)
            {
                responses.Enqueue(sentence);
            }
            Haschoosen = true;
        }    
    
        string response = responses.Dequeue();
        Debug.Log(response);
        dialogText.text = response;
        
    }

}
