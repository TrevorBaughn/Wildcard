using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //static (stays same) game manager instance
    public static GameManager instance;
    public static AudioManager audioManager;

    [Header("Lists")]
    public List<PlayerController> players;
    public List<AIController> ais;
    public EnemySpawner enemySpawner;


    [Header("Screen State Objects")]
    [SerializeField] private GameObject titleScreenStateObject;
    [SerializeField] private GameObject gameOverStateObject;
    [SerializeField] private GameObject mainMenuStateObject;
    [SerializeField] private GameObject optionsStateObject;
    [SerializeField] private GameObject controlsStateObject;
    [SerializeField] private GameObject creditsGameObject;
    [SerializeField] private GameObject gameplayStateObject;

    [Header("Other variables")]
    [SerializeField] private int startTilNextLevel;
    public int tilNextLevel;
    [SerializeField] private float decreaseTimeBetweenShots;
    public int finalScore = 0;


    //Awake is called before Start
    private void Awake()
    {
        if (instance == null)
        {
            //this is THE game manager
            instance = this;
            //don't kill it in a new scene.
            DontDestroyOnLoad(gameObject);
        }
        else //this isn't THE game manager
        {
            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        ActivateTitleScreenState();

        //attach audiomanager to gamemanager
        audioManager = AudioManager.instance;

        tilNextLevel = startTilNextLevel;
    }

    private void Update()
    {
        if(tilNextLevel <= 0)
        {
            //reset
            tilNextLevel = startTilNextLevel;
           
            //decrease time between shots
            players[0].GetComponent<Shooter>().timeBetweenShots = 
                        Mathf.Clamp(players[0].GetComponent<Shooter>().timeBetweenShots - decreaseTimeBetweenShots, 0.25f, 10);

            //increase enemy count
            enemySpawner.maxEnemyCount += 1;
        }
    }

    //deactivate all gamestates
    private void DeactivateAllStates()
    {
        titleScreenStateObject.SetActive(false);
        gameOverStateObject.SetActive(false);
        mainMenuStateObject.SetActive(false);
        optionsStateObject.SetActive(false);
        gameplayStateObject.SetActive(false);
        controlsStateObject.SetActive(false);
        creditsGameObject.SetActive(false);
    }

    public void ActivateTitleScreenState()
    {
        DeactivateAllStates();
        titleScreenStateObject.SetActive(true);
    }

    public void ActivateGameOverState()
    {
        DeactivateAllStates();
        gameOverStateObject.SetActive(true);
    }

    public void ActivateMainMenuState()
    {
        DeactivateAllStates();
        mainMenuStateObject.SetActive(true);
    }

    public void ActivateOptionsState()
    {
        DeactivateAllStates();
        optionsStateObject.SetActive(true);
    }

    public void ActivateControlsState()
    {
        DeactivateAllStates();
        controlsStateObject.SetActive(true);
    }

    public void ActivateCreditsState()
    {
        DeactivateAllStates();
        creditsGameObject.SetActive(true);
    }

    public void ActivateGameplayState()
    {
        DeactivateAllStates();
        gameplayStateObject.SetActive(true);

        //reset vars
        tilNextLevel = startTilNextLevel;
        enemySpawner.maxEnemyCount = enemySpawner.baseMaxEnemyCount;
        players[0].score = 0;
        finalScore = 0;
        players[0].GetComponent<Shooter>().timeBetweenShots = players[0].GetComponent<Shooter>().baseTimeBetweenShots;

        //kill enemies
        enemySpawner.KillThemAll();
    }
}
