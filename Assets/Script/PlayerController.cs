using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MovementConroller))]
public class PlayerController : MonoBehaviour {

    private MovementConroller m_mover;
    private CameraController m_camera;

    // Mouse variables
    private Vector2 m_delta;
    private Vector2 m_currentMousePos;
    private Vector2 m_lastMousePos;
    // Use this for initialization
	void Start () {
        m_currentMousePos = m_lastMousePos;
        m_mover = this.GetComponent<MovementConroller>();
        m_camera = Camera.main.gameObject.GetComponent<CameraController>();
	}
	
	// Update is called once per frame
	void Update () {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");

        m_mover.Move(new Vector2(x, y), m_camera.transform.forward, m_camera.transform.right);

        //Move Camera

        m_currentMousePos = Input.mousePosition;

        if (Input.GetMouseButton(1))
        {
            m_delta = m_currentMousePos - m_lastMousePos;
            m_delta.x /= Screen.currentResolution.width;
            m_delta.y /= Screen.currentResolution.height;
        }
        else
        {
            m_delta = Vector2.zero;
        }

        m_lastMousePos = m_currentMousePos;

        m_camera.RotateBy(m_delta.y, m_delta.x);
        m_camera.ZoomBy(Input.GetAxis("Mouse ScrollWheel"));
    }
}
