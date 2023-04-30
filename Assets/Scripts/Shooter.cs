using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    //time before bullet despawns on it's own
    [SerializeField] private float secondsBeforeDespawn;
    public float baseTimeBetweenShots;
    public float timeBetweenShots;

    private void Start()
    {
        timeBetweenShots = baseTimeBetweenShots;
    }

    //shoots
    public void Shoot(GameObject bulletPrefab, float shootForce, Transform shootPoint)
    {
        //create bullet
        GameObject bullet = Instantiate(bulletPrefab, 
                                        shootPoint.position,  
                                        transform.rotation);

        //push it at force
        Rigidbody bulletRb = bullet.GetComponent<Rigidbody>();
        if (bulletRb != null)
        {
            bulletRb.AddForce(transform.forward * shootForce);
        }

        //destroy bullet after 5 seconds
        Destroy(bullet, secondsBeforeDespawn);
    }
}
