using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RuneAttack : MonoBehaviour {

    private float timeInstantiated;

	// Use this for initialization
	void Start () {
        timeInstantiated = Time.timeSinceLevelLoad;

    }
	
	// Update is called once per frame
	void Update () {
        float timeSinceInitialization = Time.timeSinceLevelLoad - timeInstantiated;
        if (timeSinceInitialization >= 3.0f) {
            Destroy(this.gameObject);
        }
	}
}
