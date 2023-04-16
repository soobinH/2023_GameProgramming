using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Title : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // 아무 키나 누르면 게임 시작
        if (Input.anyKeyDown)
            SceneManager.LoadScene("GameScene");
    }
}
