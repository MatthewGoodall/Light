using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    public GameObject ground;
    public GameObject rune;

    public TextMeshProUGUI timer;
    public Button startGame;

    public GameObject[] enemies;

    private float currentTime = 30;
    private float beginGame = 4;

    public static bool gameStarted = false;

    public int amountOfRunes;
    public int amountOfEnemies;


	// Use this for initialization
	void Start () {
        SpawnRunes();
        //SpawnEnemies();
        enemies = GameObject.FindGameObjectsWithTag("Enemy");
        
    }

    // Update is called once per frame
    private void Update () {
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
        }
    }

    private void SpawnRunes()
    {
        for(int i = 0; i < amountOfRunes; i++) {
            float x = UnityEngine.Random.Range(-60, 60);
            float z = UnityEngine.Random.Range(-60, 60);
            Vector3 runePosition = new Vector3(x, 1.5f, z);
            GameObject runeInstantiated = Instantiate<GameObject>(rune, runePosition, rune.transform.rotation);
            runeInstantiated.gameObject.transform.SetParent(ground.transform);
        }
    }

    private void SpawnEnemies() {
        for(int i = 0; i < amountOfEnemies; i++) {
            float x = UnityEngine.Random.Range(-60, 60);
            float z = UnityEngine.Random.Range(-60, 60);
            Vector3 enemyPosition = new Vector3(x, 1.5f, z);
            GameObject enemyInstantiated = Instantiate<GameObject>(rune, enemyPosition, rune.transform.rotation);
            enemyInstantiated.gameObject.transform.SetParent(ground.transform);
            
        }
    }
}
