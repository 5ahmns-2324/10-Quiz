using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Linq;

public class FragenMananger : MonoBehaviour
{
    [SerializeField] private string[] _questionsArr;
    [SerializeField] private bool[] questionCorAn;
    [SerializeField] private TMP_Text activeQuestion;
    [SerializeField] private AntwortenManager[] antwortenOb;
    [SerializeField] private TMP_Text[] activeAnsweres;

    [SerializeField] Image imageGO;
    [SerializeField] Sprite[] bilder;

    public bool initQuestion = true;
    int punktAnzahl = 0;
    [SerializeField] private TMP_Text[] pointCounter;

    [SerializeField] private TMP_Text[] questionCounterTxt;

    [SerializeField] private Button[] answerBtns;
    [SerializeField] private Sprite[] buttonColor;
    [SerializeField] private Sprite[] btnBasicColor;
    [SerializeField] private Timer timeL;

    [SerializeField] private Button weiterBtn;

    int answered = 0;
    List<int> order = new List<int> {0, 1, 2, 3 ,4};
    List<int> orderAnswers = new List<int> { 0, 1, 2 };
    int qID;
    int questionsAnswered = 0;

    void Start()
    {
        questionsAnswered = 0;
        for (int i=0; i< _questionsArr.Length-1; i++)
        {
            questionCorAn[i] = false;
        }
        order = order.OrderBy(x => Random.value).ToList();
        ChooseQuestion();
        for (int i = 0; i <= 2; i++)
        {
            pointCounter[i].text = punktAnzahl.ToString();
        }
    }

    public void ChooseQuestion()
    {
        if (questionsAnswered == 5)
        {
            gameObject.GetComponent<EndGame>().SetGameOver(punktAnzahl);
            return;
        }
        SetQuestionsRandom();
        SetQuestionCount();
        SetAnswersRandom();
        ChangeStateWeiter(false);
        imageGO.sprite = bilder[qID];
        answered = 0;
        questionsAnswered++;
    }

    public void UpdateDisplayedPoints()
    {
        foreach(TMP_Text i in pointCounter)
        {
            i.text = punktAnzahl.ToString();
        }
    }

 
    public void CheckAccuracy(int buttonInx)
    {
        if (antwortenOb[qID]._solution[orderAnswers.ElementAt(buttonInx)] == true)
        {
            answered++;
            punktAnzahl++;
            answerBtns[buttonInx].image.sprite = buttonColor[0];
            answerBtns[buttonInx].interactable = false;
            if (answered == antwortenOb[qID].amtCorAnswers)
            {
                DisableAllBtns();
                ChangeStateWeiter(true);
                questionCorAn[qID] = true;
                answered = 0;
            }
        }
        else
        {
            answerBtns[buttonInx].image.sprite = buttonColor[1];
             DisableAllBtns();
            ChangeStateWeiter(true);
        }

    }

    private void DisableAllBtns()
    {
        timeL.StopTimer();
        for (int i = 0; i <= 2; i++)
        {
            answerBtns[i].interactable = false;
        }
    }

    private void ChangeStateWeiter(bool wantedState)
    {
        weiterBtn.enabled = wantedState;
    }

    private void SetQuestionCount()
    {
        for(int i =0; i<3; i++) {
            int questInt = 1;
            questInt += qID;
            questionCounterTxt[i].text = questInt.ToString() + "/5";
        }
    }

    void SetAnswersRandom()
    {
        orderAnswers = orderAnswers.OrderBy(x => Random.value).ToList();
   
        for (int i = 0; i < 3; i++)
        {
            activeAnsweres[i].text = antwortenOb[qID]._answerTxt[orderAnswers.ElementAt(i)];
            answerBtns[i].image.sprite = btnBasicColor[i];
            answerBtns[i].interactable = true;
        }

    }

    void SetQuestionsRandom()
    {
        qID = order.ElementAt(questionsAnswered);
        activeQuestion.text = _questionsArr[qID];
     }
}