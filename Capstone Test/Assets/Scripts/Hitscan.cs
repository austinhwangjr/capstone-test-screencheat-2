using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hitscan : MonoBehaviour
{
    public Transform firepoint;
    public LineRenderer line;
    private int damage = 1;
    public KeyCode fire;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(fire))
        {
            StartCoroutine(Shoot());
        }
    }

    IEnumerator Shoot()
    {
        RaycastHit2D hitReg = Physics2D.Raycast(firepoint.position, firepoint.up);

        if (hitReg)
        {
            playerHealth health = hitReg.transform.GetComponent<playerHealth>();

            if (health != null)
            {
                health.TakeDamage(damage);
            }

            line.SetPosition(0, firepoint.position);
            line.SetPosition(1, hitReg.point);
        }

        else
        {
            line.SetPosition(0, firepoint.position);
            line.SetPosition(1, firepoint.position + firepoint.up * 100);
        }

        line.enabled = true;

        yield return new WaitForSeconds(0.02f);

        line.enabled = false;
    }
}
