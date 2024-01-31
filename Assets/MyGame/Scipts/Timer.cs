using UnityEngine;
using TMPro;
public class Timer : MonoBehaviour
{
    public float startTime;
    private float timeLeft;
    bool timerRunning = true;
    [SerializeField] TMP_Text[] timerT;
    private void Start()
    {
        timeLeft = startTime;
    }
    void Update()
    {
    if (timerRunning)
        {
            if (timeLeft > 0f)
            {
                timeLeft = timeLeft-Time.deltaTime;
            }

            else
            {
                timerRunning = false;
                timeLeft = 0;
            }

            float minutes = Mathf.FloorToInt(timeLeft / 60);
            float seconds = Mathf.FloorToInt(timeLeft % 60);
            for (int i = 0; i < 3; i++)
            {
                timerT[i].text = minutes.ToString() + ':' + seconds.ToString();
            }
        }
    }
    public void SetTimerBack()
    {
        timerRunning = true; 
        timeLeft = startTime; 
    }
    public void StopTimer()
    {
        timerRunning = false;
    }
}