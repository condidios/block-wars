using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallInit : MonoBehaviour
{
    public float speed = 1000f;
    public int cloneCount = 2;
    public float cloneLife = 3f;
    private Rigidbody2D rb;
    private bool isClone = false; // Flag to indicate if this is a clone

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        // Only set a random trajectory if this is not a clone
        if (!isClone && (gameObject.layer == LayerMask.NameToLayer("WhiteBall") || gameObject.layer == LayerMask.NameToLayer("BlueBall")))
        {
            Invoke(nameof(SetRandomTrajectory), 1f);
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.X) && gameObject.layer == LayerMask.NameToLayer("WhiteBall"))
        {
            CloneBalls();
        }
        else if (Input.GetKeyDown(KeyCode.Z) && gameObject.layer == LayerMask.NameToLayer("BlueBall"))
        {
            CloneBalls();
        }
    }

    private void SetRandomTrajectory()
    {
        Vector2 force = new Vector2(Random.Range(-0.5f, 0.5f), gameObject.tag == "BlueBall" ? -1 : 1);
        rb.AddForce(force.normalized * speed);
    }

    private void CloneBalls()
    {
        Vector2 initialDirection = rb.velocity.normalized;

        for (int i = 0; i < cloneCount; i++)
        {
            Vector2 force = Quaternion.Euler(0, 0, -30f * i + 15f * (cloneCount - 1)) * initialDirection;
            GameObject clone = Instantiate(gameObject, transform.position, Quaternion.identity);
            clone.tag = gameObject.tag; // Set the tag
            clone.layer = LayerMask.NameToLayer("CloneBall"); // Change layer if needed
            BallInit cloneScript = clone.GetComponent<BallInit>();
            cloneScript.isClone = true; // Indicate that this object is a clone
            Rigidbody2D cloneRb = clone.GetComponent<Rigidbody2D>();
            cloneRb.velocity = Vector2.zero; // Reset velocity before applying new force
            cloneRb.AddForce(force * speed);
            Destroy(clone, cloneLife);
        }
    }
}
