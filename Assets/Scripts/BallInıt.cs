using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class BallInıt : MonoBehaviour
{
    public float speed = 500f;
    public int cloneCount = 2;
    public float cloneLife = 3f;
    private Rigidbody2D rb { get; set; }

    // Start is called before the first frame update
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void Start()
    {
        Invoke(nameof(SetRandomTrajectory), 1f);
    }

    void Update()
    {
        if (gameObject.tag == "WhiteBall")
        {
            if (Input.GetKeyDown(KeyCode.X))
            {
                CloneBalls("White");
            }
        }
        else if (gameObject.tag == "BlueBall")
        {
            if (Input.GetKeyDown(KeyCode.Z))
            {
                CloneBalls("Blue");
            }
        }
    }


    private void SetRandomTrajectory()
    {
        Vector2 force = Vector2.zero;
        
        if (gameObject.tag == "BlueBall")
        {
            force.y = -1;
            force.x = Random.Range(-0.5f, 0.5f);
        }
        else if (gameObject.tag == "WhiteBall")
        {
            force.y = 1;
            force.x = Random.Range(-0.5f, 0.5f);
        }
        rb.AddForce(force.normalized * speed);
    }

    private void CloneBalls(string tag)
    {
        Vector2 initialDirection;
        if (tag == "White")
        {
            initialDirection = Quaternion.Euler(0, 0, 30f) * Vector2.down;
        }
        else
        {
            initialDirection = Quaternion.Euler(0, 0, 30f) * Vector2.up;
        }
        for (int i = 0; i < cloneCount; i++)
        {
            Vector2 force = Quaternion.Euler(0, 0, -30f * i) * initialDirection;
            GameObject clone = Instantiate(gameObject, transform.position, Quaternion.identity);
            clone.tag = tag + "CloneBalls";
            Rigidbody2D cloneRb = clone.GetComponent<Rigidbody2D>();
            cloneRb.AddForce(force.normalized * speed);
            Destroy(clone, cloneLife);
        }
    }
}
