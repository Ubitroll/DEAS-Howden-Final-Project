using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public static class GameData
{

    public static GameMode currentGameMode = GameMode.PC;

   [SerializeField] public static float cameraHeight  = 20f;

    public static Machine[] machines;

    static int playerScore;
    


    public static void ChangeGameMode()
    {
        if(currentGameMode == GameMode.MOBILE)
        {
            currentGameMode = GameMode.PC;
        }
        else
        {
            currentGameMode = GameMode.MOBILE;
        }
        
    }

    public static void EditMode()
    {
        if(currentGameMode != GameMode.EDIT) currentGameMode = GameMode.EDIT; else currentGameMode = GameMode.PC;
    }

    public enum GameMode
    {
        EDIT,
        PC,
        MOBILE
    };

}
