using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class AbilityBase : ScriptableObject
{
    //THIS WILL SIMPLY BE THE BASE TO BUILD THE ACTUAL ABILITIES.

    //EVERY ABILITY SHOULD STOP EXISTING AFTER IT MOVED THE RANGE.
    //HOW TO CHECK HOW MUCH IT HAS MOVED?


    public Sprite mySprite;
    public string myName;
    public int range;
    public int speed;
    public GameObject projectilTemplate;

    public virtual bool CanCall()
    {
        //CHECK IF YOU CAN DO THE ABILITY. I DONT KNOW YET WHAT TO PUT IT HERE SO FOR NOW IT ALWAYS RETURNS TRUE.
        return true;
    }


    public virtual void CallAction(PlayerControl controller)
    {
        //ACTUALLY DOES THE ABILITY.
    }

    public GameObject CreateProjectil(GameObject template, Transform holder)
    {
        GameObject newObject = Instantiate(template, holder.position, Quaternion.identity);
        return newObject;        

    }

    public virtual AbilityForceField GetNonRegularProjectil()
    {
        return null;
    }
}
