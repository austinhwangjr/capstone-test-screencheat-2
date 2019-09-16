using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Proj_Move : MonoBehaviour
{
    private Rigidbody2D rb2d_proj;
    public GameObject bulletPrefab;
    private int damage = 1;
    private float speed = 10.0f;
    public float lifetime = 2.0f;

    // Start is called before the first frame update
    void Start()
    {
        rb2d_proj = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        rb2d_proj.velocity = transform.up * speed;
        Destroy(gameObject, lifetime);
    }

    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        // Debug.Log(hitInfo + "Hello");
        Player_Health health = hitInfo.GetComponent<Player_Health>();
        Wall wall = hitInfo.GetComponent<Wall>();

        if(health != null)
        {
            health.TakeDamage(damage);
        }

        if (wall != null)
        {
            Destroy(gameObject);
        }

        Destroy(gameObject);
    }
}
