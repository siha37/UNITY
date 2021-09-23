using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameEndScene : MonoBehaviour
{
    public TextMeshProUGUI ResulText;
    Gamemanager myChar;

    private void Start()
    {
        //Quit();  - 게임을  바로 종료시키는 함수
        myChar = Gamemanager.myChar;
        ResultOutput();
    }
    
    public void  ResultOutput()
    {
        if(myChar.Clear)
        {
            ResulText.text = "성공";
        }
        else
        {
            ResulText.text = "실패";
        }
        StartCoroutine(QuitDelay());
    }
    IEnumerator QuitDelay()
    {
        yield return new WaitForSeconds(2);
        Quit();
    }

    public void Quit()
    {
        if (Application.platform == RuntimePlatform.WebGLPlayer)
        {
            Application.Quit();
        }
        else
        {
            Application.Quit();
        }
    }
}
