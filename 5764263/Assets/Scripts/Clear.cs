using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clear : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // �ƹ� Ű�� ������ ����
        if(Input.anyKeyDown)
            Application.Quit();
    }
}