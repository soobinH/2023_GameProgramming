using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ScorePrint : MonoBehaviour
{
    GameObject score;

    // Start is called before the first frame update
    void Start()
    {
        this.score = GameObject.Find("Score");
    }

    // Update is called once per frame
    void Update()
    {
        int Score = MonsterCtrl.score; // Monster Ctrl ��ũ��Ʈ�� score ���� �޾ƿ���(���� �޾ƿ���)

        score.GetComponent<Text>().text = "Your Score: " + Score.ToString() + " / 300"; // ȭ�鿡 ���� ǥ��


        // ������ 300���� �Ǹ� ���� Ŭ����
        if(Score>=300)
        {
            SceneManager.LoadScene("ClearScene");
        }

    }
}
