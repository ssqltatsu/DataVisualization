using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.XR.Interaction;

public class DecidePosition : MonoBehaviour
{
    private Vector3 settingPosition;
    private bool dPosFlag = false;
    private bool worldDPosFlag = false;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetPosition(Vector3 position)
    {
        settingPosition = position;
        dPosFlag = true;
    }

    public void SetPosition(float x, float y, float z)
    {
        settingPosition = new Vector3(x, y, z);
        dPosFlag = true;
    }

    public void SetWorldPosition(float x, float y, float z)
    {
        settingPosition = new Vector3(x, y, z);
        worldDPosFlag = true;
    }

    public void PositionPlus(float x, float y, float z)
    {
        settingPosition +=  new Vector3(x, y, z);
    }

    public Vector3 GetPosition()
    {
        //localpositionとworldpositionは同時に持たない前提
        return settingPosition;
    }

    public bool GetPosFlag()
    {
        return dPosFlag;
    }

    public bool GetWorldPosFlag()
    {
        return worldDPosFlag;
    }
}
