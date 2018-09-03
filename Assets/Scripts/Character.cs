﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour {

    public int notesMissed = 0;
    public float characterHealth = 100f;
    public float dodgeSpeed;
    public bool isFacingRight = true;
    public bool isDodging;
    public bool isAttackingSingle = false;
    public bool isAttackingDouble = false;

    private float damage = 1f;
    private Animator animator;
	// Use this for initialization
	void Start () {
        notesMissed = 0;
        animator = GetComponent<Animator>();
	}

    // Update is called once per frame
    void Update() {
        if (isFacingRight)
        {
            transform.rotation = new Quaternion(0, 0, 0, 1);
        }
        else {
            transform.rotation = new Quaternion(0, 180, 0, 1);
        }

        if (isDodging == true) {
            animator.SetTrigger("dodgeTrigger");
            isDodging = false;
        } else if (isAttackingSingle == true) {
            animator.SetTrigger("attacksingleTrigger");
            isAttackingSingle = false;
        } else if (isAttackingDouble == true) {
            animator.SetTrigger("attackingdoubleTrigger");
            isAttackingDouble = false;
        }
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Note>()) {
            notesMissed += 1;
            TakingDamage();
            Destroy(collision.gameObject);
        }
    }

    private void TakingDamage() {
        damage += notesMissed * 3;
        characterHealth -= damage;
        print(characterHealth);

        animator.SetTrigger("takeDamageTrigger");
    }
}