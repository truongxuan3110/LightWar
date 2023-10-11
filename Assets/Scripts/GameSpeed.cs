using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameSpeed : MonoBehaviour
{
    public int gameSpeed = 1;
    public Text gameSpeedText;

    // Update is called once per frame
    void Update()
    {
        gameSpeedText.text = "X"+gameSpeed.ToString();
        Time.timeScale = gameSpeed;
    }
    public void ChangeSpeed()
    {
        if(gameSpeed < 4)
        {
            gameSpeed++;
        }else if(gameSpeed == 4)
        {
            gameSpeed = 1;
        }
    }
}
