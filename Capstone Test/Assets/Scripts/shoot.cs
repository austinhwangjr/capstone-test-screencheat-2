using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shoot : MonoBehaviour
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
        
        if (Input.GetKeyDown(fire))//(Input.GetButtonDown("Fire1"))
        {
            Shoot();
            Debug.Log("I shoot");
        }
        Debug.Log("No shoot");
        Destroy(bulletPrefab, lifetime);
    }

    void Shoot()
    {
        Debug.Log(firepoint.transform.position.ToString() + "keyword");
        Instantiate(bulletPrefab, firepoint.position, firepoint.rotation);
        
    }

}
