using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slider : MonoBehaviour
{

    private Rigidbody2D rb;

    public float speed = 5;
    public GameObject fireBall;
    public float fireBallSpeed = 1000f;
    public float freezeTime = 2f;
    private bool isFreezing = false;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        if (!isFreezing)
        {
            if (gameObject.tag == "WhiteSlider")
            {
                if (Input.GetKeyDown(KeyCode.Y))
                {
                    FireBall(Vector2.down, "WhiteFireBall");
                }
                if (Input.GetKey(KeyCode.LeftArrow))
                {
                    rb.velocity = new Vector2(-speed, 0);
                }
                else if (Input.GetKey(KeyCode.RightArrow))
                {
                    rb.velocity = new Vector2(speed, 0);
                }
                else
                {
                    rb.velocity = new Vector2(0, 0);
                }
            }
            else if (gameObject.tag == "BlueSlider")
            {
                if (Input.GetKeyDown(KeyCode.U))
                {
                    FireBall(Vector2.up, "BlueFireBall");
                }
                if (Input.GetKey(KeyCode.A))
                {
                    rb.velocity = new Vector2(-speed, 0);
                }
                else if (Input.GetKey(KeyCode.D))
                {
                    rb.velocity = new Vector2(speed, 0);
                }
                else
                {
                    rb.velocity = new Vector2(0, 0);
                }
            }
        }
    }

    void FireBall(Vector2 direction, string tag)
    {
        GameObject ball = Instantiate(fireBall, transform.position + (Vector3)direction * 0.5f, Quaternion.identity);
        ball.tag = tag;
        Rigidbody2D ballRb = ball.GetComponent<Rigidbody2D>();
        ballRb.velocity = direction.normalized * fireBallSpeed;
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (gameObject.tag == "WhiteSlider")
        {
            if (other.gameObject.CompareTag("BlueFireBall"))
            {
                Destroy(other.gameObject);
                rb.velocity = Vector2.zero;
                isFreezing = true;
                StartCoroutine(DisableSliderForSeconds(freezeTime));
            }
        }
        else if (gameObject.tag == "BlueSlider")
        {
            if (other.gameObject.CompareTag("WhiteFireBall"))
            {
                Destroy(other.gameObject);
                rb.velocity = Vector2.zero;
                isFreezing = true;
                StartCoroutine(DisableSliderForSeconds(freezeTime));
            }
        }
    }

    IEnumerator DisableSliderForSeconds(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        isFreezing = false;
    }
}
