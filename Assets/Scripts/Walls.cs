using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Walls : MonoBehaviour
{
    public float timer = 2f;
    public GameObject blueBall;
    public GameObject whiteBall;
    public GameObject spawnPositionBlue;
    public GameObject spawnPositionWhite;
    

    private void spawnBall()
    {
        if (gameObject.tag == "BottomWall")
        {
            Instantiate(blueBall,spawnPositionBlue.transform.position,Quaternion.identity);
        }
        else if (gameObject.tag == "TopWall")
        {
            Instantiate(whiteBall,spawnPositionWhite.transform.position,Quaternion.identity);
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (gameObject.tag == "BottomWall")
        {
            if (other.gameObject.tag == "BlueBall")
            {
                Destroy(other.gameObject);
                Invoke("spawnBall",timer);
                
            }
        }
        else if (gameObject.tag == "TopWall")
        {
            if (other.gameObject.tag == "WhiteBall")
            {
                Destroy(other.gameObject);
                Invoke("spawnBall",timer);
            }
        }
    }
}
