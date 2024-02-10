using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slider : MonoBehaviour
{
    
    private Rigidbody2D rb;

    public float speed = 5;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.tag == "WhiteSlider")
        {
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
