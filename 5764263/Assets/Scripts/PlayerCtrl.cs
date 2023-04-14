using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;



public class PlayerCtrl : MonoBehaviour
{
    int moveSpeed = 5;

    Rigidbody2D rigidBody;
    Vector2 vector;

    int HP;

    // Start is called before the first frame update
    void Start()
    {
        this.rigidBody = GetComponent<Rigidbody2D>();
        this.HP = 100;
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMove();
        Debug.Log(this.HP);
    }

    void PlayerMove()
    {
        vector.x = Input.GetAxisRaw("Horizontal");
        vector.y = Input.GetAxisRaw("Vertical");

        rigidBody.velocity = vector * moveSpeed;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
    }
}

