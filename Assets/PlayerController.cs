using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    public GameObject cam; //This is the main camera that is a child of the player

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        //Handle player movement
        float x = Input.GetAxis("Horizontal") * Time.deltaTime;
        float z = Input.GetAxis("Vertical") * Time.deltaTime;

        float h = 1f * Input.GetAxis("Mouse X");
        float v = 2f * Input.GetAxis("Mouse Y");

        cam.transform.Rotate(0, h, 0);
        gameObject.transform.Rotate(0, h, 0);
        gameObject.transform.position += z * cam.transform.forward;


        /* 
        gameObject.transform.Translate(0, 0, z);
        gameObject.transform.Rotate(0, x, 0);

        transform.localEulerAngles = new Vector3(transform.localEulerAngles.x, Camera.main.transform.localEulerAngles.y, transform.localEulerAngles.z);
       
        cam.transform.Rotate(0, h, 0);

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
        /*
         gameObject.transform.Rotate(0, x, 0);
          //Change this so forward is the direction of the camera

          float h = 1f * Input.GetAxis("Mouse X");
          //float v = 2f * Input.GetAxis("Mouse Y");
          cam.transform.Rotate(0, h, 0);
          gameObject.transform.Translate(0, 0, z);*/



    }
}
