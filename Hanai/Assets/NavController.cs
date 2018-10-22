using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NavController : MonoBehaviour {
    public float speed = 1.0f;

    private Waypoint waypoint;
    private int current = 0;
    private Rigidbody rb;

	// Use this for initialization
	void Start () {
        waypoint = GetComponentInParent<Waypoint>();
        rb = GetComponent<Rigidbody>();
    }
	
	// Update is called once per frame
	void Update () {
        if ((waypoint == null) || (waypoint.waypoints == null)) return;

        if (waypoint.waypoints.Count > current)
        {
            transform.LookAt(waypoint.waypoints[current].transform);
            rb.velocity = transform.TransformDirection(0, 0, speed);

            if (Vector3.Distance(transform.position, waypoint.waypoints[current].transform.position) < 1)
            {
                current++;
            }
        }
        else
        {
            current = 0;
        }
    }
}
