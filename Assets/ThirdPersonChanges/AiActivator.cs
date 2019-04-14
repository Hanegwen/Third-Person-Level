using CoverShooter;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiActivator : MonoBehaviour
{
    [SerializeField]
    List<AIActivetAndDeActive> EnemiesTiedToThis;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.GetComponent<PlayerOverlay>() != null)
        {
            print("Player Walked In");
            foreach (AIActivetAndDeActive Enemy in EnemiesTiedToThis)
            {
                Enemy.ActiveAI();
            }
        }
    }
}
