using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    public GameObject cam; //This is the main camera that is a child of the player
    float speed;//Value to change walking speed

	// Use this for initialization
	void Start () {
        speed = 2f;
	}
	
	// Update is called once per frame
	void Update () {

        //Handle player movement
        //Get player's input for what direction they want to go in
        float x = Input.GetAxis("Horizontal") * Time.deltaTime;
        float z = Input.GetAxis("Vertical") * Time.deltaTime;

        //Get where the mouse is pointing
        float h = 1f * Input.GetAxis("Mouse X");
        float v = 2f * Input.GetAxis("Mouse Y");

        //Rotate the camera based on the player's rotation
        cam.transform.Rotate(0, h, 0);
        gameObject.transform.Rotate(0, h, 0);

        //Move the player in the direction the camera is facing
        gameObject.transform.position += z * cam.transform.forward;

        //Move the player left or right without using the camera
        gameObject.transform.position += new Vector3(x, 0, 0);


       

        // create a ray going into the scene from the screen location the user clicked at
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        // the raycast hit info will be filled by the Physics.Raycast() call further
        RaycastHit hit;

        // perform a raycast using our new ray. 
        // If the ray collides with something solid in the scene, the "hit" structure will
        // be filled with collision information
        if (Physics.Raycast(ray, out hit))
        {
            // a collision occured. Check if it's our plane object and create our cube at the
            // collision point, facing toward the collision normal
            //if (hit.collider)
              //  Debug.Log("Here");
        }
       



    }
}
