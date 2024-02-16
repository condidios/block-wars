using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    public Sprite SpriteWhite;
    public Sprite SpriteBlue;
    private SpriteRenderer spriteRenderer;

    public bool isBlue;
    private Animator _animator;
    private void Start()
    {
        _animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        if (isBlue)
        {
            spriteRenderer.sprite = SpriteBlue;
            
        }
        else
        {
            spriteRenderer.sprite = SpriteWhite;
        }
    }


    private void OnCollisionEnter2D(Collision2D other)
    {
        if (gameObject.tag == "BlueTile")
        {
            if (other.gameObject.tag == "BlueBall")
            {
                gameObject.tag = "WhiteTile";
                int LayerChange = LayerMask.NameToLayer("WhiteTile");
                gameObject.layer = LayerChange;
                _animator.SetTrigger("GoWhite");
                spriteRenderer.sprite = SpriteWhite;
                isBlue = false;
            }
        }
        else if (gameObject.tag == "WhiteTile")
        {
            if (other.gameObject.tag == "WhiteBall")
            {
                gameObject.tag = "BlueTile";
                int LayerChange = LayerMask.NameToLayer("BlueTile");
                gameObject.layer = LayerChange;
                _animator.SetTrigger("GoBlue");
                spriteRenderer.sprite = SpriteBlue;
                isBlue = true;
            }
        }
    }
}
