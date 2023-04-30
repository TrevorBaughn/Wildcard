using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Pawn : MonoBehaviour
{
    public Controller controller;
    //this is being a pain in my ass and I forgot how to fix it.  I've got like 2 hours to get this entire game done
    //so I'm just commenting this out for now.  Never do this.
    //protected Mover mover;

    [Header("Speeds")]
    public float maxMoveSpeed;
    public float baseMoveSpeed;
    public float moveSpeed;
    public float maxTurnSpeed;
    public float baseTurnSpeed;
    public float turnSpeed;

    // Start is called before the first frame update
    protected virtual void Start()
    {
        //load mover
        //mover = GetComponent<Mover>();
    }

    public abstract void MoveForward();
    public abstract void TurnRight(float speed);

    public abstract void Shoot();

}
