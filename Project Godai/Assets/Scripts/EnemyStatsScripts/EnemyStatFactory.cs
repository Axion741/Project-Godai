using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStatFactory : MonoBehaviour {

    public IEnemyStats Create(string enemyType, GameObject targetCharacter)
    {
        switch (enemyType.ToLower())
        {
            case "goblin":
                print("Generating GoblinStats");
                return targetCharacter.AddComponent<GoblinStats>();

            case "skeleton":
                return targetCharacter.AddComponent<SkeletonStats>();

            default:
                return targetCharacter.AddComponent<DefaultEnemyStats>();
            
        }
    }

}
