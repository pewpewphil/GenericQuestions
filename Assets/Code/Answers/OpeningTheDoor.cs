using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpeningTheDoor : MonoBehaviour
{
    Vector2 PlayerPosition;
    Vector2 DoorPosition;
    Vector2 DoorNormal;
    List<Vector2> AllObjectLoc; 

    /// <summary>
    /// part A
    /// </summary>
    void PartADetermineWhichSideObjectIs()
    {
        Vector2 PlayerLookDir = PlayerPosition - DoorPosition;
        Vector2 currentObjectDir;
        bool objectIsSameSizeAsPlayer = false; 
        foreach (Vector2 currentObjectLoc in AllObjectLoc)
        {
            objectIsSameSizeAsPlayer = false;
            currentObjectDir = currentObjectLoc - DoorPosition;// direction of the object to the door 
            if (DotProduct(PlayerLookDir,currentObjectDir) >0)
            {
                objectIsSameSizeAsPlayer = true;
            }
        }
    }

    bool IsDoorOpen()
    {
        return true; // will be variable later 
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="OpenInwards">I will assume that openInwards mean open to the inside </param>
    void openDoor(bool OpenInwards)
    {// if open inwards is true we open to inside, else we open outside 

    }

    /// <summary>
    /// part B
    /// I will assume we cannot open the door towards the player.
    /// </summary>
    void PartBInteractWithDoor()
    {
        if(IsDoorOpen())
        {
            // close door
        }
        else
        {
            Vector2 PlayerLookDir = PlayerPosition - DoorPosition;
            if (DotProduct(PlayerLookDir, DoorNormal) < 0)
            {// if we are on the inside the directions will not opposite , so we will want the door to open outward
                openDoor(false);
            }
            else if (DotProduct(PlayerLookDir, DoorNormal) > 0)
            {// if we are on the outside the directions will be the same , so we will want the door to open inward
                openDoor(true);
            }
        }
    }

    float DotProduct(Vector2 vecA, Vector2 vecB)
    {
        return (vecA.x * vecB.x) + (vecA.y * vecB.y);
    }
}
