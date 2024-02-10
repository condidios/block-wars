using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class BallInıt : MonoBehaviour
{
    public float speed = 500f;

    private Rigidbody2D rb { get; set; }

    // Start is called before the first frame update
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void Start()
    {
        Invoke(nameof(SetRandomTrajectory),1f);
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
}
