using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public static class GameData
{
    public static int playerScore;
    public static float minutes;
    public static float hours;
    public static GameMode currentGameMode;

    [SerializeField] public static float cameraHeight = 20f;

    public static Machine[] machines;

    public enum GameMode
    {
        TIER_1,
        TIER_2,
        TIER_3,
        TIER_4
    };


    //public static void ChangeGameMode()
    //{
    //    if(currentGameMode == GameMode.MOBILE)
    //    {
    //        currentGameMode = GameMode.PC;
    //    }
    //    else
    //    {
    //        currentGameMode = GameMode.MOBILE;
    //    }

    //}

    //public static void EditMode()
    //{
    //    if(currentGameMode != GameMode.EDIT) currentGameMode = GameMode.EDIT; else currentGameMode = GameMode.PC;
    //}

}
