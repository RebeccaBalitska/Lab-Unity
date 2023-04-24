using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

using UnityEngine.UI;


public class Menu : MonoBehaviour
{
    private float timer;
    private float sec;
    private float min;
    public Text timerText;
    void Start()
    {
        
    }


    void Update()
    {
        timer += Time.deltaTime;
        if (timer > 1)
        {
            sec++;
            timer = 0;
        }
        if(sec >= 60)
        {
            min++;
            sec = 0;
        }
        timerText.text = $"{min}:{sec}";
    }

    public void Reload()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void Exit()
    {
        Application.Quit();
    }
}
