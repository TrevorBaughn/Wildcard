using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(EnemyPawn))]
public class EnemyController : AIController
{
    EnemyPawn enemyPawn;

    // Start is called before the first frame update
    protected override void Start()
    {
        enemyPawn = GetComponent<EnemyPawn>();
        //add itself to list of ais
        GameManager.instance.ais.Add(this);
    }

    // Update is called once per frame
    protected override void Update()
    {
        MakeDecisions();
    }

    protected override void OnDestroy()
    {
        base.OnDestroy();
    }

    public override void DoHomeState()
    {
        enemyPawn.TurnTowards(GameManager.instance.players[0].transform.position, enemyPawn.turnSpeed);
        enemyPawn.MoveForward();
    }

    public override void MakeDecisions()
    {
        if (enemyPawn == null) return; //prevent null reference errors

        //FSM
        //based on current state
        switch (currentState)
        {
            case AIStates.Home:
                //do state
                DoHomeState();
                //check for change state
                //NEVER CHANGE STATE
                break;
        }
    }
}
