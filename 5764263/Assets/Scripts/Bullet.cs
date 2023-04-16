using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private const float moveSpeed = 10.0f; // 총알 속도

    void Update()
    {
        fireBullet();
    }

    // 총알 발사
    void fireBullet()
    {

        float moveY = moveSpeed * Time.deltaTime; // 스피드(Y축으로 이동함)
        transform.Translate(0, moveY, 0); // 이동

        Destroy(gameObject, 2.0f); // 발사되고 2초 뒤 삭제
    }

    // 적 충돌 처리
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // 적과 부딪히면 총알, 적 오브젝트 삭제
        if(collision.gameObject.tag == "Enemy")
        {
            Debug.Log("collision");
            Destroy(this.gameObject);
            Destroy(collision.gameObject);

        }

    }
}
