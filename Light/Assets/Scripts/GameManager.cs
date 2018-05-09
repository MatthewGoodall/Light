using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public GameObject ground;
    public GameObject rune;

    public int amountOfRunes;
    public int amountOfEnemies;


	// Use this for initialization
	void Start () {
        for (int i = 0; i < amountOfRunes; i++) {
            float x = Random.Range(-60, 60);
            float z = Random.Range(-60, 60);
            Vector3 runePosition = new Vector3(x, 1.5f, z);
            GameObject runeInstantiated = Instantiate<GameObject>(rune, runePosition, rune.transform.rotation);
            runeInstantiated.gameObject.transform.SetParent(ground.transform);
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
