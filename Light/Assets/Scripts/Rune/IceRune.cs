using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceRune : Rune {

    public GameObject IceAttack;

    private float speed = 15f;
    public int damage = 5;

    private void Start()
    {
        IceAttack = Resources.Load("IceAttack") as GameObject;
    }

    public override void Fire()
    {
        Debug.Log("Fire Electric Rune");
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        GameObject FiredProjectile = Instantiate<GameObject>(IceAttack, player.transform.position, player.transform.rotation);
        FiredProjectile.GetComponent<Rigidbody>().AddRelativeForce(Vector3.forward * speed, ForceMode.Impulse);
        FiredProjectile.GetComponent<RuneAttack>().damage = damage;
    }

}
