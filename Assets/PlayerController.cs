using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    public GameObject cam; //This is the main camera that is a child of the player
    float speed;//Value to change walking speed
    public BoxCollider buttonCol; //the collider on the button

	// Use this for initialization
	void Start () {
        speed = 2f;
	}
	
	// Update is called once per frame
	void Update () {

        //Handle player movement
        //Get player's input for what direction they want to go in
        float x = Input.GetAxis("Horizontal") * Time.deltaTime * speed;
        float z = Input.GetAxis("Vertical") * Time.deltaTime;

        //Get where the mouse is pointing
        float h = 1f * Input.GetAxis("Mouse X");
        float v = 2f * Input.GetAxis("Mouse Y");

        //Rotate the camera based on the player's rotation and rotate the player object
        cam.transform.Rotate(0, h, 0);
        //cam.transform.Rotate(v, 0, 0);//test
        gameObject.transform.Rotate(0, h, 0);

        //Move the player in the direction the camera is facing
        gameObject.transform.position += z * cam.transform.forward;

        //Move the player left or right without using the camera
        gameObject.transform.position += new Vector3(x, 0, 0);


        //Check to see if the player is looking at something interactable

        // create a ray going into the scene from the screen location the user clicked at
        //Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        Ray ray = cam.GetComponent<Camera>().ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f));
        Debug.DrawRay(ray.origin, ray.direction * 10f, Color.red);

        // the raycast hit info will be filled by the Physics.Raycast() call further
        RaycastHit hit;

        // perform a raycast using our new ray. 
        // If the ray collides with something solid in the scene, the "hit" structure will
        // be filled with collision information
        if (Physics.Raycast(ray, out hit, 10f))
        {
            // a collision occured. Check if it's our plane object and create our cube at the
            // collision point, facing toward the collision normal
            if (hit.collider == buttonCol) {
                Debug.Log("Here");
            }
        }
       



    }
}
