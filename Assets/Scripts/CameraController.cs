using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {
    public static CameraController Instance;

    public Camera sonPerspective;
    public Camera motherPerspective;

    public bool sonOn;
    public bool motherOn;


    void Awake()
    {
        Instance = this;
    }

    // Use this for initialization
    void Start ()
    {
        sonPerspective.enabled = true;
        motherPerspective.enabled = false;

        sonOn = true;
        motherOn = false;

	}
	
	// Update is called once per frame
	void Update ()
    {
        sonPerspective.cullingMask = ~(1 << 9);
        motherPerspective.cullingMask = ~(1 << 8);

        if (Input.GetMouseButtonDown(0))
        {
            sonPerspective.enabled = !sonPerspective.enabled;
            motherPerspective.enabled = !motherPerspective.enabled;

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
        }
	}
}
