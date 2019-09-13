using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shoot : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform player;
    public float lifetime = 10.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
            
        }
        Destroy(bulletPrefab, lifetime);
    }

    void Shoot()
    {
        Instantiate(bulletPrefab, player.position, player.rotation);
        
    }

}
