﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NatureRune : Rune {

    public GameObject NatureAttack;

    private float speed = 15f;
    public int damage = 5;

    private void Start()
    {
        NatureAttack = Resources.Load("NatureAttack") as GameObject;
    }

    public override void Fire()
    {
        Debug.Log("Fire Electric Rune");
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        GameObject FiredProjectile = Instantiate<GameObject>(NatureAttack, player.transform.position, player.transform.rotation);
        FiredProjectile.GetComponent<Rigidbody>().AddRelativeForce(Vector3.forward * speed, ForceMode.Impulse);
        FiredProjectile.GetComponent<RuneAttack>().damage = damage;
    }

}
