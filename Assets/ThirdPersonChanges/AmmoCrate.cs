using CoverShooter;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoCrate : MonoBehaviour
{
    CharacterMotor Motor;
    int ammoAmount = 5;

    // Start is called before the first frame update
    void Start()
    {
        Motor = FindObjectOfType<CharacterMotor>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnHit()
    {
        var gun = Motor.Weapon.Gun;
        if (!Motor.IsEquipped) gun = null;

        if (gun != null)
            gun.LoadedBulletsLeft = gun.LoadedBulletsLeft + ammoAmount;
    }
}
