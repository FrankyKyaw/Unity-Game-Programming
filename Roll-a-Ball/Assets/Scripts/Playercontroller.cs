using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class Playercontroller : MonoBehaviour
{
    public float speed = 0;
    public TextMeshProUGUI countText;
    public GameObject winTextObject;
    public GameObject loseTextObject;
    private Rigidbody rb;
    private int count;
    private float movementX;
    private float movementY;
 

    // Start is called before the first frame update
    void Start()
    {
        count = 0;
        SetCountText();
        winTextObject.SetActive(false);
        loseTextObject.SetActive(false);
        rb = GetComponent<Rigidbody>();
    }

    void OnMove(InputValue movementValue) 
    {
       Vector2 movementVector = movementValue.Get<Vector2>();

       movementX = movementVector.x;
       movementY = movementVector.y;
 

    }
    void SetCountText()
    {
        countText.text = "Score: " + count.ToString();
        if(count >= 30)
        {
            winTextObject.SetActive(true);
        }
    }

    void FixedUpdate()
    {
        Vector3 movement = new Vector3(movementX, 0.0f, movementY);
        rb.AddForce(movement * speed);
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("PickUp")) 
        {
           other.gameObject.SetActive(false);
           count = count + 1;
           SetCountText();
        }
        if(other.gameObject.CompareTag("Ground"))
        {
             loseTextObject.SetActive(true);
             count = 0;
             SetCountText();
        }
        if(other.gameObject.CompareTag("Powerup"))
        {
            other.gameObject.SetActive(false);
            count = count + 5;
            SetCountText();
            transform.GetComponent<Renderer>().material.color= new Color
            (Random.Range(0f, 1f), 
             Random.Range(0f, 1f), 
             Random.Range(0f, 1f),
             Random.Range(0f, 1f));
        
        }
    }
       
}
