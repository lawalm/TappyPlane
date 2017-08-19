using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneScript : MonoBehaviour {

    [Tooltip("The force which is added when the player jumps")]
    public float upForce = 200f;
    private bool isDead = false;

    private Animator anim;
    private Rigidbody2D rb2d;

	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
        rb2d = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
		if(isDead == false) {
            if(Input.GetMouseButtonDown(0)) {
                rb2d.velocity = Vector2.zero;
                rb2d.AddForce(new Vector2(0, upForce));
                anim.SetTrigger("Fly");
            }
        }
	}

    private void OnCollisionEnter2D(Collision2D collision) {
        rb2d.velocity = Vector2.zero;
        isDead = true;
        anim.SetTrigger("Die");
        GameController.instance.PlaneDied();
    }
}
