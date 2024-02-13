using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class BallInıt : MonoBehaviour
{
    public float speed = 500f;
    public bool isCloned = false;
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
        if (isCloned)
        {
            Invoke(nameof(CloneBalls), 1f);
        }
    }



    private void SetRandomTrajectory()
    {
        Vector2 force = Vector2.zero;
        force.x = Random.Range(-0.5f, 0.5f);
        if (gameObject.tag == "BlueBall")
        {
            force.y = -1;
        }
        else if (gameObject.tag == "WhiteBall")
        {
            force.y = 1;
        }
        rb.AddForce(force.normalized * speed);
    }

    private void CloneBalls()
    {
        Vector2 initialDirection = Quaternion.Euler(0, 0, 30f) * Vector2.up;
        for (int i = 0; i < cloneCount; i++)
        {
            Vector2 force = Quaternion.Euler(0, 0, -30f * i) * initialDirection;
            GameObject clone = Instantiate(gameObject, transform.position, Quaternion.identity);
            clone.GetComponent<BallInıt>().isCloned = false;
            Rigidbody2D cloneRb = clone.GetComponent<Rigidbody2D>();
            cloneRb.AddForce(force.normalized * speed);
            Destroy(clone, cloneLife);
        }
    }
}
