using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public PlayerDetection playerDetection;
    public float speed = 1.0f;

    private float h = 0;
    private float v = 0;
    private Rigidbody rb;

    public bool canMove = true;

    public Sprite down;
    public Sprite left;
    public Sprite up;
    public Sprite right;
    public Sprite downleft;
    public Sprite upleft;
    public Sprite upright;
    public Sprite downright;

    public SpriteRenderer spriteRenderer;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (canMove)
        {
            h = Input.GetAxis("Horizontal");
            v = Input.GetAxis("Vertical");

            rb.velocity = new Vector3(h, 0, v) * speed;
        }

        if (spriteRenderer != null)
        {
            if (h > 0.0f && v > 0.0f)
            {
                spriteRenderer.sprite = upright;
            }
            else
            {
                if (h > 0.0f && v < 0.0f)
                {
                    spriteRenderer.sprite = downright;
                }
                else
                {
                    if (h < 0.0f && v < 0.0f)
                    {
                        spriteRenderer.sprite = downleft;
                    }
                    else
                    {
                        if (h < 0.0f && v > 0.0f)
                        {
                            spriteRenderer.sprite = upleft;
                        }
                        else
                        {
                            if (h > 0.0f)
                            {
                                spriteRenderer.sprite = right;
                            }
                            else
                            {
                                if (h < 0.0f)
                                {
                                    spriteRenderer.sprite = left;
                                }
                                else
                                {
                                    if (v < 0.0f)
                                    {
                                        spriteRenderer.sprite = down;
                                    }
                                    else
                                    {
                                        if (v > 0.0f)
                                        {
                                            spriteRenderer.sprite = up;
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}
