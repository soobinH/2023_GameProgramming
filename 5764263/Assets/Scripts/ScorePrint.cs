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
        int Score = MonsterCtrl.score; // Monster Ctrl 스크립트의 score 변수 받아오기(점수 받아오기)

        score.GetComponent<Text>().text = "Your Score: " + Score.ToString() + " / 300"; // 화면에 점수 표시


        // 점수가 300점이 되면 게임 클리어
        if(Score>=300)
        {
            SceneManager.LoadScene("ClearScene");
        }

    }
}
