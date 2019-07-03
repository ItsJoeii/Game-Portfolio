using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public float panSpeed = 4f;

    private Vector3 mouseOrigin;
    private bool isPanning;

	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        mouseOrigin = Input.mousePosition;

        if (Input.GetMouseButtonDown(1))
        {
            mouseOrigin = Input.mousePosition;
            isPanning = true;
        }
        if (!Input.GetMouseButton(1))
        {
            isPanning = false;
        }
        if (isPanning)
        {
            Vector3 pos = Camera.main.ScreenToViewportPoint(Input.mousePosition - Input.mousePosition);
            Vector3 move = new Vector3(pos.x * panSpeed, pos.y * panSpeed, 0);

            Camera.main.transform.Translate(move, Space.Self);
        }
	}
}
