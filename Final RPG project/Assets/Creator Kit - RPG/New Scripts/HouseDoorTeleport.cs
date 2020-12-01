using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HouseDoorTeleport : MonoBehaviour
{
    public GameObject MainCharacter;
    bool m_IsPlayerAtDoor = false;

    void Start()
    {
        
    }

    void Update()
    {
        if(m_IsPlayerAtDoor)
        {
            SceneManager.LoadScene("HouseInterior");
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Player")
        {
            m_IsPlayerAtDoor = true;    
        }
    }
}
