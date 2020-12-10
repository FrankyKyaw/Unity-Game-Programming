using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{
	public GameObject dialogBox;
	
	void Start()
	{
		dialogBox.SetActive(false);

	}

	public void DisplayDialog()
	{
		if(dialogBox.activeInHierarchy == false)
		{
			dialogBox.SetActive(true);
			
		}
		else
		{
			dialogBox.SetActive(false);
		}
		//source:https://answers.unity.com/questions/834134/why-does-unity-mean-with-cannot-implicitly-convert.html
		FindObjectOfType<DialogTrigger>().TriggerDialog();
		
	}
}
