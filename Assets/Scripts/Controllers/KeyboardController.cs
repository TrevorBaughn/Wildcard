using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyboardController : PlayerController
{
    [Header("Control Key Codes")]
    [SerializeField] private KeyCode right;
    [SerializeField] private KeyCode left;
    [SerializeField] private KeyCode shoot;

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
    }

    protected override void OnDestroy()
    {
        base.OnDestroy();
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
    }

    protected override void ProcessInputs()
    {
        if (Input.GetKey(right))
        {
            pawn.TurnRight(pawn.turnSpeed);
        }

        if (Input.GetKey(left))
        {
            pawn.TurnRight(-pawn.turnSpeed);
        }

        if (Input.GetKey(shoot))
        {
            pawn.Shoot();
        }
    }
}
