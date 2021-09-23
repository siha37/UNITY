using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StartUI : MonoBehaviour
{
    public GameObject InGameOBJ;
    public GameObject InGameUI;
    public GameObject STARTUI;
    public GameObject StartButton;
    public TextMeshProUGUI CountDown;

    private void Start()
    {
        InGameUI.SetActive(false);
        InGameOBJ.SetActive(false);
        CountDown.gameObject.SetActive(false);
    }

    public void StartButtonClick()
    {
        StartButton.SetActive(false);
        CountDown.gameObject.SetActive(true);
        StartCoroutine(CountDownStart());
    }
    IEnumerator CountDownStart()
    {
        int time = 3;
        for(int i=0;i<3;i++)
        {
            CountDown.text = time.ToString();
            time--;
            yield return new WaitForSeconds(1);
        }
        CountDown.text = "GO!";
        yield return new WaitForSeconds(1);
        CountDown.gameObject.SetActive(false);
        InGameOBJ.SetActive(true);
        InGameUI.SetActive(true);
        STARTUI.SetActive(false);
    }
}
