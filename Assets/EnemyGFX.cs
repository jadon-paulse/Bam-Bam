using Pathfinding;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGFX : MonoBehaviour
{
    public AIPath aiPath;


    private void Update()
    {
        if (aiPath.desiredVelocity.x >= 0f)
        {
            transform.localScale = new Vector3(1f, 1f, 1f);
        }
        else if (aiPath.desiredVelocity.x < 0f)
        {
            transform.localScale = new Vector3(-1f, 1f, 1f);
        }
    }

}
