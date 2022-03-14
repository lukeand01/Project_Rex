using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectilScript : MonoBehaviour
{
    //HAVE A CLASS PER THING
    Vector3 initialPos;
    AbilityBase abilityBase; 

    int range;
    bool regularProjectil;
    //WHAT ABOUT DECAY? 
    //ALSO NOT EVERY PROJECTIL WANTS TO EXPLODE WITH TOUCH.

    float safeDecay;
    float currentSafeDecay;
    private void Awake()
    {
        safeDecay = 3;
    }
    public void SetUp(AbilityBase _base)
    {
        abilityBase = _base;
        range = _base.range;
        
        if(_base.GetNonRegularProjectil() != null)
        {
            regularProjectil = false;
            return;
        }
        regularProjectil = true;
    }
    public void ArcBehavior()
    {
        //START THE PROCESS OF ARC BEHAVIOR.
    }
    public void StraightBehavior()
    {
        //GOES FORWARD.
    }

    public void ForceFieldBehavior()
    {
        //GOES FORWARD. STOP. CREATE BARRIER.
    }


    private void Start()
    {
        initialPos = transform.position;
    }
    bool done;
    private void Update()
    {
        //THIS DESTROYS THE GAMEOBJECT AFTER IT MOVED MORE THAN RANGE.
        if (Vector3.Distance(transform.position, initialPos) > range) 
        {
            if (!regularProjectil && !done) 
            {
                done = true;
                //IS THERE A PAUSE BEFORE CALLING THE THING?
                //DESTROY THIS
                //CREATE BARRIER WHERE IT IS.
                //SET UP THE BARRIER.

                GameObject newBarrier = Instantiate(abilityBase.GetNonRegularProjectil().barrierTemplate, this.transform.position, Quaternion.identity);



                float decayTimer = abilityBase.GetNonRegularProjectil().decayTimer;

                newBarrier.GetComponent<BarrierScript>().SetUp(decayTimer);
                Destroy(this.gameObject);
                return;

            }
            Destroy(this.gameObject);

        } 
        

        if(currentSafeDecay >= safeDecay)
        {
            Destroy(this.gameObject);
        }
        else
        {
            currentSafeDecay += Time.deltaTime;
        }
        
    }


    private void OnCollisionEnter(Collision collision)
    {
        //IF IT TOUCHES SOMETHING IT SHOULD ALSO EXPLODE.
        //CANNTO EXPLODE IF IT TOUCHES WEAPON.
        if(collision.gameObject.tag == "Wall" ) //BARRIER PROJECTIL WONT INTERACT WITH OTHER PROJECTILS. BUT WHAT IF IT DOES? IF IT TOUCHES A WALL IT WILL TRIGGER THE BARRIER IN THE WALL.
        {
            Destroy(this.gameObject);
        }
    }
}
