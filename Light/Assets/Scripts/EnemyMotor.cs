using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMotor : MonoBehaviour {

    public GameObject player;
    private float moveSpeed = 15f;
    private float rotationSpeed = 5f;

    private int health = 10;

	// Use this for initialization
	void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
	}
	
	// Update is called once per frame
	void Update () {
        transform.rotation = Quaternion.Slerp(transform.rotation,
     Quaternion.LookRotation(player.transform.position - transform.position), rotationSpeed * Time.deltaTime);

        //move towards the player
        transform.position += transform.forward * moveSpeed * Time.deltaTime;

        if (health <= 0) {
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<RuneAttack>()) {
            TakeDamage();
            Destroy(other.gameObject);
        }
    }

    private void TakeDamage() {
        health -= 1;
    }
}
