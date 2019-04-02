using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CoverShooter;

public class HealthPickUp : MonoBehaviour
{
    CharacterHealth characterHealth;
    float HealAmount = 50;
    // Start is called before the first frame update
    void Start()
    {
        characterHealth = FindObjectOfType<CharacterHealth>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PickUp()
    {
        characterHealth.Heal(HealAmount);
        Destroy(this.gameObject);
    }
}
