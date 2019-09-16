using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Move : MonoBehaviour
{
    public Rigidbody2D  rb2d_player_;
    private string      horizontal_input_;
    private string      vertical_input_;

    // movement variables
    public float rotation_speed_    = 360.0f;
    public float speed_             = 0.0f;
    public float acceleration_      = 2.0f;
    public float decceleration_     = -2.0f;
    public float max_speed_         = 5.0f;  // i.e. max forward speed
    public float min_speed_         = -5.0f; // i.e. max backward speed

    // transformation variables
    Quaternion  rotation_;
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
        rotation_ = transform.rotation;
        if (name == "Player 1")
        {
            horizontal_input_ = "Horizontal";
            vertical_input_ = "Vertical";
        }
        else if (name == "Player 2")
        {
            horizontal_input_ = "Horizontal_2";
            vertical_input_ = "Vertical_2";
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
        float z = rotation_.eulerAngles.z;
        z += Input.GetAxisRaw(horizontal_input_) * -rotation_speed_ * Time.deltaTime;
        rotation_ = Quaternion.Euler(0, 0, z);
        transform.rotation = rotation_;
    }
    
    void UpdateObjectSpeed(float movement)
    {
        // if backward
        if (movement == -1)
        {
            if (speed_ > min_speed_)
            {
                speed_ += -acceleration_ * Time.deltaTime;
            }
        }
        // if forward
        else if (movement == 1)
        {
            if (speed_ < max_speed_)
            {
                speed_ += acceleration_ * Time.deltaTime;
            }
        }
        // not moving
        else
        {
            if (speed_ < -0.1f || speed_ > 0.1f)
            {
                speed_ += decceleration_ * Time.deltaTime;
            } 
            else if (speed_ != 0.0f)
            {
                speed_ = 0.0f;
            }
        }
    }
    void UpdateHVTranslation()
    {
        //hv_velocity_.y = Input.GetAxisRaw(vertical_input_);
        UpdateObjectSpeed(Input.GetAxisRaw(vertical_input_));
        hv_velocity_ = heading * speed_ * Time.deltaTime;
    }

    void UpdateTransformation()
    {
        transform.position += rotation_ * hv_velocity_;
    }
}
