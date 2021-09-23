using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gamemanager : MonoBehaviour
{
    private static Gamemanager gamemanager = null;

    private void Start()
    {
        if (gamemanager != null)
        {
            if (gamemanager != this)
            {
                Destroy(gameObject);
            }
        }
    }
    public static Gamemanager myChar
    {
        get
        {
            if (gamemanager == null)
            {
                gamemanager = FindObjectOfType(typeof(Gamemanager)) as Gamemanager;
                if (gamemanager == null)
                {
                    GameObject obj = new GameObject("GameManager");
                    gamemanager = obj.AddComponent(typeof(Gamemanager)) as Gamemanager;
                    DontDestroyOnLoad(obj);
                }
            }
            return gamemanager;
        }
    }


    public bool Clear;
}
