﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Note : MonoBehaviour {

    public float timeToTravel = 2f;

    private GameObject character;
    private GameObject activatorUpArrow;
    private GameObject activatorLeftArrow;
    private GameObject activatorRightArrow;

    private Vector3 startPosition, upEndPosition, leftEndPosition, rightEndPosition;
    Vector3 controlPosition;
    private float t;


    private void Awake()
    {
        character = GameObject.Find("Character");
        activatorUpArrow = GameObject.Find("ActivatorUpArrow");
        activatorLeftArrow = GameObject.Find("ActivatorLeftArrow");
        activatorRightArrow = GameObject.Find("ActivatorRightArrow");
    }

    // Use this for initialization
    void Start () {
        startPosition = transform.position;
    }
	
	// Update is called once per frame
	void Update () {
        upEndPosition = activatorUpArrow.transform.position;
        leftEndPosition = activatorLeftArrow.transform.position;
        rightEndPosition = activatorRightArrow.transform.position;

        if (gameObject.tag == "Up")
        {
            if (transform.position.y <= upEndPosition.y)
            {
                transform.position = Vector2.MoveTowards(transform.position, character.transform.position, 3 * Time.deltaTime);
            }
            else {
                t += Time.deltaTime / timeToTravel;
                transform.position = Vector3.Lerp(startPosition, upEndPosition, t);
            }
        
        }
        else if (gameObject.tag == "Left")
        {
            if (transform.position.y <= leftEndPosition.y)
            {
                transform.position = Vector2.MoveTowards(transform.position, character.transform.position, 3 * Time.deltaTime);
            }
            else {
                t += Time.deltaTime / timeToTravel;

                controlPosition = startPosition + (leftEndPosition - startPosition) / 2 + Vector3.left * 5.0f;
                Vector2 m1 = Vector3.Lerp(startPosition, controlPosition, t);
                Vector2 m2 = Vector3.Lerp(controlPosition, leftEndPosition, t);
                transform.position = Vector2.Lerp(m1, m2, t);
            }           
        }
        else if (gameObject.tag == "Right")
        {
            if (transform.position.y <= rightEndPosition.y)
            {
                transform.position = Vector2.MoveTowards(transform.position, character.transform.position, 3 * Time.deltaTime);
            }
            else {
                t += Time.deltaTime / timeToTravel;

                controlPosition = startPosition + (rightEndPosition - startPosition) / 2 + Vector3.right * 5.0f;
                Vector2 m1 = Vector3.Lerp(startPosition, controlPosition, t);
                Vector2 m2 = Vector3.Lerp(controlPosition, rightEndPosition, t);
                transform.position = Vector2.Lerp(m1, m2, t);
            }
        }
    }
}
