using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour {
    public List<GameObject> waypoints;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnDrawGizmos()
    {
        if (waypoints == null) return;
        Gizmos.color = new Color(0f, 0f, 0f);
        GameObject lw = null;
        foreach(var w in waypoints)
        {
            if (!w) continue;
            Vector3 p = transform.position;
            if (lw) p = lw.transform.position;

            Gizmos.DrawLine(p, w.transform.position);
            Gizmos.DrawWireSphere(w.transform.position, 0.1f);
            lw = w;
        }
    }
}
