using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Abilities / Thunder")]
public class AbilityThunder : AbilityBase
{

    public override void CallAction(PlayerControl controller)
    {
        //ATTACK WITH RANGE IN A STRAIGHT LINE.
        //INSTANT?
        //EFFECTS?
        GameObject projectil = CreateProjectil(controller.projectilTemplate, controller.weapon.transform);
        Rigidbody rb = projectil.AddComponent<Rigidbody>();

        rb.useGravity = false;
        rb.AddForce(controller.transform.forward * speed);

        projectil.GetComponent<ProjectilScript>().SetUp(this);

    }
}
