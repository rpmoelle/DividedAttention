﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    public GameObject cam; //This is the main camera that is a child of the player
    float speed;//Value to change walking speed
    public BoxCollider buttonCol; //the collider on the button

    int button1Timer;
    int button2Timer;

	// Use this for initialization
	void Start () {
        speed = 2f;

        button1Timer = 30;
        button2Timer = 30;
	}
	
	// Update is called once per frame
	void Update () {

        //Handle player movement ->See Camera Controller
        //They did this way way way better than I did
        //////////////////////////////////////////////////
        
        //Get player's input for what direction they want to go in
       /* float x = Input.GetAxis("Horizontal") * Time.deltaTime * speed;
        float z = Input.GetAxis("Vertical") * Time.deltaTime;

        //Get where the mouse is pointing
        float h = 1f * Input.GetAxis("Mouse X");
        float v = 2f * Input.GetAxis("Mouse Y");

        //Rotate the camera based on the player's rotation and rotate the player object
       /* cam.transform.Rotate(0, h, 0);
        cam.transform.Rotate(0, 0, v);//test
        gameObject.transform.Rotate(0, h, 0);

        //Move the player in the direction the camera is facing
        gameObject.transform.position += z * cam.transform.forward;
       // gameObject.transform.position += x * cam.transform.forward;

        //Move the player left or right without using the camera THIS IS BUGGY (not cam dependent)
        //gameObject.transform.position += new Vector3(x, 0, 0);*/


        //Check to see if the player is looking at a button
        //////////////////////////////////////////////////
        //Cast a ray from screen center into space
        Ray ray = cam.GetComponent<Camera>().ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f));
        //Debug.DrawRay(ray.origin, ray.direction * 10f, Color.red);//show the debug ray
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 10f)) //the 10f is the length the ray extends in distance
        {
            //A collision occured between the ray and a thing
            if (hit.collider == buttonCol) {
                //Was the collision on a button?
                if (Input.GetKeyDown(KeyCode.E))
                {
                    //If the player clicks while looking at the button:
                    //Register the button click
                    Debug.Log("Clicked Button");
                }
                
            }
        }
       



    }
}
