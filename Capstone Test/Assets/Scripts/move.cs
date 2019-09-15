using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move : MonoBehaviour
{
    public Rigidbody2D rb2d_player;

    // Start is called before the first frame update
    void Start()
    {
        rb2d_player = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (name == "Player 1")
        {
            float xAxis = Input.GetAxisRaw("Horizontal");
            float yAxis = Input.GetAxisRaw("Vertical");
            //rb2d_player.velocity = new Vector3(0, yAxis, 0);
            Quaternion rot = transform.rotation;

            float z = rot.eulerAngles.z;

            z += Input.GetAxisRaw("Horizontal") * -180f * Time.deltaTime;

            rot = Quaternion.Euler(0, 0, z);

            transform.rotation = rot;

            // move
            Vector3 pos = transform.position;

            Vector3 velocity = new Vector3(0, yAxis * Time.deltaTime, 0);

            pos += rot * velocity;
            transform.position = pos;
        }
        
        if (name == "Player 2")
        {
            float xAxis = Input.GetAxisRaw("Horizontal_2");
            float yAxis = Input.GetAxisRaw("Vertical_2");
            //rb2d_player.velocity = new Vector2(Input.GetAxisRaw("Horizontal_2"), Input.GetAxisRaw("Vertical_2"));
            Quaternion rot = transform.rotation;

            float z = rot.eulerAngles.z;

            z += Input.GetAxisRaw("Horizontal_2") * -180f * Time.deltaTime;

            rot = Quaternion.Euler(0, 0, z);

            transform.rotation = rot;

            // move
            Vector3 pos = transform.position;

            Vector3 velocity = new Vector3(0, yAxis * Time.deltaTime, 0);

            pos += rot * velocity;
            transform.position = pos;
        }

        

        //Rotate();
        //Forward(yAxis);

        
    }

    /*void Rotate()
    {
        Quaternion rot = transform.rotation;

        float z = rot.eulerAngles.z;

        z += Input.GetAxisRaw("Horizontal") * -2f;

        rot = Quaternion.Euler(0, 0, z);

        transform.rotation = rot;
    }*/
    
    void Forward(float amount)
    {
        Vector2 force = transform.up * amount;

        rb2d_player.AddForce(force);
    }
}
