using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float speed;
    public AudioClip footStep;

    private Rigidbody sonRB;
    private Rigidbody motherRB;

    public float audioTimer;

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
        sonRB = GameObject.FindGameObjectWithTag("Son").GetComponent<Rigidbody>();
        motherRB = GameObject.FindGameObjectWithTag("Mother").GetComponent<Rigidbody>();

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
        if (CameraController.Instance.motherOn == true)
        {
            sonState = SonState.sonIdle;
            motherState = MotherState.motherActive;
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
            if (CameraController.Instance.sonOn == true)
            {
                sonRB.AddForce(Vector3.right * speed * Time.deltaTime);
            }
            else if (CameraController.Instance.motherOn == true)
            {
                motherRB.AddForce(Vector3.right * speed * Time.deltaTime);
            }

            if (audioTimer == 0)
            {
                SoundConroller.soundController.PlaySound(footStep);
                audioTimer = 0.9f;
            }
        }
        if (Input.GetKey(KeyCode.A))
        {
            if (CameraController.Instance.sonOn == true)
            {
                sonRB.AddForce(Vector3.left * speed * Time.deltaTime);
            }
            else if (CameraController.Instance.motherOn == true)
            {
                motherRB.AddForce(Vector3.left * speed * Time.deltaTime);
            }

            if (audioTimer == 0)
            {
                SoundConroller.soundController.PlaySound(footStep);
                audioTimer = 0.9f;
            }
        }
        if (Input.GetKey(KeyCode.W))
        {
            if (CameraController.Instance.sonOn == true)
            {
                sonRB.AddForce(Vector3.forward * speed * Time.deltaTime);
            }
            else if (CameraController.Instance.motherOn == true)
            {
                motherRB.AddForce(Vector3.forward * speed * Time.deltaTime);
            }

            if (audioTimer == 0)
            {
                SoundConroller.soundController.PlaySound(footStep);
                audioTimer = 0.9f;
            }
        }
        if (Input.GetKey(KeyCode.S))
        {
            if (CameraController.Instance.sonOn == true)
            {
                sonRB.AddForce(Vector3.back * speed * Time.deltaTime);
            }
            else if (CameraController.Instance.motherOn == true)
            {
                motherRB.AddForce(Vector3.back * speed * Time.deltaTime);
            }

            if (audioTimer == 0)
            {
                SoundConroller.soundController.PlaySound(footStep);
                audioTimer = 0.9f;
            }
        }
    }

    void Idle()
    {
        if (CameraController.Instance.sonOn == true)
        {
            motherRB.isKinematic = true;
            sonRB.isKinematic = false;
        }
        if (CameraController.Instance.motherOn == true)
        {
            sonRB.isKinematic = true;
            motherRB.isKinematic = false;
        }
    }
}
