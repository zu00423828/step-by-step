using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class color : MonoBehaviour {
    // Use this for initialization
    SpriteRenderer r;
    void Start () {
        //r.color = new Color(255f, 255f, 255f, 160 / 255f);
	}
	
	// Update is called once per frame
	void Update () {
        if(Input.GetKey(KeyCode.Space))
            gameObject.GetComponentInChildren<SpriteRenderer>().color =new Color(255f, 255f, 255f, 160 / 255f);
        if(Input.GetKey(KeyCode.Z))
            gameObject.GetComponentInChildren<SpriteRenderer>().color = new Color(255f, 255f, 255f, 255 / 255f);

    }

}
