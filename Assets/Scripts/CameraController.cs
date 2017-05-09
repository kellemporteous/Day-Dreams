using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    public Camera sonPerspective;
    public Camera motherPerspective;

    // Use this for initialization
    void Start ()
    {
        sonPerspective.enabled = true;
        motherPerspective.enabled = false;
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
        }
	}
}
