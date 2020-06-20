using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Toss : MonoBehaviour
{
    int rotateSpeed = 0;
    public Text tossText;
    public Button head;
    public Button tail;
    public Button bat;
    public Button ball;
    public GameObject afterHead;
    public GameObject afterTail;
    public GameObject chooseText;
    public GameObject tossScreen;
    public GameObject ready;

    void Update()
    {
        Rotate();
    }

    public void Rotate()
    {
        transform.Rotate(rotateSpeed * Time.deltaTime * 360, 0, 0, Space.World);
    }
    public void TossCoin()
    {
        rotateSpeed = 2;
        tossText.gameObject.SetActive(false);
        chooseText.SetActive(true);
        head.gameObject.SetActive(true);
        tail.gameObject.SetActive(true);
    }

    public void MakeChoice(int choice)
    {
        head.gameObject.SetActive(false);
        tail.gameObject.SetActive(false);
        chooseText.SetActive(false);
        StartCoroutine(TossResults(choice));
    }
    private IEnumerator TossResults(int choice)
    {
        int toss=0;
        yield return new WaitForSeconds(2.0f);
        int tossGenerator = Random.Range(1, 100);
        Debug.Log(tossGenerator);
        if (tossGenerator < 51)
        {
            toss = 1;
        }
        else if(tossGenerator<101)
        {
            toss = 2;
        }
        if (toss==1)
        {
            gameObject.SetActive(false);
            rotateSpeed = 0;
            afterHead.SetActive(true);
        }
        else if(toss==2)
        {
            gameObject.SetActive(false);
            rotateSpeed = 0;
            afterTail.SetActive(true);
        }
        if (choice == toss)
        {
            chooseText.SetActive(true);
            bat.gameObject.SetActive(true);
            ball.gameObject.SetActive(true);
            Debug.Log("You won the toss");
        }
        else
        {
            int randomChoice = Random.Range(1, 100);
            if (randomChoice < 51)
            {
                FindObjectOfType<RotatePitch>().batPlayer = false;
                Debug.Log("CPU win the toss and choose Bat");
            }
            else
            {
                FindObjectOfType<RotatePitch>().batPlayer = true;
                Debug.Log("CPU win the toss and choose Ball");
            }
            ball.gameObject.SetActive(false);
            afterHead.SetActive(false);
            afterTail.SetActive(false);
            tossScreen.SetActive(false);
            ready.SetActive(true);
        }
    }
    public void WinToss(int choice)
    {
        if (choice == 1)
        {
            FindObjectOfType<RotatePitch>().batPlayer = true;
        }
        else
        {
            FindObjectOfType<RotatePitch>().batPlayer = false;
        }
        chooseText.SetActive(false);
        bat.gameObject.SetActive(false);
        ball.gameObject.SetActive(false);
        afterHead.SetActive(false);
        afterTail.SetActive(false);
        tossScreen.SetActive(false);
        ready.SetActive(true);
    }
}
