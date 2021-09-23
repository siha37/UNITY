using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class PlayerHP : MonoBehaviour
{
    public TextMeshProUGUI text_Timer;
    private float time_current;
    public float time_Max = 20f;
    private bool isEnded;
    Gamemanager myChar;

    public int HP = 3;
    public GameObject HpBar;

    // Start is called before the first frame update
    void Start()
    {
        myChar = Gamemanager.myChar;
    }
    private void OnEnable()
    {
        myChar = Gamemanager.myChar;
        Reset_Timer();
    }

    void Update()
    {
        if (isEnded)
            return;

        Check_Timer();
    }
    private void Check_Timer()
    {

        if (0 < time_current)
        {
            time_current -= Time.deltaTime;
            text_Timer.text = $"{time_current:N1}";
            Debug.Log(time_current);
        }
        else if (!isEnded)
        {
            End_Timer();
        }
    }

    private void End_Timer()
    {
        time_current = 0;
        text_Timer.text = $"{time_current:N1}";
        isEnded = true;
        End(true);
    }


    private void Reset_Timer()
    {
        time_current = time_Max;
        text_Timer.text = $"{time_current:N1}";
        isEnded = false;
    }


    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.tag == "ENEMY")
        {
            Damage();
        }
    }
    void Damage()
    {
        HpBar.transform.GetChild(HP-1).gameObject.SetActive(false);
        HP--;
        if(HP == 0)
        {
            End(false);
        }
    }
    void End(bool ClearResult)
    {
        myChar.Clear = ClearResult;
        SceneManager.LoadScene("Result");
    }
}
