using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPawn : Pawn
{
    [SerializeField] private float shootForce;
    [SerializeField] private Shooter shooter;
    [SerializeField] private GameObject bullet;
    [SerializeField] private Transform shootPoint;
    private float countdown;

    PlayerMover mover;
    // Start is called before the first frame update
    protected override void Start()
    {
        mover = GetComponent<PlayerMover>();
        shooter = GetComponent<Shooter>();

        countdown = shooter.timeBetweenShots;
    }

    // Update is called once per frame
    void Update()
    {
        countdown -= Time.deltaTime;
    }

    public override void MoveForward()
    {
        //use the mover to move forward if not null
        if (mover != null)
        {
            mover.MoveForward(moveSpeed);
        }
    }

    public override void TurnRight(float speed)
    {
        //use the mover to turn toward if not null
        if (mover != null)
        {
            mover.TurnRight(speed);
        }
    }

    public override void Shoot()
    {

        //check for countdown over or not (and make sure shooter exists yet)
        if (countdown <= 0 && shooter != null)
        {
            //noise
            AudioManager.instance.audioSource.PlayOneShot(AudioManager.instance.playerShot);

            //shoot with shooter
            shooter.Shoot(bullet, shootForce, shootPoint);
            //reset countdown
            countdown = shooter.timeBetweenShots;
        }
        
    }
}
