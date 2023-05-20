using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static int playerScore01 = 0;
    public static int playerScore02 = 0;

    public GUISkin theSkin;

    public Transform theBall;

    // Start is called before the first frame update
    void Start()
    {
        theBall = GameObject.FindGameObjectWithTag("Ball").transform;

        playerScore01 = 0;
        playerScore02 = 0;
    }

    public static void Score(string wallName)
    {
        if (wallName == "rightWall")
        {
            playerScore01 += 1;
        }
        else
        {
            playerScore02 += 1;
        }

        Debug.Log("Player score 1: " + playerScore01);
        Debug.Log("Player score 2: " + playerScore02);
    }

    public void OnGUI()
    {
        GUI.skin = theSkin;
        GUI.Label(new Rect(Screen.width / 2 - 150 - 12, 25, 100, 100), "" + playerScore01);
        GUI.Label(new Rect(Screen.width / 2 + 150 - 12, 25, 100, 100), "" + playerScore02);

        if(GUI.Button(new Rect(Screen.width/2-100/2, 35, 100, 32), "RESET"))
        {
            playerScore01 = 0;
            playerScore02 = 0;

            theBall.gameObject.SendMessage("ResetBall");
        }
    }
}
