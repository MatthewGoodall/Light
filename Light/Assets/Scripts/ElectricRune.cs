using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElectricRune : Rune {

    public GameObject ElectricOrb;

    private float speed = 15f;

    public override void Fire() {
        Debug.Log("Fire Electric Rune");
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        GameObject FiredProjectile = Instantiate<GameObject>(ElectricOrb, player.transform.position, player.transform.rotation);
        FiredProjectile.GetComponent<Rigidbody>().AddRelativeForce(Vector3.forward * speed, ForceMode.Impulse);
    }
}
