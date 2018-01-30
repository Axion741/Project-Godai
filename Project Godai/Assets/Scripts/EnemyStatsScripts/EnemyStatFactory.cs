using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStatFactory : MonoBehaviour {

    public IEnemyStats Create(string enemyType)
    {
        switch (enemyType.ToLower())
        {
            case "goblin":
                print("Generating GoblinStats");
                return gameObject.AddComponent<GoblinStats>();

            case "skeleton":
                return gameObject.AddComponent<SkeletonStats>();

            default:
                return gameObject.AddComponent<DefaultEnemyStats>();
            
        }
    }

}
