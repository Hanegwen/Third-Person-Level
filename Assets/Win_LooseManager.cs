using CoverShooter;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Win_LooseManager : MonoBehaviour
{
    CharacterHealth characterHealth;
    CharacterMotor characterMotor;

    [SerializeField]
    CharacterHealth[] enemyList;

    [SerializeField]
    TextMeshProUGUI winText;


    int deadNum = 0;
    // Start is called before the first frame update
    void Start()
    {
        characterMotor = GetComponent<CharacterMotor>();
        characterHealth = FindObjectOfType<CharacterHealth>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }

        deadNum = 0;
        foreach (CharacterHealth enemy in enemyList)
        {
            if(enemy.Health <= 0)
            {
                deadNum++;
            }
            else
            {
                //break;
            }

        }

        if(deadNum == 8)
        {
            print("Player Won");
            winText.text = "You Won: Game Will Restart";
            StartCoroutine(RestartGame());
        }

        if(!characterMotor.IsAlive)
        {
            print("Player Lost");
            StartCoroutine(RestartGame());
        }
    }

    IEnumerator RestartGame()
    {
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
