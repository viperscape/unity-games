using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour {
    public MonsterSelect.MonsterKind favorite;
    private GameObject monster;
    Rigidbody rb;
    private float birth_time = 0;

    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody>();
    }
	
	// Update is called once per frame
	void Update () {
        if ((birth_time > 0) && ((Time.fixedTime - birth_time) > 2.25))
            Destroy(gameObject);
    }

    private void OnMouseUp()
    {
        if (Vector3.Distance(monster.transform.position, transform.position) < 0.3)
        {
            GameObject monster = Globals.GetMonster();
            Animator anim = monster.GetComponent<Animator>();

            AudioSource aud = monster.GetComponent<AudioSource>();

            if (favorite == Globals.MonsterKind)
            {
                anim.Play("attack");
                aud.clip = monster.GetComponent<MonsterController>().FoodFavorite;
            }
            else
            {
                aud.clip = monster.GetComponent<MonsterController>().FoodDislike;
                anim.Play("damage");
            }

            
            aud.Play();
            Destroy(gameObject);
        }
        else
        {
            rb.isKinematic = false;
            rb.velocity = Vector3.zero;
            rb.AddForce(0,1,5, ForceMode.Impulse);

            birth_time = Time.fixedTime;
        }

    }

    private void OnMouseDown()
    {
        monster = Globals.GetMonster();
        rb.isKinematic = true;
    }

    private void OnMouseDrag()
    {
        transform.position = Globals.Cam.ScreenToWorldPoint
            (new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0.925f));// FIXME: monster.transform.position.z));
    }
}
