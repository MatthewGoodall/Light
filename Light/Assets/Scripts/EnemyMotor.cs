using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMotor : MonoBehaviour {

    public GameObject player;
    public GameManager gameManager;
    private float moveSpeed = 10f;
    private float rotationSpeed = 5f;

    private int health = 10;
    private int score = 20;

	// Use this for initialization
	void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
	}
	
	// Update is called once per frame
	void Update () {
        if (GameManager.gameStarted) {
            transform.rotation = Quaternion.Slerp(transform.rotation,
     Quaternion.LookRotation(player.transform.position - transform.position), rotationSpeed * Time.deltaTime);

            //move towards the player
            transform.position += transform.forward * moveSpeed * Time.deltaTime;

            if (health <= 0)
            {
                gameManager.IncreaseScore((int)(score * gameManager.currentMultiplier));
                Destroy(this.gameObject);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<RuneAttack>()) {
            TakeDamage(other.gameObject.GetComponent<RuneAttack>().getDamage());
            Destroy(other.gameObject);
        }
    }

    private void TakeDamage(int damage) {
        health -= damage;
    }
}
