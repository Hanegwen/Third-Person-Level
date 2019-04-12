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

    [SerializeField]
    TextMeshProUGUI GoalText;

    bool inTutorial = true;

    enum TutorialStates { Moving, Climbing, Crouching, Shooting, SwitchingWeapons};
    TutorialStates currentTutorial;
    // Start is called before the first frame update
    void Start()
    {
        currentTutorial = TutorialStates.Moving;
    }

    // Update is called once per frame
    void Update()
    {
        UpdateTutorial();

        Vector3 endPoint = new Vector3();
        endPoint = (transform.forward * 3) + Eyeline.position;
        Debug.DrawLine(Eyeline.position, endPoint, Color.red);
        RaycastHit hit;
        if(Physics.Raycast(Eyeline.position, endPoint, out hit))
        {
            //print(hit.transform.name);
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

    void UpdateTutorial()
    {
        if(inTutorial)
        {
            if(Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.D))
            {
                if(currentTutorial == TutorialStates.Moving)
                {
                    currentTutorial = TutorialStates.Climbing;

                }
            }

            if(Input.GetKeyDown(KeyCode.Space))
            {
                if(currentTutorial == TutorialStates.Climbing)
                {
                    currentTutorial = TutorialStates.Shooting;
                }
            }

            if(Input.GetKeyDown(KeyCode.Mouse0))
            {
                if(currentTutorial == TutorialStates.Shooting)
                {
                    currentTutorial = TutorialStates.SwitchingWeapons;
                }
            }

            switch (currentTutorial)
            {
                case TutorialStates.Moving:
                    GoalText.text = "Move Using WASD";
                    break;
                case TutorialStates.Climbing:
                    GoalText.text = "Go into Cover the Jump (Press Space)";
                    break;
                case TutorialStates.Crouching:
                    break;
                case TutorialStates.Shooting:
                    GoalText.text = "Shoot The Enemy In The Head (Left Mouse Click To Shoot)";
                    break;
                case TutorialStates.SwitchingWeapons:
                    GoalText.text = "Find an Entrance to The Sewer";
                    break;
                default:
                    break;
            }
        }
    }

    public void UpdateGoal(string NewGoal)
    {
        if (!inTutorial)
        {
            GoalText.text = NewGoal;
        }
    }
}
