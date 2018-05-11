using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RuneController : MonoBehaviour {

    public int id;

    public void Awake()
    {
        id = Random.Range(0, 3);
        if (id == 0)
        {
            this.gameObject.AddComponent<IceRune>();
            Light light = this.gameObject.GetComponent<Light>();
            light.color = new Color(0, 0, 1, 1);
            
        }
        else if (id == 1)
        {
            this.gameObject.AddComponent<ElectricRune>();
            Light light = this.gameObject.GetComponent<Light>();
            light.color = new Color(1, 0, 1, 1);
        }
        else if (id == 2)
        {
            this.gameObject.AddComponent<FireRune>();
            Light light = this.gameObject.GetComponent<Light>();
            light.color = new Color(1, 0, 0, 1);
        }
        else if (id == 3) {
            this.gameObject.AddComponent<NatureRune>();
            Light light = this.gameObject.GetComponent<Light>();
            light.color = new Color(0, 1, 0, 1);
        }

    }
}
