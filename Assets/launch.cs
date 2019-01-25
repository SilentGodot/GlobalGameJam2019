using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class launch : MonoBehaviour {

    [SerializeField] Rigidbody2D playerObj;
    [SerializeField] Transform attackObj;

    
    bool activated;

    public bool Activated
    {
        get
        {
            return activated;
        }

        set
        {
            activated = value;
        }
    }

    public void Move()
    {

        attackObj.position = playerObj.position + new Vector2(0.2f,0f);
       

    }


    // Use this for initialization
    void Start () {

		
	}
	
	// Update is called once per frame
	void Update () {
        Move();

        if (Input.GetButton("z"))
            Activated = true;

    }
}
