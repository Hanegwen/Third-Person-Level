using CoverShooter;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIActivetAndDeActive : MonoBehaviour
{
    AIWaypoints aIWaypoints;

    // Start is called before the first frame update
    void Start()
    {
        aIWaypoints = GetComponent<AIWaypoints>();

        aIWaypoints.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ActiveAI()
    {
        aIWaypoints.enabled = true;
    }
}
