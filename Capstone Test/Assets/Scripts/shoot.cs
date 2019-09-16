using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform firepoint;
    public Transform player;
    public KeyCode fire;
    public float lifetime = 10.0f;
   
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(fire))
        {
            Fire();
        }
        //Destroy(gameObject, lifetime);
    }

    void Fire()
    {
        Instantiate(bulletPrefab, firepoint.position, firepoint.rotation);
    }

}
