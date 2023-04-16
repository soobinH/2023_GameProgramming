using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;

public class MonsterSpawn : MonoBehaviour
{
    bool CanSpawn = true;
    public GameObject Enemy; // �� ������ ����
    GameObject Player;

    void Start()
    {
        this.Player = GameObject.Find("Player"); // �÷��̾� ������Ʈ �޾ƿ�
        InvokeRepeating("SpawnMonster", 2, 1); // 2�� ��, 1�ʸ��� SpawnMonster �Լ� ��� ȣ��
    }

    void SpawnMonster()
    {
        float X = Random.Range(-10f, 10f); // �� ������ X ��ǥ�� �������� ����

        // ���� ������ X ��ǥ�� �÷��̾�� ����� ��� �� ����
        if (X <= Player.transform.position.x + 5 || X >= Player.transform.position.x-5)
            X += 6.0f;

        if (CanSpawn)
        {
            GameObject enemy = (GameObject)Instantiate(Enemy, new Vector3(X, 1.1f, 0f), Quaternion.identity); // ������ ��ġ���� �� ����
        }
    }
}
