using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    EnemyController otherKiller;

    //this script is holy garbage...


    //when this enters another object, run
    public void OnTriggerEnter(Collider other)
    {
        otherKiller = other.GetComponent<EnemyController>();
        if (otherKiller != null)
        {
            Destroy(other.gameObject);
            AudioManager.instance.audioSource.PlayOneShot(AudioManager.instance.enemyDeath);

            GameManager.instance.players[0].score += 1;
            GameManager.instance.tilNextLevel -= 1;


            //kill self
            Destroy(this.gameObject);
        }
        
    }
}
