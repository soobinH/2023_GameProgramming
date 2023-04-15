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
    const float fireDelay = 0.5f; // 총알 발사 딜레이 시간(쿨타임)
    float fireTimer = 0; // 총알 발사 후 시간 세기


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
                    Instantiate(firePrefab, fireLoc.transform.position, fireLoc.transform.rotation);
            }


            fireTimer += Time.deltaTime;
        }
    }
}


