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

    private float currentTime = 30;
    private float beginGame = 3;

    public static bool gameStarted = false;

    public int amountOfRunes;
    public int amountOfEnemies;


	// Use this for initialization
	void Start () {
        SpawnRunes();
        //SpawnEnemies();

    }
	
	// Update is called once per frame
	void Update () {
        if (gameStarted)
        {
            timer.text = Mathf.FloorToInt(currentTime).ToString();
            currentTime -= Time.deltaTime;
        }
        else {
            
            if (beginGame > 0)
            {
                timer.text = Mathf.FloorToInt(beginGame).ToString();
                beginGame -= Time.deltaTime;
            }
            else
            {
                gameStarted = true;
            }
        }

    }

    private void SpawnRunes()
    {
        for(int i = 0; i < amountOfRunes; i++) {
            float x = Random.Range(-60, 60);
            float z = Random.Range(-60, 60);
            Vector3 runePosition = new Vector3(x, 1.5f, z);
            GameObject runeInstantiated = Instantiate<GameObject>(rune, runePosition, rune.transform.rotation);
            runeInstantiated.gameObject.transform.SetParent(ground.transform);
        }
    }

    private void SpawnEnemies() {
        for(int i = 0; i < amountOfEnemies; i++) {
            float x = Random.Range(-60, 60);
            float z = Random.Range(-60, 60);
            Vector3 enemyPosition = new Vector3(x, 1.5f, z);
            GameObject enemyInstantiated = Instantiate<GameObject>(rune, enemyPosition, rune.transform.rotation);
            enemyInstantiated.gameObject.transform.SetParent(ground.transform);
        }
    }
}
