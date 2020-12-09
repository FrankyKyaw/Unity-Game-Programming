using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarriorMovement : MonoBehaviour
{
    public float speed;
    int direction = 1;
    public float changeTime = 3.0f;

    Animator animator;
    float timer;
    Rigidbody2D rigidbody2d;
    
    void Start()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        
    }

    void Update()
    {
        timer -=Time.deltaTime;
        if(timer < 0)
        {
            direction = -direction;
            timer = changeTime;
        }
    }
    void FixedUpdate()
    {
        Vector2 position = rigidbody2d.position;

        animator.SetFloat("Move X", direction);
        animator.SetFloat("Move Y", 0);

        position.x = position.x + Time.deltaTime * speed * direction;

        rigidbody2d.MovePosition(position);
    }
}
