using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rune : MonoBehaviour {

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player") {
            collision.gameObject.GetComponent<PlayerMotor>().currentRune = this;
            collision.gameObject.GetComponent<PlayerMotor>().runeTime = 10f;
            GameManager.runeSlider.maxValue = collision.gameObject.GetComponent<PlayerMotor>().runeTime;
            this.gameObject.transform.SetParent(collision.gameObject.transform);
            this.gameObject.SetActive(false);
        }
    }

    public virtual void Fire() {
        Debug.Log("Fire Rune");
    }

    public virtual int getDamage() {
        return -1;
    }
}
