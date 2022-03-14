using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Abilities / FireBall")]
public class AbilityFireBall : AbilityBase
{

    public override void CallAction(PlayerControl controller)
    {

        //HURLS A RED BALL THAT FALLS IN AN ARC. IT DEALS DAMAGE.IT DESTROY UPON CONTACT.
        //THE FIRE BALL IS SHOT FROM MOUSE POS.

        //HOW DO I HANDLE THE ARC? 
        //NEED TO GIVE THE INSTRUCTIONS ON WHAT TO DO TO THE PROJECTIL SO IT SOLVES EVERYTIHNG.

        GameObject projectil = CreateProjectil(controller.projectilTemplate, controller.weapon.transform);
        Rigidbody rb = projectil.AddComponent<Rigidbody>();

        //IT NEEDS TO GO UP AND DOWN.


        rb.mass = 0.5f;
        rb.AddForce(Vector3.up * 300);
        rb.AddForce(controller.transform.forward * speed);


        projectil.GetComponent<ProjectilScript>().SetUp(this);
       // rb.AddForce(Vector3.up * 500);
        //rb.AddForce(Vector3.forward * 500);


        //IT ALWAYS COME OUT FROM THE WEAPON. BUT HOW DO I KNOW THAT IT OUGHT TO GO FORWARD?

    }

}
