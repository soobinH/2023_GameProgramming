using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class MonsterCtrl : MonoBehaviour
{
    GameObject Player;
    Transform player;
    float current = 0;
    int random = 1;
    public static int score = 0; // 점수

    void Start()
    {
        this.Player = GameObject.Find("Player");
        this.player = Player.GetComponent<Transform>();
    }

    void Update()
    {

        float dis = Vector3.Distance(transform.position, player.position); // 적 위치와 플레이어 위치 사이의 거리

        // 랜덤으로 플레이어 쫓아다님(중간에 딜레이를 줌)
        current += Time.deltaTime;

        if (current > 5)
        {
            random = Random.Range(1, 5);
            current = 0;
        }
        
        // 랜덤 변수가 1, 2일 때만 움직임
        if (random == 1 || random == 2)
        {
                KillPlayer();
        }


    }

    // 적 이동
    void KillPlayer()
    {
        float dirX = player.position.x - transform.position.x; // 적 오브젝트의 x - 플레이어 오브젝트의 x
        float dirY = player.position.y - transform.position.y; // 적 오브젝트의 y - 플레이어 오브젝트의 y



        // X축 방향 변환
        if(dirX < 0)
        {
            // 플레이어 오브젝트와의 거리가 0보다 작으면 -1 (왼쪽으로 이동)
            dirX = -1;
        }

        // 플레이어 오브젝트와의 거리가 0보다 크면 1 (오른쪽으로 이동)
        else if(dirX>0)
        {
            dirX = 1;
        }

        transform.Translate(new Vector2(dirX+0.7f, dirY+0.7f) * 2 * Time.deltaTime); // 적 이동

        // 진행 방향에 따라 오브젝트 방향 바꾸기
        if (dirX == -1)
        {
            transform.localScale = new Vector3(dirX, 1, 1);
        }

        else if (dirX == 1)
        {
            transform.localScale = new Vector3(dirX, 1, 1);
        }

    }

    // 점수 카운트
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag =="bullet")
        {
            score += 10; // 10점씩
            Debug.Log(score);
        }
    }


}
