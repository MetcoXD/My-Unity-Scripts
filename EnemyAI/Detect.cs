using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Detect : MonoBehaviour
{
    bool detected;
    GameObject target;
    public Transform enemy;
    public GameObject bullet;
    public Transform shootPoint;

    public float shootSpeed = 5f;
    public float timeToShoot = 1.3f;
    float originalTime;

    // Start is called before the first frame update
    void Start()
    {
        originalTime = timeToShoot;
    }
    // Update is called once per frame
    void Update()
    {
        if(detected)
        {
            enemy.LookAt(target.transform);
        }
    }

    private void FixedUpdate()
    {
        if (detected)
        {
            timeToShoot -= Time.deltaTime;

            if (timeToShoot <= 0)
            {
                ShootPlayer();
                timeToShoot = originalTime;
            }
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            detected = true;
            target = other.gameObject;
        }

    }

    private void OnTriggerExit(Collider other)
    {
        detected = false;
    }

    private void ShootPlayer() {
        GameObject newProjectile = Instantiate(bullet, shootPoint.position, shootPoint.rotation);
        Projectile projectileComponent = newProjectile.GetComponent<Projectile>();

        // speed
        projectileComponent.SetSpeed(shootSpeed);
    }
}
