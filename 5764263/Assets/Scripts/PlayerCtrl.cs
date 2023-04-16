using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerCtrl : MonoBehaviour
{
    Rigidbody2D rigidBody;
    Vector2 vector;
    Transform Player;
    GameObject PrintHP;

    int HP = 3;

    const float moveSpeed = 5.0f; // �÷��̾� �̵� �ӵ�

    [SerializeField]
    GameObject bullet; // �Ѿ� ������Ʈ
    GameObject fireLoc; // �߻� ��ġ ������Ʈ

    bool canFire = true; // �߻� ���� ���� �Ǵ�
    const float fireDelay = 0.3f; // �Ѿ� �߻� ������ �ð�(��Ÿ��)
    float fireTimer = 0; // �Ѿ� �߻� �� �ð� ����


    // Start is called before the first frame update
    void Start()
    {
        this.rigidBody = GetComponent<Rigidbody2D>();
        this.Player = GetComponent<Transform>();
        this.fireLoc = GameObject.Find("FireLocation");
        this.PrintHP = GameObject.Find("HP");
   
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMove();
        FireControl();
        PlayerRotation();
        printHP();

        // HP �� ����� �� ���� ����
        if(HP <= 0)
        {
            SceneManager.LoadScene("GameoverScene");
        }
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
                    Instantiate(bullet, fireLoc.transform.position, fireLoc.transform.rotation);
            }


            fireTimer += Time.deltaTime;
        }
    }

    // �÷��̾� HP UI ���
    void printHP()
    {
        this.PrintHP.GetComponent<Text>().text = "X " + this.HP.ToString();
    }

    // ���� �浹 ó��
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // �浹�� ���
        if(collision.gameObject.tag == "Enemy")
        {
            HP--; // HP ����
            Destroy(collision.gameObject); // �ش� �� ������Ʈ ����
        }
    }
}


