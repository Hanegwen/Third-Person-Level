using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerOverlay : MonoBehaviour
{
    [SerializeField]
    Transform Eyeline;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 endPoint = (transform.forward * 3) + Eyeline.position;
        Debug.DrawLine(Eyeline.position, endPoint, Color.red);
        RaycastHit hit;
        if(Physics.Raycast(Eyeline.position, endPoint, out hit))
        {
            print(hit.transform.name);
            if(hit.transform.gameObject.GetComponent<HealthPickUp>() != null)
            {
                print("Hit");
                hit.transform.gameObject.GetComponent<HealthPickUp>().PickUp();
            }
        }
    }
}
