using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrefCache : MonoBehaviour
{
    private const string Level = "Level_";
    private const string LevelCur = "LevelCurrent"; 

    public static bool GetLevelOpen(int level) {
        if (level == 0) return true;
        return PlayerPrefs.GetInt(Level + level) == 0 ? false : true;
    }
    public static void SetOpenLevel(int level) {
        PlayerPrefs.SetInt(Level + level, 1);
    }

    public static int GetCurLevel() {
        return PlayerPrefs.GetInt(LevelCur);
    }

    public static void SetCurLevel(int levelCur) {
        PlayerPrefs.SetInt(LevelCur, levelCur);
    }
}
