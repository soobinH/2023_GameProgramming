using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;

public class MonsterSpawn : MonoBehaviour
{
    bool CanSpawn = true;
    public GameObject Enemy; // 적 프리팹 저장
    GameObject Player;

    void Start()
    {
        this.Player = GameObject.Find("Player"); // 플레이어 오브젝트 받아옴
        InvokeRepeating("SpawnMonster", 2, 1); // 2초 후, 1초마다 SpawnMonster 함수 계속 호출
    }

    void SpawnMonster()
    {
        float X = Random.Range(-10f, 10f); // 적 생성할 X 좌표를 랜덤으로 지정

        // 랜덤 생성된 X 좌표가 플레이어와 가까울 경우 값 조정
        if (X <= Player.transform.position.x + 5 || X >= Player.transform.position.x-5)
            X += 6.0f;

        if (CanSpawn)
        {
            GameObject enemy = (GameObject)Instantiate(Enemy, new Vector3(X, 1.1f, 0f), Quaternion.identity); // 랜덤한 위치에서 적 생성
        }
    }
}
