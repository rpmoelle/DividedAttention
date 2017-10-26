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
        //Use vector forces and movement axis for possible controller support
        float x = Input.GetAxis("Horizontal") * Time.deltaTime * 150.0f;
        float z = Input.GetAxis("Vertical") * Time.deltaTime * 3.0f;

      //  gameObject.transform.Rotate(0, x, 0);
    //Change this so forward is the direction of the camera

        float h = 1f * Input.GetAxis("Mouse X");//Change this value
        //float v = 2f * Input.GetAxis("Mouse Y");
        cam.transform.Rotate(0, h, 0);
        gameObject.transform.Translate(h, 0, z);



    }
}
