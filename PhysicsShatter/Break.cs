using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Break : MonoBehaviour
{
    public Transform fractured;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Projectile")
        {
            BreakTheThing();
        }
    }

    public void BreakTheThing()
    {
        Instantiate(fractured, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}
