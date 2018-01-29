using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerPrefsManager : MonoBehaviour {

    const string MASTER_VOLUME_KEY = "master_volume";
    const string DIFFICULTY_KEY = "difficulty";
    const string LEVEL_KEY = "level_unlocked_";
    const string STRENGTH = "strength_modifier";
    const string SPEED = "speed_modifier";
    const string ENDURANCE = "endurance_modifier";
    const string SPIRIT = "spirit_modifier";
    const string LEVEL = "player_level";
    const string EXPERIENCE = "experience_points";
    const string STATPOINTS = "stat_points";
    const string BREAKPOINT = "break_point";
    const string BREAKCHANCE = "break_chance";
   

    public static void SetMasterVolume (float volume)
    {
        if (volume >= 0f && volume <= 1f)
        {
            PlayerPrefs.SetFloat(MASTER_VOLUME_KEY, volume);
        } else
        {
            Debug.LogError("Master Volume out of range");
        }
    }

    public static float GetMasterVolume ()
    {
        return PlayerPrefs.GetFloat(MASTER_VOLUME_KEY);
    }

    public static void UnlockLevel (int level)
    {
        if (level <= SceneManager.sceneCountInBuildSettings - 1)
        {
            PlayerPrefs.SetInt(LEVEL_KEY + level.ToString(), 1); //Use 1 for true
        }else
        {
            Debug.LogError("Trying to unlock level which doesn't exist");
        }
    }

    public static bool IsLevelUnlocked (int level)
    {
        int levelValue = PlayerPrefs.GetInt(LEVEL_KEY + level.ToString());
        bool isLevelUnlocked = (levelValue == 1);

        if (level <= SceneManager.sceneCountInBuildSettings - 1)
        {
            return isLevelUnlocked;
        }
        else
        {
            Debug.LogError("Trying to query level which doesn't exist");
            return false;
         
        }
    } 

    public static void SetDifficulty (float difficulty)
    {
        if (difficulty >= 1f && difficulty <= 3f)
        {
            PlayerPrefs.SetFloat(DIFFICULTY_KEY, difficulty);
        }
        else
        {
            Debug.LogError("Difficulty out of range");
        }
    }

    public static float GetDifficulty ()
    {
        return PlayerPrefs.GetFloat(DIFFICULTY_KEY);
    }

    public static void SetStrengthMod  (int modStrength)
    {
        PlayerPrefs.SetInt(STRENGTH, modStrength);
    }
        
    public static int GetStrengthMod()
    {
        return PlayerPrefs.GetInt(STRENGTH);
    }

    public static void SetSpeedMod(int modSpeed)
    {
        PlayerPrefs.SetInt (SPEED, modSpeed);
    }

    public static int GetSpeedMod()
    {
        return PlayerPrefs.GetInt(SPEED);
    }

    public static void SetEnduranceMod(int modEndurance)
    {
        PlayerPrefs.SetInt(ENDURANCE, modEndurance);
    }

    public static int GetEnduranceMod()
    {
        return PlayerPrefs.GetInt(ENDURANCE);
    }

    public static void SetSpiritMod(int modSpirit)
    {
        PlayerPrefs.SetInt(SPIRIT, modSpirit);
    }

    public static int GetSpiritMod()
    {
        return PlayerPrefs.GetInt(SPIRIT);
    }

    public static void SetPlayerLevel(int playerLevel)
    {
        PlayerPrefs.SetInt(LEVEL, playerLevel);
    }

    public static int GetPlayerLevel()
    {
        return PlayerPrefs.GetInt(LEVEL);
    }

    public static void SetExperiencePoints(float experiencePoints)
    {
        PlayerPrefs.SetFloat(EXPERIENCE, experiencePoints);
    }

    public static float GetExperiencePoints()
    {
        return PlayerPrefs.GetFloat(EXPERIENCE);
    }

    public static void SetStatPoints(int statPoints)
    {
        PlayerPrefs.SetInt(STATPOINTS, statPoints);
    }

    public static int GetStatPoints()
    {
        return PlayerPrefs.GetInt(STATPOINTS);
    }

    public static void SetBreakPoint(int breakPoint)
    {
        PlayerPrefs.SetInt(BREAKPOINT, breakPoint);
    }

    public static int GetBreakPoint()
    {
        return PlayerPrefs.GetInt(BREAKPOINT);
    }

    public static void SetBreakChance(int breakChance)
    {
        PlayerPrefs.SetInt(BREAKCHANCE, breakChance);
    }

    public static int GetBreakChance()
    {
        return PlayerPrefs.GetInt(BREAKCHANCE);
    }
}
