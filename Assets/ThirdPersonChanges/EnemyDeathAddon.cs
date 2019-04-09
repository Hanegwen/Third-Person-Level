using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CoverShooter;

public class EnemyDeathAddon : MonoBehaviour
{
    CharacterMotor Motor;
    int ammoAmount = 5;
    // Start is called before the first frame update
    void Start()
    {
        ammoAmount = 5;
        Motor = FindObjectOfType<PlayerOverlay>().GetComponent<CharacterMotor>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnDeath()
    {
        print("Ammo Added");

        var gun = Motor.Weapon.Gun;
        if (!Motor.IsEquipped) gun = null;

        if (gun != null)
            gun.LoadedBulletsLeft = gun.LoadedBulletsLeft + ammoAmount;
    }
}
