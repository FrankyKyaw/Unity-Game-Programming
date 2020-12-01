using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RPGM.Gameplay;
using UnityEngine;
using UnityEngine.U2D;

public class CharacterMovement : MonoBehaviour
{   
    Rigidbody2D rigidbody2d;
    float horizontal;
    float vertical;
    public float speed;

    public Animator animator;
    Vector2 moveDirection = new Vector2(1,0);

    void Start()
    {
        animator = GetComponent<Animator>();
        rigidbody2d = GetComponent<Rigidbody2D>();
    }

    
    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");

        Vector2 move = new Vector2(horizontal, vertical);

        if(!Mathf.Approximately(move.x, 0.0f) || !Mathf.Approximately(move.y, 0.0f))
        {
            moveDirection.Set(move.x, move.y);
            moveDirection.Normalize();
        }
        
        animator.SetFloat("Move X", moveDirection.x);
        animator.SetFloat("Move Y", moveDirection.y);
        animator.SetFloat("Speed", move.magnitude);

        
    }
    void FixedUpdate()
    {
        Vector2 position = rigidbody2d.position;
        position.x = position.x + horizontal * speed * Time.deltaTime;
        position.y = position.y + vertical * speed * Time.deltaTime;

        rigidbody2d.MovePosition(position);
    }
}
