using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//DATA TO SAVE TO FILE
public class SaveData : MonoBehaviour
{
    public string saveID = "DEFAULT";

    public int player2Recruited;
    public int player3Recruited;

    //CHARACTER 1 STATS//

    public int modStrength1;
    public int modSpeed1;
    public int modEndurance1;
    public int modSpirit1;

    public int playerLevel1;
    public float experiencePoints1;
    public int statPoints1;

    //CHARACTER 2 STATS//

    public int modStrength2;
    public int modSpeed2;
    public int modEndurance2;
    public int modSpirit2;

    public int playerLevel2;
    public float experiencePoints2;
    public int statPoints2;

    //CHARACTER 3 STATS//

    public int modStrength3;
    public int modSpeed3;
    public int modEndurance3;
    public int modSpirit3;

    public int playerLevel3;
    public float experiencePoints3;
    public int statPoints3;

    //LEVEL PROGRESS//

    public int highestLevelUnlocked;

}
