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
            this.gameObject.GetComponent<Renderer>().material.SetColor("_Color", Color.cyan);
        }
        else if (id == 1)
        {
            this.gameObject.AddComponent<ElectricRune>();
            this.gameObject.GetComponent<Renderer>().material.SetColor("_Color", Color.magenta);
        }
        else if (id == 2)
        {
            this.gameObject.AddComponent<FireRune>();
            this.gameObject.GetComponent<Renderer>().material.SetColor("_Color", Color.red);
        }
        else if (id == 3) {
            this.gameObject.AddComponent<NatureRune>();
            this.gameObject.GetComponent<Renderer>().material.SetColor("_Color", Color.green);
        }
    }
}
