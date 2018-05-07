using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightBehaviour : MonoBehaviour {

    private Light lightSource;
    private Color color;
    private float timePassed;
    private float changeValue;

	// Use this for initialization
	void Start () {
        lightSource = this.GetComponent<Light>();
        if (lightSource != null) {
            color = lightSource.color;
        }
        changeValue = 0;
        timePassed = 0;
	}
	
	// Update is called once per frame
	void Update () {
        timePassed = Time.time;
        timePassed = timePassed - Mathf.Floor(timePassed);

        lightSource.color = color * CalculateChange();
	}

    private float CalculateChange()
    {
        changeValue = -Mathf.Sin(timePassed * 12 * Mathf.PI) * 0.05f + 0.95f;
        return changeValue;
    }
}
