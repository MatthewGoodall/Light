using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMotor : MonoBehaviour {

    //private Rigidbody rb;

    private float speed = 10f;

    [HideInInspector]
    public float runeTime = 5f;

    public Rune currentRune;


    // Use this for initialization
    void Start () {
        //rb = GetComponent<Rigidbody>();
    }
	
	// Update is called once per frame
	void Update () {
        if (GameManager.gameStarted) {
            float horizontal = Input.GetAxisRaw("Horizontal");
            float vertical = Input.GetAxisRaw("Vertical");
            if (vertical != 0)
            {
                this.transform.position += new Vector3(0, 0, vertical * speed * Time.deltaTime);
            }
            if (horizontal != 0)
            {
                this.transform.position += new Vector3(horizontal * speed * Time.deltaTime, 0, 0);
            }

            Plane playerPlane = new Plane(Vector3.up, transform.position);
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            float hitdist = 0.0f;
            if (playerPlane.Raycast(ray, out hitdist))
            {
                Vector3 targetPoint = ray.GetPoint(hitdist);
                Quaternion targetRotation = Quaternion.LookRotation(targetPoint - transform.position);
                transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, speed * Time.deltaTime);
            }

            if (runeTime >= 0.1)
            {
                runeTime -= Time.deltaTime;
                GameManager.runeSlider.value = runeTime;
                if (Input.GetMouseButtonDown(0) && currentRune != null)
                { 
                    currentRune.Fire();
                }
            }
            else {
                gameObject.transform.GetChild(1).gameObject.SetActive(true);
                Destroy(gameObject.transform.GetChild(1).gameObject);
                currentRune = null;
            }
            
        }
    }

}