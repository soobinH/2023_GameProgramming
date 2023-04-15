using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;



public class PlayerCtrl : MonoBehaviour
{
    Rigidbody2D rigidBody;
    Vector2 vector;
    Transform Player;

    public const float moveSpeed = 5.0f;

    public GameObject firePrefab;
    GameObject fireLoc;

    bool canFire = true;
    const float fireDelay = 0.5f; // �Ѿ� �߻� ������ �ð�(��Ÿ��)
    float fireTimer = 0; // �Ѿ� �߻� �� �ð� ����


    // Start is called before the first frame update
    void Start()
    {
        this.rigidBody = GetComponent<Rigidbody2D>();
        this.Player = GetComponent<Transform>();
        this.fireLoc = GameObject.Find("FireLocation");
   
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMove();
        FireControl();
        PlayerRotation();

    }

    // �÷��̾� �̵�
    void PlayerMove()
    {
        vector.x = Input.GetAxisRaw("Horizontal"); // �¿� �̵�(A, DŰ)
        vector.y = Input.GetAxisRaw("Vertical"); // ���� �̵�(W, SŰ)

        rigidBody.velocity = vector * moveSpeed; // �÷��̾� �̵�
    }

    // �÷��̾� ���� ��ȯ
    void PlayerRotation()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            Player.transform.localEulerAngles = new Vector3(0, 0, 180);
        }

        if (Input.GetKeyDown(KeyCode.W))
        {
            Player.transform.localEulerAngles = new Vector3(0, 0, 0);

        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            Player.transform.localEulerAngles = new Vector3(0, 0, 90);
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            Player.transform.localEulerAngles = new Vector3(0, 0, 270);
        }
    }

    // �� �߻�
    void FireControl()
    {
        if (canFire)
        {
            if (fireTimer > fireDelay)
            {
                // Ŭ���ϸ� �Ѿ� ����
                if (Input.GetMouseButtonDown(0))
                    Instantiate(firePrefab, fireLoc.transform.position, fireLoc.transform.rotation);
            }


            fireTimer += Time.deltaTime;
        }
    }
}


