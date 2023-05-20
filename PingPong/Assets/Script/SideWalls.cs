using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SideWalls : MonoBehaviour
{
    public void OnTriggerEnter2D(Collider2D col)
    {
        if(col.name == "Ball")
        {
            string wallName = transform.name;
            GameManager.Score(wallName);
        }
    }
}
