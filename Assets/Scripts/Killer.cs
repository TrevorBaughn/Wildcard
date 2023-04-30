using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Killer : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject == GameManager.instance.players[0].gameObject)
        {
            GameManager.instance.finalScore = GameManager.instance.players[0].score;

            AudioManager.instance.audioSource.PlayOneShot(AudioManager.instance.playerDeath);

            GameManager.instance.ActivateGameOverState();
        }
    }
}
