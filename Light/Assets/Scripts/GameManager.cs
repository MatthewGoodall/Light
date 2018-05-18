using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    public GameObject ground;
    public GameObject rune;
    public GameObject enemy;

    public TextMeshProUGUI timer;
    public TextMeshProUGUI scoreText;
    public static Slider runeSlider;


    public GameObject[] enemies;
    public GameObject[] runes;

    public static float currentTime = 30;
    private float beginGame = 4;
    public float currentMultiplier = 1;

    public static bool gameStarted = false;
    private bool hasStartedSpawning = false;

    public int amountOfRunes;
    public int amountOfEnemies;
    private int currentScore = 0;
    


	// Use this for initialization
	void Start () {
        SpawnRunes();
        SpawnEnemies();
        enemies = GameObject.FindGameObjectsWithTag("Enemy");
        runeSlider = GameObject.Find("RuneSlider").GetComponent<Slider>();
    }

    // Update is called once per frame
    private void Update () {
        enemies = GameObject.FindGameObjectsWithTag("Enemy");
        runes = GameObject.FindGameObjectsWithTag("Rune");
        if (!gameStarted) {
            timer.text = Mathf.FloorToInt(beginGame).ToString();
            beginGame -= Time.deltaTime;
            Debug.Log(beginGame);
            if (beginGame < 0)
            {
                gameStarted = true;
            }
        } else
        {
            timer.text = Mathf.FloorToInt(currentTime).ToString();
            currentTime -= Time.deltaTime;
            if (!hasStartedSpawning) {
                hasStartedSpawning = true;
                InvokeRepeating("SpawnEnemies", 0, 5);
                InvokeRepeating("SpawnRunes", 0, 7);
            }
        }
    }

  

    private void SpawnRunes()
    {
        if (runes.Length <= 7) {
            for (int i = 0; i < amountOfRunes; i++)
            {
                float x = UnityEngine.Random.Range(-60, 60);
                float z = UnityEngine.Random.Range(-60, 60);
                Vector3 runePosition = new Vector3(x, 1.5f, z);
                GameObject runeInstantiated = Instantiate<GameObject>(rune, runePosition, rune.transform.rotation);
                runeInstantiated.gameObject.transform.SetParent(ground.transform);
            }
        }
    }

    private void SpawnEnemies() {
        for(int i = 0; i < amountOfEnemies; i++) {
            float x = UnityEngine.Random.Range(-60, 60);
            float z = UnityEngine.Random.Range(-60, 60);
            Vector3 enemyPosition = new Vector3(x, 1.5f, z);
            GameObject enemyInstantiated = Instantiate<GameObject>(enemy, enemyPosition, enemy.transform.rotation);
            enemyInstantiated.gameObject.transform.SetParent(ground.transform);
            
        }
    }
    public void IncreaseScore(int score) {
        currentScore += score;
        scoreText.text = "Score: " + currentScore;
    }
}
