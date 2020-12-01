using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RPGM.Gameplay;
using UnityEngine;
using UnityEngine.U2D;

public class CharacterController : MonoBehaviour
{   
    Rigidbody2D rigidbody2d;
    public Animator animator;
    void Start()
    {
        animator = GetComponent<Animator>();
        rigidbody2d = GetComponent<Rigidbody2D>();
    }

    
    void Update()
    {

        
    }

}
