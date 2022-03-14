using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrierScript : MonoBehaviour
{
    float decay;
    float current;
    bool setUpComplete;
    public void SetUp(float _decay)
    {
        Debug.Log(_decay);
        current = 0;
        decay = _decay;
        setUpComplete = true;
    }


    private void Update()
    {
        if (!setUpComplete) return;
        if(current >= decay)
        {
            Debug.Log("should destroy");
            Destroy(this.gameObject);
        }
        else
        {
            Debug.Log("counting");
            current += Time.deltaTime;
        }
    }


}
