using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerControl : MonoBehaviour
{
    //THIS SHOULD ONLY CONTROLS THE INPUT AND MOUSE. HOWEVER, I WILL PUT ADDITIONAL STUFF HERE JUST FOR SIMPLICITY.
    //THIS CALLS THE SO(SCRIPTABLE OBJECT), WHICH ACTUALLY DOES THE ABILITY.


    [Header("Ability Stuff")]
    [SerializeField] AbilityBase ability1;
    [SerializeField] GameObject ability1Holder;
    [SerializeField] AbilityBase ability2;
    [SerializeField] GameObject ability2Holder;
    [SerializeField] AbilityBase ability3;
    [SerializeField] GameObject ability3Holder;

    [SerializeField] GameObject body;

    [Header("PAUSE MENU")]
    [SerializeField] GameObject pause;

    public GameObject projectilTemplate;
    public GameObject weapon;

    private void Start()
    {
        //UPATE THE UI IN THE ABILITIES
        HandleAbilityUI();
    }
    #region UI 
    //IM GOING TO LEAVE THESE STUFF HERE JUST FOR SIMPLICITY.
    void HandleAbilityUI()
    {


        ability1Holder.SetActive(false);
        ability2Holder.SetActive(false);

        if(ability1 != null)
        {
            ability1Holder.transform.GetChild(0).GetComponent<Image>().sprite = ability1.mySprite;
            ability1Holder.SetActive(true);
        }
        if (ability2 != null)
        {
            ability2Holder.transform.GetChild(0).GetComponent<Image>().sprite = ability2.mySprite;
            ability2Holder.SetActive(true);
        }
        if(ability3 != null)
        {
            ability3Holder.transform.GetChild(0).GetComponent<Image>().sprite = ability3.mySprite;
            ability3Holder.SetActive(true);
        }
    }

    void AbilityChosenUI(Image targetAbility)
    {
        //WE TRIGGER JUST A LITTLE UI ANIMATION.
        //THEN WE RETURN TO NORMAL.
        targetAbility.color = Color.black;
        StartCoroutine(ResetUI(targetAbility));
    }
    IEnumerator ResetUI(Image targetAbility)
    {
        yield return new WaitForSeconds(0.2f);
        targetAbility.color = Color.white;
    }



        #endregion
    private void Update()
    {
        SkillInput();
        MouseInput();
        //THIS IS JUST FOR THE PAUSE MENU SO YOU CAN LEAVE EASILY.
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (pause.activeInHierarchy) pause.SetActive(false);
            else pause.SetActive(true);
        }

    }

    void SkillInput()
    {
        //DO I WANT THIS TO SELECT OR INSTATNYL TRIGGER THE ABILITY? 

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            if (!ability1.CanCall()) return;

            AbilityChosenUI(ability1Holder.GetComponent<Image>());
            ability1.CallAction(this);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            if (!ability2.CanCall()) return;
            AbilityChosenUI(ability2Holder.GetComponent<Image>());
            ability2.CallAction(this);
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            if (!ability3.CanCall()) return;
            AbilityChosenUI(ability3Holder.GetComponent<Image>());
            ability3.CallAction(this);
        }
    }



    float mouseAngle;
    [SerializeField] float mouseSpeed;
    void MouseInput()
    {
        //THIS WILL CONTROL THE LITTLE AIM UI. THATS ABOUT IT.
        //THE WHOLE BODY MOVES WITH IT, BUT ONLY SIDE WAYS. THE BODY NOR THE AIM EVER GOES UP OR DOWN.
        Vector2 mouseDelta = new Vector2(Input.GetAxis("Mouse X"), 0);

        transform.Rotate(Vector3.up * mouseDelta.x * mouseSpeed);

    }


    public Vector3 GetAimPos()
    {
        return new Vector3(0,0,0);
    }

    public void LeaveApp()
    {
        Application.Quit();
    }
}
