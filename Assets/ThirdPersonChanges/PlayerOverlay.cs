using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerOverlay : MonoBehaviour
{
    [SerializeField]
    Transform Eyeline;

    [SerializeField]
    TextMeshProUGUI OverlayText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 endPoint = new Vector3();
        endPoint = (transform.forward * 3) + Eyeline.position;
        Debug.DrawLine(Eyeline.position, endPoint, Color.red);
        RaycastHit hit;
        if(Physics.Raycast(Eyeline.position, endPoint, out hit))
        {
            print(hit.transform.name);
            OverlayText.text = "";
            if(hit.transform.gameObject.GetComponent<HealthPickUp>() != null)
            {
                OverlayText.text = "Press E To Heal";

                if (Input.GetKeyDown(KeyCode.E))
                {
                    hit.transform.gameObject.GetComponent<HealthPickUp>().PickUp();
                }
            }

            if(hit.transform.gameObject.GetComponent<AmmoCrate>() != null)
            {
                OverlayText.text = "Press E To Gain Ammo In Active Gun";

                if (Input.GetKeyDown(KeyCode.E))
                {
                    hit.transform.gameObject.GetComponent<AmmoCrate>().OnHit();
                }
            }
        }
    }
}
