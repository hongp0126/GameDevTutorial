using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Camera))]
public class CameraController : MonoBehaviour {

    public GameObject Target;

    public float phi;
    public float theta;
    public float Distance = 4.0f;

    public float RotateSpeed = 30;
    // Use this for initialization
	void Start () {
        
    }
	
	// Update is called once per frame
	void Update () {
        float x = Distance * Mathf.Sin(Mathf.Deg2Rad * theta) * Mathf.Cos(Mathf.Deg2Rad * phi);
        float z = Distance * Mathf.Sin(Mathf.Deg2Rad * theta) * Mathf.Sin(Mathf.Deg2Rad * phi);
        float y = Distance * Mathf.Cos(Mathf.Deg2Rad * theta);

        this.transform.position = new Vector3(x, y, z) + Target.transform.position;

        this.transform.LookAt(Target.transform);
    }

    public void RotateBy(float theta, float phi)
    {
        this.phi += phi * RotateSpeed ;
        this.theta += theta * RotateSpeed;
    }
    public void ZoomBy(float amt)
    {
        Distance += amt;
    }
}
