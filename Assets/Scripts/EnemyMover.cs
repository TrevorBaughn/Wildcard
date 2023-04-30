using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMover : Mover
{
    //rigidbody
    private Rigidbody rigidbodyComponent;

    // Start is called before the first frame update
    void Start()
    {
        //load components to vars
        rigidbodyComponent = this.gameObject.GetComponent<Rigidbody>();
    }

    public override void MoveForward(float speed)
    {
        //move position of rigidbody rank forward at speed
        rigidbodyComponent.MovePosition(transform.position += (transform.forward * (speed * Time.deltaTime)));
    }

    public void TurnTowards(Vector3 targetPos, float speed)
    {
        //find vector to target pos from pos
        Vector3 vectorToTargetPos = targetPos - transform.position;
        //find quaternion needed to look down vector
        Quaternion lookRot = Quaternion.LookRotation(vectorToTargetPos, transform.up);
        //change rotation to be slightly down quaternion
        transform.rotation = Quaternion.RotateTowards(transform.rotation,
                                                      lookRot,
                                                      speed * Time.deltaTime);
    }
}
