using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SameDirection : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    struct Vector2D
    {
        public float x, y;
        // Assume usual math functions are available.
        public float Manitude()
        {
            return Mathf.Sqrt(x * x + y * y);
        }

        public Vector2D subtract( Vector2D otherVector)
        {
            Vector2D returningVec= new Vector2D();
            returningVec.x -= otherVector.x;
            returningVec.y -= otherVector.y;
            return returningVec;
        }
    };

    // Should return true if the player is facing towards the enemy (90 degrees to the left or right of PlayerPosition).
    bool IsFacing(Vector2D PlayerPosition, Vector2D PlayerDirection, Vector2D EnemyPosition)
    {
        Vector2D dirToEnemy= EnemyPosition.subtract(PlayerPosition);// determining direction to enemy 
        if (DotProduct(PlayerDirection, dirToEnemy) ==0)
            return true; 
        return false;
    }

    float DotProduct(Vector2D vecA, Vector2D vecB)
    {
        return (vecA.x * vecB.x) + (vecA.y * vecB.y);
    }
    //  if (Mathf.Acos(DotProduct(PlayerDirection, EnemyPosition) / (PlayerDirection.Manitude() * EnemyPosition.Manitude())) == 90)
}
