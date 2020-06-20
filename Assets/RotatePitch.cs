using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RotatePitch : MonoBehaviour
{
    public int rotateSpeed;
    float startTime;
    int run=0, wicket=0;
    public Text scoreText;
    public Text overText;
    public Text targetText;
    public Text winningText;
    public Text ballLength;
    public Text tossText;
    public float fillPowerBat;
    public float fillPowerBall;
    public Image powerBat;
    public Image powerBall;
    public Button restartGame;
    public GameObject winningScreen;
    float powerChangerBat;
    float powerChangerBall;
    public GameObject target;
    public GameObject popUpScore;
    public GameObject ball;
    public GameObject bowl;
    public GameObject hitMoodBtn;
    public GameObject tossCoin;
    public GameObject tossScreen;
    bool fillDirectionBat = true;
    bool fillDirectionBall = true;
    string hitMood="balance";
    string ballDelivery;
    int total_balls = 0;
    int targetScore = 0;
    [HideInInspector]
    public bool batPlayer=false;
    private string team1, team2;


    void Start()
    {
        rotateSpeed = 0;
        startTime = Time.time;
    }
    private void Update()
    {
        PowerAccuracyBat();
        PowerAccuracyBall();
        powerBat.fillAmount = fillPowerBat;
        powerBall.fillAmount = fillPowerBall;
        Rotate();
    }

    public void PowerAccuracyBat()
    {
        if (fillDirectionBat)
        {
            if (fillPowerBat <= 0.82)
            {
                fillPowerBat += powerChangerBat * Time.deltaTime*120;
            }
            else
            {
                fillDirectionBat = false;
            }
        }
        else
        {
            if (fillPowerBat >= 0.12)
            {
                fillPowerBat -= powerChangerBat * Time.deltaTime*120;
            }
            else
            {
                fillDirectionBat = true;
            }
        }
        
    }
    public void PowerAccuracyBall()
    {
        if (fillDirectionBall)
        {
            if (fillPowerBall <= 0.82)
            {
                fillPowerBall += powerChangerBall * Time.deltaTime * 120;
            }
            else
            {
                fillDirectionBall = false;
            }
        }
        else
        {
            if (fillPowerBall >= 0.12)
            {
                fillPowerBall -= powerChangerBall * Time.deltaTime * 120;
            }
            else
            {
                fillDirectionBall = true;
            }
        }

    }
    public void Rotate()
    {
            transform.Rotate(0, 0, rotateSpeed * Time.deltaTime * 360, Space.World);

            if (Time.time - startTime >= 4)
            {
            rotateSpeed = 0;
            powerChangerBat = 0.00f;
            startTime = Time.time;
            if (gameObject.GetComponent<CircleCollider2D>().enabled)
            {
                Score();
                ball.SetActive(true);
                ballLength.gameObject.SetActive(false);
            }
            gameObject.GetComponent<CircleCollider2D>().enabled = false;
        }
    }
    public void HitMode(string mood)
    {
        hitMood = mood;
    }
    private void OnMouseDown()
    {
        rotateSpeed = 0;
        powerChangerBat = 0.00f;
        startTime = Time.time;
        Score();
        gameObject.GetComponent<CircleCollider2D>().enabled = false;
        ballLength.gameObject.SetActive(false);
        BallDone();
    }

    private void Score()
    {
        int risk = 0;
        List<int> scoreList = new List<int>();
        if (hitMood == "attack")
        {
            if ((fillPowerBat >= 0.32 && fillPowerBat <= 0.45) ||
            (fillPowerBat >= 0.53 && fillPowerBat <= 0.65))
            {
                risk = 2;
                scoreList.Add(2);
                scoreList.Add(3);
                scoreList.Add(4);
                scoreList.Add(5);
            }
            else if (fillPowerBat >= 0.46 && fillPowerBat <= 0.52)
            {
                risk = 1;
                scoreList.Add(4);
                scoreList.Add(5);
                scoreList.Add(4);
                scoreList.Add(5);
                scoreList.Add(4);
                scoreList.Add(5);
            }
            else if ((fillPowerBat >= 0.20 && fillPowerBat <= 0.31) ||
            (fillPowerBat >= 0.66 && fillPowerBat <= 0.70))
            {
                risk = 3;
                scoreList.Add(1);
                scoreList.Add(2);
                scoreList.Add(4);
                scoreList.Add(6);
            }
            else
            {
                risk = 4;
                scoreList.Add(2);
                scoreList.Add(6);
            }
            
        }
        if (hitMood == "balance")
        {
            risk = 2;
            if ((fillPowerBat >= 0.32 && fillPowerBat <= 0.45) ||
            (fillPowerBat >= 0.53 && fillPowerBat <= 0.65))
            {
                risk = 1;
                scoreList.Add(1);
                scoreList.Add(2);
                scoreList.Add(3);
                scoreList.Add(4);
                scoreList.Add(5);
                scoreList.Add(7);
                scoreList.Add(8);
            }
            else if (fillPowerBat >= 0.46 && fillPowerBat <= 0.52)
            {
                risk = 1;
                scoreList.Add(1);
                scoreList.Add(2);
                scoreList.Add(3);
                scoreList.Add(4);
                scoreList.Add(5);
            }
            else if ((fillPowerBat >= 0.20 && fillPowerBat <= 0.31) ||
            (fillPowerBat >= 0.66 && fillPowerBat <= 0.70))
           {
                scoreList.Add(3);
                scoreList.Add(4);
                scoreList.Add(5);
                scoreList.Add(6);
            }
            else
            {
                int wicket = Random.Range(6, 10);
                scoreList.Add(1);
                scoreList.Add(2);
                scoreList.Add(wicket);
            }
            
        }
        if (hitMood == "defence")
        {
            risk = 1;
            if ((fillPowerBat >= 0.32 && fillPowerBat <= 0.45) ||
            (fillPowerBat >= 0.53 && fillPowerBat <= 0.65))
            {
                risk = 0;
                scoreList.Add(1);
                scoreList.Add(2);
                scoreList.Add(3);
                scoreList.Add(4);
            }
            else if (fillPowerBat >= 0.46 && fillPowerBat <= 0.52)
            {
                risk = 0;
                scoreList.Add(1);
                scoreList.Add(2);
                scoreList.Add(3);
                scoreList.Add(4);
                scoreList.Add(4);
                scoreList.Add(4);
            }
            else if ((fillPowerBat >= 0.20 && fillPowerBat <= 0.31) ||
            (fillPowerBat >= 0.66 && fillPowerBat <= 0.70))
            {
                scoreList.Add(1);
                scoreList.Add(2);
                scoreList.Add(3);
                scoreList.Add(4);
            }
            else
            {
                scoreList.Add(1);
                scoreList.Add(2);
                scoreList.Add(7);
                scoreList.Add(8);
            }
        }
        if (ballDelivery == "Avarage")
        {
            for(int i = 0; i < risk; i++)
            {
                scoreList.Add(Random.Range(1,8));
            }
        }
        if (ballDelivery == "Good")
        {
            for (int i = 0; i < risk; i++)
            {
                scoreList.Add(Random.Range(6, 10));
                scoreList.Add(Random.Range(1, 10));
            }
        }
        if (ballDelivery == "Poor")
        {
            for (int i = 0; i < risk; i++)
            {
                scoreList.Add(Random.Range(3, 5));
            }
        }
        if (ballDelivery == "Perfect")
        {
            for (int i = 0; i < risk; i++)
            {
                scoreList.Add(Random.Range(6, 8));
                scoreList.Add(Random.Range(6, 10));
                scoreList.Add(Random.Range(6, 10));
            }
        }
        for(int i = 0; i<scoreList.Count;i++)
        {
            Debug.Log(scoreList[i]);
        }
        int score = scoreList[Random.Range(0, scoreList.Count)];
        if (score == 1)
        {
            StartCoroutine(ScoreBreak("One\nRun"));
            run += score;
        }
        else if (score == 2)
        {
            StartCoroutine(ScoreBreak("Two\nRuns"));
            run += score;
        }
        else if (score == 3)
        {
            StartCoroutine(ScoreBreak("Three\nRuns"));
            run += score;
        }
        else if (score == 4)
        {
            StartCoroutine(ScoreBreak("FOUR"));
            run += score;
        }
        else if (score == 5)
        {
            StartCoroutine(ScoreBreak("SIX"));
            run += score+1;
        }
        else if (score == 6)
        {
            StartCoroutine(ScoreBreak("CATCH"));
            wicket += 1;
        }
        else if (score == 7)
        {
            StartCoroutine(ScoreBreak("LBW"));
            wicket += 1;
        }
        else if (score == 8)
        {
            StartCoroutine(ScoreBreak("BOLD"));
            wicket += 1;
        }
        else if (score == 9)
        {
            StartCoroutine(ScoreBreak("RUN\nOUT"));
            wicket += 1;
        }
        else if (score == 10)
        {
            StartCoroutine(ScoreBreak("HIT\nOUT"));
            wicket += 1;
        }
        Debug.Log(score);
        Debug.Log(run);
        Debug.Log(wicket);
        Debug.Log(hitMood);
        scoreText.text = run.ToString()+" / "+wicket.ToString();
        if (wicket == 10 && targetScore==0)
        {
            SecondInnings();
        }
        if (targetScore > 0) 
        {
            if (targetScore<=run)
            {
                CompleteMatch();
            }
            else
            {
                if (total_balls==30 || wicket==10)
                {
                    CompleteMatch();
                }
            }
        }
    }
    private void SecondInnings()
    {
        target.SetActive(true);
        if (batPlayer)
        {
            batPlayer = false;
            team1 = "You";
            team2 = "CPU";
        }
        else
        {
            batPlayer = true;
            hitMoodBtn.SetActive(true);

            team2 = "You";
            team1 = "CPU";
        }
        targetScore = run + 1;
        targetText.text = "Target: " + targetScore;
        run = 0;
        wicket = 0;
        total_balls = 0;
        scoreText.text = run.ToString() + " / " + wicket.ToString();
        overText.text = "Overs 0.0 (5)";
    }
    public void NextBall()
    {
        gameObject.GetComponent<CircleCollider2D>().enabled = false;
        ball.SetActive(false);
        if (batPlayer)
        {
            StartCoroutine(BowlerAction());
            hitMoodBtn.SetActive(true);
        }
        else
        {
            bowl.SetActive(true);
            fillPowerBall = 0.12f;
            powerChangerBall = 0.010f;
            hitMoodBtn.SetActive(false);
        }
    }
    private IEnumerator ScoreBreak(string score)
    {
        Text scoreText;
        popUpScore.SetActive(true);
        scoreText = popUpScore.GetComponentInChildren<Text>();
        scoreText.text = score;
        for (int i = 140; i <= 250; i=i+3)
        {
            scoreText.fontSize = i;
            yield return new WaitForSeconds(0.005f);
        }
        popUpScore.SetActive(false);
        ball.SetActive(true);
    }
    private IEnumerator BowlerAction()
    {
        float waitToHit =  Random.Range(80,240)/ 60.0f;
        fillPowerBall = 0.12f;
        powerChangerBall = 0.010f;
        yield return new WaitForSeconds(waitToHit);
        if ((fillPowerBall >= 0.20 && fillPowerBall <= 0.31) ||
            (fillPowerBall >= 0.66 && fillPowerBall <= 0.70))
        {
            ballDelivery = "Avarage";
            ballLength.text = ballDelivery;
            ballLength.gameObject.SetActive(true);
        }
        else if ((fillPowerBall >= 0.32 && fillPowerBall <= 0.45)|| 
            (fillPowerBall >= 0.53 && fillPowerBall <= 0.65))
        {
            ballDelivery = "Good";
            ballLength.text = ballDelivery;
            ballLength.gameObject.SetActive(true);
        }
        else if (fillPowerBall >= 0.46 && fillPowerBall <= 0.52)
        {
            ballDelivery = "Perfect";
            ballLength.text = ballDelivery;
            ballLength.gameObject.SetActive(true);
        }
        else
        {
            ballDelivery = "Poor";
            ballLength.text = ballDelivery;
            ballLength.gameObject.SetActive(true);
        }
        powerChangerBall = 0.0f;
        gameObject.GetComponent<CircleCollider2D>().enabled = true;
        rotateSpeed = 20;
        fillPowerBat = 0.12f;
        powerChangerBat = 0.01f;
        startTime = Time.time;
    }
    public void BowlerActionPlayer()
    {
        bowl.SetActive(false);
        if ((fillPowerBall >= 0.20 && fillPowerBall <= 0.31) ||
            (fillPowerBall >= 0.66 && fillPowerBall <= 0.70))
        {
            ballDelivery = "Avarage";
            ballLength.text = ballDelivery;
            ballLength.gameObject.SetActive(true);
            hitMood = "balance";
        }
        
        else if (fillPowerBall >= 0.46 && fillPowerBall <= 0.52)
        {
            ballDelivery = "Perfect";
            ballLength.text = ballDelivery;
            ballLength.gameObject.SetActive(true);
            hitMood = "defence";
        }
        else if (fillPowerBall < 0.20 || fillPowerBall > 0.70)
        {
            ballDelivery = "Poor";
            ballLength.text = ballDelivery;
            ballLength.gameObject.SetActive(true);
            hitMood = "attack";
        }
        else
        {
            ballDelivery = "Good";
            ballLength.text = ballDelivery;
            ballLength.gameObject.SetActive(true);
            hitMood = "balance";
        }
        powerChangerBall = 0.0f;
        rotateSpeed = 20;
        fillPowerBat = 0.12f;
        powerChangerBat = 0.01f;
        startTime = Time.time;
        StartCoroutine(CPUBat());
    }

    private IEnumerator CPUBat()
    {
        float waitToHit = Random.Range(80, 240) / 60.0f;
        yield return new WaitForSeconds(waitToHit);
        rotateSpeed = 0;
        powerChangerBat = 0.00f;
        startTime = Time.time;
        BallDone();
        Score();
        ballLength.gameObject.SetActive(false);
    }
    private void BallDone()
    {
        total_balls += 1;
        int over = total_balls / 6;
        int ballRemainInOver = total_balls % 6;
        overText.text = "Overs " + over + "." + ballRemainInOver + " (5)";
        if (total_balls == 30)
        {
            SecondInnings();
        }
    }
    private void CompleteMatch()
    {
        hitMoodBtn.SetActive(false);
        winningScreen.SetActive(true);
        restartGame.gameObject.SetActive(true);
        if (targetScore <= run)
        {
            winningText.text = team2+" beat "+team1+" by "+(10-wicket)+" wickets";
        }
        else
        {
            winningText.text = team1 + " beat " + team2 + " by " + (targetScore-run) + " runs";
        }

        
    }
    public void RestartGame()
    {
        winningScreen.SetActive(false);
        SetUpTossScreen();
        run = 0;
        wicket = 0;
        total_balls = 0;
        targetScore = 0;
        scoreText.text = run.ToString() + " / " + wicket.ToString();
        overText.text = "Overs 0.0 (5)";
        target.SetActive(false);
    }
    public void SetUpTossScreen()
    {
        ball.SetActive(false);
        tossCoin.SetActive(true);
        tossText.gameObject.SetActive(true);
        tossScreen.SetActive(true);
    }

}
