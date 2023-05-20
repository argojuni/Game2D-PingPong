using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static int  playerScore01 = 0;
    public static int  playerScore02 = 0;

    public GUISkin theSkin;
    public static void Score(string wallName)
    {
        if(wallName == "rightWall")
        {
            playerScore01 += 1;
        }
        else
        {
            playerScore02 += 1;
        }
        Debug.Log("Player score 1 in " + playerScore01);
        Debug.Log("Player score 2 in " + playerScore02);
    }

    public void OnGUI()
    {
        GUI.skin = theSkin;
        GUI.Label(new Rect(Screen.width/2-150, 25, 100, 100),""+playerScore01);
        GUI.Label(new Rect(Screen.width/2+150, 25, 100, 100),""+playerScore02);
    }
}
