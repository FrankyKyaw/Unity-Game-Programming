using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RPGM.Gameplay;
using UnityEngine;
using UnityEngine.U2D;
using TMPro;

public class CharacterController : MonoBehaviour
{   
    Rigidbody2D rigidbody2d;
    public Animator animator;

    float horizontal;
    float vertical;
    public float speed;
    Vector2 moveDirection = new Vector2(1,0);
    private int count;
    public TextMeshProUGUI countText;

    void Start()
    {
        animator = GetComponent<Animator>();
        rigidbody2d = GetComponent<Rigidbody2D>();
        SetCountText();
    }

    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            RaycastHit2D hit = Physics2D.Raycast(rigidbody2d.position + Vector2.up * 0.2f, moveDirection, 1.5f, LayerMask.GetMask("NPC"));
            if (hit.collider != null)
            {
                NPC character = hit.collider.GetComponent<NPC>();
                if (character != null)
                {
                    character.DisplayDialog();
                }  
            }
        }

        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");

        

        if(horizontal > 0)
        {
            vertical = 0;

        }
        else if(horizontal < 0)
        {
            vertical = 0;
        }
        else if(vertical > 0)
        {
            horizontal = 0;
        }
        else if(vertical <0)
        {
            horizontal = 0;
        }

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
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("QuestItems"))
        {
            other.gameObject.SetActive(false);
            count = count + 1;
            SetCountText();
        }
    }
    void SetCountText()
    {
        countText.text = "Chickens: " + count.ToString();

    }

}
