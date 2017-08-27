using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {
    public static CameraController Instance;

    public bool sonOn;
    public bool motherOn;
    public bool first;

    public float rotationSpeed;
    public float travelSpeed;

    public float yaw;
    public float pitch;

    PlayerController player;

    public Camera cam;
    void Awake()
    {
        Instance = this;
    }

    // Use this for initialization
    void Start ()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();

        cam = Camera.main;

        sonOn = true;
        motherOn = false;
        first = true;

    }

    // Update is called once per frame
    void Update ()
    {
        if (first == true)
        {
            cam.transform.position = player.activePlayer.transform.position;
            first = false;
        }
        CameraRotation();
        SwitchPlayer();
    }

    void CameraRotation()
    {
        yaw += rotationSpeed * Input.GetAxis("Mouse X");
        pitch -= rotationSpeed * Input.GetAxis("Mouse Y");

        transform.eulerAngles = new Vector3(pitch, yaw, 0.0f);
    }

    void SwitchPlayer()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (sonOn == true)
            {
                sonOn = false;
                motherOn = true;
            }
            else if (motherOn == true)
            {
                sonOn = true;
                motherOn = false;
            }

            if (player.sonState == PlayerController.SonState.sonActive)
            {
                cam.cullingMask = ~(1 << 9);
            }

            else if (player.motherState == PlayerController.MotherState.motherActive)
            {
                cam.cullingMask = ~(1 << 8);
            }
        }
        cam.transform.position = Vector3.MoveTowards(cam.transform.position, player.activePlayer.transform.position, rotationSpeed * Time.deltaTime);

    }
}
