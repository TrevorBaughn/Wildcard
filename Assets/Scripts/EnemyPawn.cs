using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPawn : Pawn
{
    EnemyMover mover;
    // Start is called before the first frame update
    protected override void Start()
    {
        mover = GetComponent<EnemyMover>();
    }

    // Update is called once per frame
    void Update()
    {
    }

    public override void MoveForward()
    {
        //use the mover to move forward if not null
        if (mover != null)
        {
            mover.MoveForward(moveSpeed);
        }
    }

    public void TurnTowards(Vector3 targetPos, float speed)
    {
        //use the mover to turn toward if not null
        if (mover != null)
        {
            mover.TurnTowards(targetPos, speed);
        }
    }

    public override void TurnRight(float speed)
    {
        //abstraction is being a pain in my ass.  Don't do this.
        throw new System.NotImplementedException();
    }

    public override void Shoot()
    {
        //abstraction is being a pain in my ass.  Don't do this.
        throw new System.NotImplementedException();
    }


}
