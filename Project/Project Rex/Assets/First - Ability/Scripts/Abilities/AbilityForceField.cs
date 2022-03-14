using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
[CreateAssetMenu(menuName = "Abilities / ForceField")]
public class AbilityForceField : AbilityBase
{
    [SerializeField] public float decayTimer;
    [SerializeField] public GameObject barrierTemplate;
    public override void CallAction(PlayerControl controller)
    {
        //THIS SHOOTS A (INVISIBLE) PROJECTIL WHICH ACTIVATES AFTER X SECONDS OR X RANGE. IT CREATES A TRANSPARENT BARRIER. 
        //ANY OTHER PROJECTIL IS STOPPED BY THIS BARRIER. IT DOES NOT TAKE DAMAGE. IT IS DESTROYED AFTER X SECONDS.

        GameObject projectil = CreateProjectil(controller.projectilTemplate, controller.weapon.transform);
        Rigidbody rb = projectil.AddComponent<Rigidbody>();     

        rb.useGravity = false;
        rb.AddForce(controller.transform.forward * 100);


        projectil.GetComponent<ProjectilScript>().SetUp(this);

    }

    public override AbilityForceField GetNonRegularProjectil()
    {
        return this;
    }
}
