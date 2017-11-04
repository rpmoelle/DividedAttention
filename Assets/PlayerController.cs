using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {
    public GameObject cam; //This is the main camera that is a child of the player
    float speed;//Value to change walking speed

    public BoxCollider buttonCol; //the collider on button1
    public BoxCollider buttonCol2; //the collider on button2

    int button1Timer;
    int button2Timer;

    int button1Rest;
    int button2Rest;

    bool button1Pushed;
    bool button2Pushed;

    public Text button1Timer_text;
    public Text button2Timer_text;

    public Text end_text;

    public Text button1Timer_world;
    public Text button2Timer_world;

    float totalTime;

    bool collide;

    //Test Monsters
    public GameObject testMonster;

    public GameObject floor;
    public GameObject wallCap1;
    public GameObject ceiling;
    public GameObject plant;
    public GameObject timer1;
    public GameObject button1_platform;
    public GameObject wall1;
    public GameObject wall2;
    public GameObject ceilingLightModel2;
    public Material bigFloor;
    public Material bigCeiling;
    public Material bigWall;

    public Light light1_ceiling;
    public Material greenLightMat;
    public MeshRenderer light1_model;
    public GameObject light1_ceiling_obj;

    public GameObject timer1_obj;
    public GameObject timer2_obj;



    bool backTo1;
    bool backTo2;

    int monsterCounter;

    //Buttons
    public Animator button1;
    public Animator button2;

   /* void OnCollisionEnter(Collision col)
    {
        if(col.gameObject.tag == "wall")
        {
            //prevent bounce
            speed = 0;
            collide = true;
        }
     
    }*/


    void CheckMonster()
    {
        //This function keeps track of what monster to display and when monster appearances are triggered
        //Test Case: Purple Sphere
        if (backTo2 && monsterCounter == 0)
        {
            //Stretch wall
            //You start facing button 2
            floor.transform.localScale = new Vector3(floor.transform.localScale.x, floor.transform.localScale.y, 100);
            floor.GetComponent<MeshRenderer>().material = bigFloor;
            //move the end cap back
            wallCap1.transform.position = new Vector3(wallCap1.transform.position.x, wallCap1.transform.position.y, 25);
            //move plant, button, and timer
            plant.transform.position = new Vector3(plant.transform.position.x, plant.transform.position.y, 20);
            button1_platform.transform.position = new Vector3(button1_platform.transform.position.x, button1_platform.transform.position.y, 20);
            timer1.transform.position = new Vector3(timer1.transform.position.x, timer1.transform.position.y, 24);
            //move light
            ceilingLightModel2.transform.position = new Vector3(ceilingLightModel2.transform.position.x, ceilingLightModel2.transform.position.y, 24);
            light1_ceiling_obj.transform.position = new Vector3(light1_ceiling_obj.transform.position.x, light1_ceiling_obj.transform.position.y, 24);
            //extend ceiling
            ceiling.transform.localScale = new Vector3(ceiling.transform.localScale.x, ceiling.transform.localScale.y, 100);
            ceiling.GetComponent<MeshRenderer>().material = bigCeiling;
            //scale walls
            wall1.transform.localScale = new Vector3(wall1.transform.localScale.x, wall1.transform.localScale.y, 100);
            wall2.transform.localScale = new Vector3(wall2.transform.localScale.x, wall2.transform.localScale.y, 100);
            wall1.GetComponent<MeshRenderer>().material = bigWall;
            wall2.GetComponent<MeshRenderer>().material = bigWall;
            //fixing textures on floor and cieling and walls
            //reassign the material?

            monsterCounter++;
        }
        if (backTo1 && monsterCounter == 1)
        {
            //change light color
            light1_ceiling.color = Color.green;
            light1_model.material = greenLightMat;
            monsterCounter++;
        }
        if (backTo2 && monsterCounter == 2)
        {
            //Turn the timer 
            timer2_obj.transform.localScale = new Vector3(timer2_obj.transform.localScale.x, timer2_obj.transform.localScale.y * -1, timer2_obj.transform.localScale.z);
            monsterCounter++;
        }

    }

    // Use this for initialization
    void Start () {
        speed = 6f;

        button1Timer = 1200;
        button2Timer = 1200;

        button1Rest = 0;
        button2Rest = 0;

        button1Pushed = false;
        button2Pushed = false;

        //All Monsters start invisible
        testMonster.GetComponent<MeshRenderer>().enabled = false;

        backTo2 = false;
        backTo1 = true;

        monsterCounter = 0;
    }
	
	// Update is called once per frame
	void Update () {

        //Handle player movement ->See Camera Controller
        //They did this way way way better than I did
        //////////////////////////////////////////////////

        //Get player's input for what direction they want to go in
        float z = Input.GetAxis("Vertical") * Time.deltaTime;
        gameObject.transform.position += z * cam.transform.forward * speed;

        if (collide)
        {
            collide = false;
            speed = 2;
        }
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
        //Freeze Y movement
        this.gameObject.transform.position = new Vector3(gameObject.transform.position.x, 0.93f, gameObject.transform.position.z);

        //Check to see if the player is looking at a button
        //////////////////////////////////////////////////
        //Cast a ray from screen center into space
        Ray ray = cam.GetComponent<Camera>().ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f));
        //Debug.DrawRay(ray.origin, ray.direction * 10f, Color.red);//show the debug ray
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 10f)) //the 10f is the length the ray extends in distance
        {
            //A collision occured between the ray and a thing
            if (hit.collider == buttonCol)
            {
                //Was the collision on Button 1
                if (Input.GetKeyDown(KeyCode.E))
                {
                    //If the player clicks while looking at the button:
                    //Register the button click
                    button1Pushed = true;
                    button1Rest = 0;
                    //You aren't looking at button 2
                    backTo1 = false;
                    backTo2 = true;
                    //play the animation
                    button1.SetBool("isPushed",true);
                }
                else
                {
                    button1.SetBool("isPushed", false);
                }
            }
            if (hit.collider == buttonCol2)
            {
                //Was the collision on Button 2
                if (Input.GetKeyDown(KeyCode.E))
                {
                    //If the player clicks while looking at the button:
                    //Register the button click
                    button2Pushed = true;
                    button2Rest = 0;
                    //You aren't looking at button 1
                    backTo1 = true;
                    backTo2 = false;
                    //play the animation
                    button2.SetBool("isPushed", true);
                }
                else
                {
                    button2.SetBool("isPushed", false);
                }

            }
        }
      
        //Handle Timers
        //////////////////////////////////////////////////
        //A timer will decrement as long as the player is not pressing that button
        

        if (!button1Pushed)
        {
            button1Timer--;
        }
        else
        {
            //See if the player has pushed this button recently
            button1Rest++;
            if(button1Rest > 15)
            {
                //if X frames have passed, start the count again
                button1Rest = 0;
                button1Pushed = false;

            }
        }
        if (!button2Pushed)
        {
            button2Timer--;
        }
        else
        {
            //See if the player has pushed this button recently
            button2Rest++;
            if (button2Rest > 15)
            {
                //if X frames have passed, start the count again
                button2Rest = 0;
                button2Pushed = false;

            }
        }
        // Debug.Log(button1Timer + " " + button2Timer);
     


        //Check for ending
        if(button1Timer <= 0 || button2Timer <= 0)
        {
            //If either timer hits zero, game is over
            //Display the player's time as a score
            end_text.text = "You've got a one track mind.\nTime survived: " + Mathf.Round(totalTime / 30) + " seconds.";
            button1Timer_text.text = "00:00";
            button2Timer_text.text = "00:00";
        }
        else
        {
            button1Timer_text.text = "Button 1 Timer: " + button1Timer / 30;
            button2Timer_text.text = "Button 2 Timer: " + button2Timer / 30;
            button2Timer_world.text = "00:" + button2Timer / 30;
            button1Timer_world.text = "00:" + button1Timer / 30;

            totalTime++;
        }

        //Handle Creepy Events when player's back is turned
        CheckMonster();

    }
}
