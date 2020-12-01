using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RPGM.Gameplay;
using UnityEngine;
using UnityEngine.U2D;

public class CharacterController : MonoBehaviour
{   
    Rigidbody2D rigidbody2d;
    float horizontal;
    float vertical;
    public float speed;
    public Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
        rigidbody2d = GetComponent<Rigidbody2D>();
    }

    
    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");

        
    }
    void FixedUpdate()
    {
        Vector2 position = rigidbody2d.position;
        position.x = position.x + horizontal * speed * Time.deltaTime;
        position.y = position.y + vertical * speed * Time.deltaTime;
        rigidbody2d.MovePosition(position);
    }
}
