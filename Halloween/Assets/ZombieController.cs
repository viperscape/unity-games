using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieController : MonoBehaviour {
    public List<GameObject> waypoints;
    public float speed = 7f;

    private int current = 0;
    private Rigidbody rb;
    private Animator anim;

    public float wait = 1.8f;
    private float last_wait = 0;

    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void Update () {
        if (Time.fixedTime - last_wait < wait) return;

        if (waypoints.Count > current)
        {
            rb.transform.LookAt(waypoints[current].transform);
            rb.MovePosition(transform.position + transform.forward * ((speed * Time.deltaTime) / 10));

            if (Vector3.Distance(rb.transform.position, waypoints[current].transform.position) < 1)
            {
                last_wait = Time.fixedTime;
                    anim.Play("idle");

                current++;
            }
        }
        else
        {
            current = 0;
        }
    }

    private void OnDrawGizmos()
    {
        if (waypoints == null) return;
        Gizmos.color = new Color(1f, 1f, 1f);
        GameObject lw = null;
        foreach (var w in waypoints)
        {
            if (!w) continue;
            Vector3 p = w.transform.position;
            if (lw) p = lw.transform.position;

            Gizmos.DrawLine(p, w.transform.position);
            Gizmos.DrawWireSphere(w.transform.position, 0.1f);
            lw = w;
        }
    }

    private void OnMouseUp()
    {
        anim.Play("attack");
        AudioSource audio = GetComponentInParent<AudioSource>();
        audio.Play();
    }
}
