using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Move : MonoBehaviour
{
    public Rigidbody2D  rb2d_player_;
    private string      horizontal_input_;
    private string      vertical_input_;

    // movement variables
    public float rotation_speed_    = 10.0f;
    private float speed_             = 0.0f;
    public float acceleration_      = 30.0f;
    public float decceleration_     = -10.0f;
    public float max_speed_         = 7.0f;  // i.e. max forward speed
    public float min_speed_         = -7.0f; // i.e. max backward speed

    // transformation variables
    Vector3     heading = new Vector3(0.0f, 1.0f, 0.0f);
    Vector3     hv_velocity_ = new Vector3(0.0f, 0.0f, 0.0f);

    // Start is called before the first frame update
    void Start()
    {
        InitPlayer();
    }

    void InitPlayer()
    {
        rb2d_player_ = GetComponent<Rigidbody2D>();
        if (name == "Player 1")
        {
            horizontal_input_ = "Horizontal_2";
            vertical_input_ = "Vertical_2";
        }
        else if (name == "Player 2")
        {
            horizontal_input_ = "Horizontal";
            vertical_input_ = "Vertical";
        }
    }

    // Update is called once per frame
    void Update()
    {
        UpdateRotation();
        UpdateHVTranslation();
        UpdateTransformation();
    }

    void UpdateRotation()
    {
        float z = Input.GetAxisRaw(horizontal_input_) * -rotation_speed_;
        transform.Rotate(0.0f, 0.0f, z);
    }
    
    void UpdateObjectSpeed(float movement)
    {
        // if forward
        if (movement == 1)
        {
            Decellerate();
            if (speed_ < max_speed_)
            {
                speed_ += acceleration_;
            }
        }
        // if backward
        else if (movement == -1)
        {
            Decellerate();
            if (speed_ > min_speed_)
            {
                speed_ += -acceleration_;
            }
        }
        // not moving
        else
        {
            Decellerate();
        }
    }

    void Decellerate()
    {
        if (speed_ > 0.05f)
        {
            speed_ += decceleration_;
        }
        else if (speed_ < -0.05f)
        {
            speed_ -= decceleration_;
        }
        else if (speed_ != 0.0f)
        {
            speed_ = 0.0f;
        }
    }

    void UpdateHVTranslation()
    {
        UpdateObjectSpeed(Input.GetAxisRaw(vertical_input_));
        hv_velocity_ = heading * speed_;
    }

    void UpdateTransformation()
    {
        rb2d_player_.AddForce(transform.rotation * hv_velocity_);
    }
}
