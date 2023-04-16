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

    const float moveSpeed = 5.0f; // 플레이어 이동 속도

    [SerializeField]
    GameObject bullet; // 총알 오브젝트
    GameObject fireLoc; // 발사 위치 오브젝트

    bool canFire = true; // 발사 가능 여부 판단
    const float fireDelay = 0.3f; // 총알 발사 딜레이 시간(쿨타임)
    float fireTimer = 0; // 총알 발사 후 시간 세기


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

        // HP 다 닳았을 떄 게임 오버
        if(HP <= 0)
        {
            SceneManager.LoadScene("GameoverScene");
        }
    }

    // 플레이어 이동
    void PlayerMove()
    {
        vector.x = Input.GetAxisRaw("Horizontal"); // 좌우 이동(A, D키)
        vector.y = Input.GetAxisRaw("Vertical"); // 상하 이동(W, S키)

        rigidBody.velocity = vector * moveSpeed; // 플레이어 이동
    }

    // 플레이어 각도 변환
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

    // 총 발사
    void FireControl()
    {
        if (canFire)
        {
            if (fireTimer > fireDelay)
            {
                // 클릭하면 총알 생성
                if (Input.GetMouseButtonDown(0))
                    Instantiate(bullet, fireLoc.transform.position, fireLoc.transform.rotation);
            }


            fireTimer += Time.deltaTime;
        }
    }

    // 플레이어 HP UI 출력
    void printHP()
    {
        this.PrintHP.GetComponent<Text>().text = "X " + this.HP.ToString();
    }

    // 적과 충돌 처리
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // 충돌할 경우
        if(collision.gameObject.tag == "Enemy")
        {
            HP--; // HP 감소
            Destroy(collision.gameObject); // 해당 적 오브젝트 삭제
        }
    }
}


