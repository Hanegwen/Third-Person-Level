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
    TextMeshProUGUI GoalText, Moving, Climbing, Aiming, Shooting, SwitchWeapons, PermanentGoalText, Croaching;

    bool inTutorial = true;

    enum TutorialStates { Moving, Climbing, Crouching, Shooting, SwitchingWeapons, Aiming};
    TutorialStates currentTutorial;


    bool hasMoved = false;
    bool hasJumped = false;
    bool hasAimed = false;
    bool hasShot = false;
    bool EnemyKilledEarly = false;
    bool hasCrouched = false;
    // Start is called before the first frame update
    void Start()
    {
        currentTutorial = TutorialStates.Moving;

        Moving.text = "";
        Climbing.text = "";
        Aiming.text = "";
        Shooting.text = "";
        SwitchWeapons.text = "";
        Croaching.text = "";
        GoalText.text = "";
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

        switch (currentTutorial)
        {
            case TutorialStates.Moving:
                if(hasMoved)
                {
                    Moving.text = "Move: WASD";
                    currentTutorial = TutorialStates.Climbing;
                }
                break;
            case TutorialStates.Climbing:
                if(hasJumped)
                {
                    Climbing.text = "Jumping and Vaulting: Space";
                    currentTutorial = TutorialStates.Aiming;
                }
                break;
            case TutorialStates.Crouching:
                
                break;
            case TutorialStates.Aiming:
                if(hasAimed)
                {
                    Aiming.text = "Aiming: Right Mouse";
                    currentTutorial = TutorialStates.Shooting;
                }
                break;
            case TutorialStates.Shooting:
                if(hasShot)
                {
                    Shooting.text = "Shooting: Left Mouse";
                    currentTutorial = TutorialStates.Crouching;
                }
                break;
            case TutorialStates.SwitchingWeapons:
                
                break;
            default:
                break;
        }
        
    }

    void UpdateTutorial()
    {
        if(inTutorial)
        {
            if(Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.D))
            {
                hasMoved = true;
                if(currentTutorial == TutorialStates.Moving)
                {
                    print("Movement Section");
                    GoalText.color = Color.green;

                    Moving.text = "Move: WASD";

                    StartCoroutine(CooldownToChange(TutorialStates.Climbing));

                }
            }

            if(Input.GetKeyDown(KeyCode.Space))
            {
                hasJumped = true;
                if(currentTutorial == TutorialStates.Climbing)
                {
                    GoalText.color = Color.green;

                    Climbing.text = "Jumping and Vaulting: Space";

                    StartCoroutine(CooldownToChange(TutorialStates.Aiming));
                }
            }

            if(Input.GetKeyDown(KeyCode.Mouse1))
            {
                hasAimed = true;
                if(currentTutorial == TutorialStates.Aiming)
                {
                    GoalText.color = Color.green;

                    Aiming.text = "Aiming: Right Mouse";

                    StartCoroutine(CooldownToChange(TutorialStates.Shooting));
                }
            }

            if(Input.GetKeyDown(KeyCode.Mouse0))
            {
                hasShot = true;
                if(currentTutorial == TutorialStates.Shooting)
                {
                    GoalText.color = Color.green;

                    Shooting.text = "Shooting: Left Mouse";

                    StartCoroutine(CooldownToChange(TutorialStates.Crouching));
                }
            }

            if(Input.GetKeyDown(KeyCode.LeftControl))
            {
                hasCrouched = true;
                if(currentTutorial == TutorialStates.Crouching)
                {
                    GoalText.color = Color.green;

                    Croaching.text = "Crouch: Hold Left CTRL";

                    StartCoroutine(CooldownToChange(TutorialStates.SwitchingWeapons));
                }
            }

            switch (currentTutorial)
            {
                case TutorialStates.Moving:
                    GoalText.text = "Move Using WASD";
                    break;
                case TutorialStates.Climbing:
                    GoalText.text = "Go into Cover, hold W ,and press Jump (Press Space)";
                    break;
                case TutorialStates.Crouching:
                    GoalText.text = "Crouch (hold Left CTRL) and go under the light pole";
                    break;
                case TutorialStates.Aiming:
                    GoalText.text = "Aiming by Holding the Right Mouse Button";
                    break;
                case TutorialStates.Shooting:
                    GoalText.text = "Shoot The Enemy In The Head (Left Mouse Click To Shoot)";
                    break;
                case TutorialStates.SwitchingWeapons:
                    GoalText.text = "";
                    PermanentGoalText.text = "Find an Entrance to The Sewer";
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

    IEnumerator CooldownToChange(TutorialStates request)
    {
        print("Recieved Request");
        yield return new WaitForSeconds(3.5f);
        print("Request Done");


        GoalText.color = Color.white;
        currentTutorial = request;

    }
}
