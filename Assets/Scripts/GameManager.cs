using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public int scoreLeft = 0;
    public int scoreRight = 0;

    public TextMesh scoreLeftText;
    public TextMesh scoreRightText;

    public Ball ball;

    void Awake()
    {
        instance = this;
    }

    public void ScoreLeft()
    {
        scoreLeft++;
        UpdateScoreUI();
        ResetBall(-1);
    }

    public void ScoreRight()
    {
        scoreRight++;
        UpdateScoreUI();
        ResetBall(1);
    }

    void UpdateScoreUI()
    {
        scoreLeftText.text = scoreLeft.ToString();
        scoreRightText.text = scoreRight.ToString();
    }

    void ResetBall(int direction)
    {
        ball.transform.position = Vector2.zero;
        ball.GetComponent<Rigidbody2D>().velocity = Vector2.right * direction * ball.speed;
    }
}
