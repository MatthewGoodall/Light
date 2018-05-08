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
            this.gameObject.AddComponent<Rune>();
        }
        else {
            this.gameObject.AddComponent<ElectricRune>();
        }
    }
}
