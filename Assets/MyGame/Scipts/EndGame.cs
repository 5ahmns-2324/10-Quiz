using UnityEngine;
using TMPro;

public class EndGame : MonoBehaviour
{
    [SerializeField] GameObject[] goToDisable;
    [SerializeField] GameObject[] ToEnable;
    [SerializeField] TMP_Text result;
    AudioSource audio;
    [SerializeField] AudioClip lostMusic;
    private void Awake()
    {
        GameObject audioGO = GameObject.FindGameObjectWithTag("Audio");
        audio = audioGO.GetComponent<AudioSource>();
    }
    public void SetGameOver(int points)
    {
        if (points >= 5)
        {
            result.text = "You passed! Congrats!";
            result.color = Color.green;
        }
        else
        {
            result.text = "You failed! Try again in two weeks!";
            result.color = Color.red;
            audio.Stop();
            audio.clip = lostMusic;
            audio.Play();
        }
        EnableEndScreen();
        DisableEverything();
    }

    void EnableEndScreen()
    {
        result.gameObject.SetActive(true);
        foreach(GameObject i in ToEnable)
        {
            i.SetActive(true);
        }
        GameObject pointCounter = GameObject.FindGameObjectWithTag("Points");
        pointCounter.GetComponent<RectTransform>().anchoredPosition = new Vector2(100,1);
    }

   void DisableEverything()
    {
        foreach(GameObject i in goToDisable)
        {
            Destroy(i);
        }
    }
}