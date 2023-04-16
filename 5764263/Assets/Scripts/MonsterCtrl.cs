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
    public static int score = 0; // ����

    void Start()
    {
        this.Player = GameObject.Find("Player");
        this.player = Player.GetComponent<Transform>();
    }

    void Update()
    {

        float dis = Vector3.Distance(transform.position, player.position); // �� ��ġ�� �÷��̾� ��ġ ������ �Ÿ�

        // �������� �÷��̾� �Ѿƴٴ�(�߰��� �����̸� ��)
        current += Time.deltaTime;

        if (current > 5)
        {
            random = Random.Range(1, 5);
            current = 0;
        }
        
        // ���� ������ 1, 2�� ���� ������
        if (random == 1 || random == 2)
        {
                KillPlayer();
        }


    }

    // �� �̵�
    void KillPlayer()
    {
        float dirX = player.position.x - transform.position.x; // �� ������Ʈ�� x - �÷��̾� ������Ʈ�� x
        float dirY = player.position.y - transform.position.y; // �� ������Ʈ�� y - �÷��̾� ������Ʈ�� y



        // X�� ���� ��ȯ
        if(dirX < 0)
        {
            // �÷��̾� ������Ʈ���� �Ÿ��� 0���� ������ -1 (�������� �̵�)
            dirX = -1;
        }

        // �÷��̾� ������Ʈ���� �Ÿ��� 0���� ũ�� 1 (���������� �̵�)
        else if(dirX>0)
        {
            dirX = 1;
        }

        transform.Translate(new Vector2(dirX+0.7f, dirY+0.7f) * 2 * Time.deltaTime); // �� �̵�

        // ���� ���⿡ ���� ������Ʈ ���� �ٲٱ�
        if (dirX == -1)
        {
            transform.localScale = new Vector3(dirX, 1, 1);
        }

        else if (dirX == 1)
        {
            transform.localScale = new Vector3(dirX, 1, 1);
        }

    }

    // ���� ī��Ʈ
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag =="bullet")
        {
            score += 10; // 10����
            Debug.Log(score);
        }
    }


}
