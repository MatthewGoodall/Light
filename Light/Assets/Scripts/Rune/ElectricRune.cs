using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElectricRune : Rune {

    public GameObject ElectricAttack;

    private float speed = 15f;

    private void Start()
    {
        ElectricAttack = Resources.Load("Orb") as GameObject;
    }

    public override void Fire() {
        Debug.Log("Fire Electric Rune");
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        GameObject FiredProjectile = Instantiate<GameObject>(ElectricAttack, player.transform.position, player.transform.rotation);
        FiredProjectile.GetComponent<Rigidbody>().AddRelativeForce(Vector3.forward * speed, ForceMode.Impulse);
    }
}
