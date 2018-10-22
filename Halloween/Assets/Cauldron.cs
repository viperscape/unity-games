using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cauldron : MonoBehaviour {
    public GameObject target;
    public MixPotions.Potions potion;
    private bool early = false; // track if mousedrag was too early
    private Scaler scaler;

    // Use this for initialization
    void Start () {
        scaler = GetComponent<Scaler>();
    }
	
	// Update is called once per frame
	void Update () {
	}

    void OnMouseUp()
    {
        if(!early) MixPotion();
        early = false;
    }

    private void OnMouseDrag()
    {
        if (scaler && scaler.isScaling())
        {
            early = true;
        }

        if (!early) // explicitly check early flag, we only clear it on mouseup
        {
            transform.position = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, target.transform.position.z));
        }
    }

    private void MixPotion()
    {
        if (Vector3.Distance(target.transform.position, transform.position) < 0.85)
        {
            target.GetComponent<MixPotions>().MixPotion(potion);
            if (scaler) scaler.RestartObject();
        }
        else
        {
            if (scaler) scaler.ResetObject();
        }
        
    }
}
