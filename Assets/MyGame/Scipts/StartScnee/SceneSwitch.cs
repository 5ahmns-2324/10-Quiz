using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitch : MonoBehaviour
{
    [SerializeField] GameObject audioThing;

    public void SwitchScene(int index)
    {
        DontDestroyOnLoad(audioThing);
        SceneManager.LoadScene(index);
    }
}
