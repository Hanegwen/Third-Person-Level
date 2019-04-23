using CoverShooter;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPartnerPlugin : MonoBehaviour
{
    [SerializeField]
    CharacterMotor friend;

    bool isActive = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(!friend.IsAlive)
        {
            if(!isActive)
            {
                isActive = !isActive;
                this.gameObject.GetComponent<AISight>().FieldOfView = 360;
                this.gameObject.GetComponent<AISight>().Distance = 35;
                this.gameObject.GetComponent<CharacterAlerts>().OnDead();
            }
        }
    }
}
