using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireRune : Rune {

    public GameObject FireAttack;

    private float speed = 15f;
    public int damage = 5;

    private void Start()
    {
        FireAttack = Resources.Load("FireAttack") as GameObject;
    }

    public override void Fire()
    {
        Debug.Log("Fire Electric Rune");
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        GameObject FiredProjectile = Instantiate<GameObject>(FireAttack, player.transform.position, player.transform.rotation);
        FiredProjectile.GetComponent<Rigidbody>().AddRelativeForce(Vector3.forward * speed, ForceMode.Impulse);
        FiredProjectile.GetComponent<RuneAttack>().damage = damage;
    }

}
