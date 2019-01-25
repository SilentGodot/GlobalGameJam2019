using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class attackFunc : MonoBehaviour {

    [SerializeField] Rigidbody2D playerObj;
    [SerializeField] GameObject attackObj;

    bool activated;
    float attackTime;

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

    public float AttackTime
    {
        get
        {
            return attackTime;
        }

        set
        {
            attackTime = value;
        }
    }


    public void Move()
    {
        attackObj.transform.position = playerObj.position;
    }


    // Use this for initialization
    void Start () {
        attackObj.SetActive(false);
    }
	
	// Update is called once per frame
	void Update () {
        Move();

        if (Input.GetKey(KeyCode.Z) && (AttackTime <= 0))
        {
            
            Activated = true;
            // Change rotation according to pressed key
            
                if (Input.GetKey(KeyCode.UpArrow))
                    attackObj.transform.rotation = new Quaternion(1, 0, 0, 0); // pointing up
                else if (Input.GetKey(KeyCode.DownArrow))
                    attackObj.transform.rotation = new Quaternion(0, 1, 0, 0); // pointing down
                else if (Input.GetKey(KeyCode.LeftArrow))
                    attackObj.transform.rotation = new Quaternion(1, 1, 0, 0); // pointing left
                else if (Input.GetKey(KeyCode.RightArrow))
                    attackObj.transform.rotation = new Quaternion(-1, 1, 0, 0); // pointing right
                
            
            attackObj.SetActive(true);//MAKE VISIBLE
            AttackTime = 0.2f;

        }
        
        

        if (AttackTime > 0)
        {
            AttackTime -= Time.deltaTime;
            if (AttackTime < 0f)
            {
                Activated = false;
                attackObj.SetActive(false); //MAKE INVISIBLE
            }


        }
    }
}
