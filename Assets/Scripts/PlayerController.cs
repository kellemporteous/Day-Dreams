using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    /*

    private Rigidbody sonRB;
    private Rigidbody motherRB;

    public float audioTimer;
    */
    public float speed;
    public AudioClip footStep;

    public GameObject son;
    public GameObject mother;
    public GameObject activePlayer;
    public GameObject deactivePlayer;

    public float audioTimer;

    private Transform myTransform;


    public enum MotherState
    {
        motherIdle,
        motherActive
    }

    public enum SonState
    {
        sonIdle,
        sonActive
    }

    public MotherState motherState;
    public SonState sonState;


    
	// Use this for initialization
	void Start ()
    {
        /*sonRB = GameObject.FindGameObjectWithTag("Son").GetComponent<Rigidbody>();
        motherRB = GameObject.FindGameObjectWithTag("Mother").GetComponent<Rigidbody>();*/



        son = GameObject.FindGameObjectWithTag("Son");
        mother = GameObject.FindGameObjectWithTag("Mother");
        activePlayer = this.gameObject;

    }

    // Update is called once per frame
    void Update ()
    {
        AILogic();
        AIBehaviour();

        if (audioTimer > 0)
        {
            audioTimer -= Time.deltaTime;
        }
        if (audioTimer < 0)
        {
            audioTimer = 0;
        }
    }

    void AILogic()
    {
        if (CameraController.Instance.sonOn == true)
        {
            sonState = SonState.sonActive;
            motherState = MotherState.motherIdle;
        }
        else if (CameraController.Instance.motherOn == true)
        {
            sonState = SonState.sonIdle;
            motherState = MotherState.motherActive;
        }

        if (sonState == SonState.sonActive)
        {
            activePlayer = son;
            deactivePlayer = mother;
        }

        else if (motherState == MotherState.motherActive)
        {
            activePlayer = mother;
            deactivePlayer = son;
        }
    }

    void AIBehaviour()
    {
        switch (sonState)
        {
            case SonState.sonActive:
                Movement();
                break;
            case SonState.sonIdle:
                Idle();
                break;
        }

        switch (motherState)
        {
            case MotherState.motherActive:
                Movement();
                break;
            case MotherState.motherIdle:
                Idle();
                break;
        }
    }

    void Movement()
    {
        if (Input.GetKey(KeyCode.D))
        {
            activePlayer.transform.position = new Vector3(activePlayer.transform.position.x + speed * Time.deltaTime, activePlayer.transform.position.y, activePlayer.transform.position.z);

            if (audioTimer == 0)
            {
                SoundConroller.soundController.PlaySound(footStep);
                audioTimer = 0.9f;
            }
        }
        if (Input.GetKey(KeyCode.A))
        {
            activePlayer.transform.position = new Vector3(activePlayer.transform.position.x - speed * Time.deltaTime, activePlayer.transform.position.y, activePlayer.transform.position.z);

            if (audioTimer == 0)
            {
                SoundConroller.soundController.PlaySound(footStep);
                audioTimer = 0.9f;
            }
        }
        if (Input.GetKey(KeyCode.W))
        {
            activePlayer.transform.position = new Vector3(activePlayer.transform.position.x, activePlayer.transform.position.y, activePlayer.transform.position.z + speed * Time.deltaTime);

            if (audioTimer == 0)
            {
                SoundConroller.soundController.PlaySound(footStep);
                audioTimer = 0.9f;
            }
        }
        if (Input.GetKey(KeyCode.S))
        {
            activePlayer.transform.position = new Vector3(activePlayer.transform.position.x, activePlayer.transform.position.y, activePlayer.transform.position.z - speed * Time.deltaTime);

            if (audioTimer == 0)
            {
                SoundConroller.soundController.PlaySound(footStep);
                audioTimer = 0.9f;
            }
        }
    }

    void Idle()
    {
        /*if (CameraController.Instance.sonOn == true)
        {
            motherRB.isKinematic = true;
            sonRB.isKinematic = false;
        }
        if (CameraController.Instance.motherOn == true)
        {
            sonRB.isKinematic = true;
            motherRB.isKinematic = false;
        }*/
    }
}
