using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private const float moveSpeed = 10.0f; // �Ѿ� �ӵ�

    void Update()
    {
        fireBullet();
    }

    // �Ѿ� �߻�
    void fireBullet()
    {

        float moveY = moveSpeed * Time.deltaTime; // ���ǵ�(Y������ �̵���)
        transform.Translate(0, moveY, 0); // �̵�

        Destroy(gameObject, 2.0f); // �߻�ǰ� 2�� �� ����
    }

    // �� �浹 ó��
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // ���� �ε����� �Ѿ�, �� ������Ʈ ����
        if(collision.gameObject.tag == "Enemy")
        {
            Debug.Log("collision");
            Destroy(this.gameObject);
            Destroy(collision.gameObject);

        }

    }
}
