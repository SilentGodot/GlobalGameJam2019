using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DigitalRuby.Tween;

public class attackFunc : MonoBehaviour {

    [SerializeField] Rigidbody2D playerObj;
    [SerializeField] GameObject attackObj;
    [SerializeField] int lastKey; // for enum
//    [SerializeField] Quaternion rot; // Nice for figuring out angles


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
        lastKey = 276;
    }
	
	// Update is called once per frame
	void Update () {
        //attackObj.transform.rotation = rot; //GET RID O THIS AFTERWARDS
        System.Action<ITween<float>> updateQuat = (t) =>
        {
            // start rotation from identity to ensure no stuttering
            attackObj.transform.rotation = Quaternion.identity;
            attackObj.transform.Rotate(Camera.main.transform.forward, t.CurrentValue);
        };

        Move();

        if (Input.GetKey(KeyCode.Z) && (AttackTime <= 0))
        {
            
            Activated = true;
            // Change rotation according to pressed key

            if (Input.GetKey(KeyCode.UpArrow))
            {
                lastKey = 273;
                attackObj.transform.rotation = new Quaternion(1, 0.5f, 0, 0); // pointing up  
            }
            else if (Input.GetKey(KeyCode.DownArrow))
            {
                lastKey = 274;
                attackObj.transform.rotation = new Quaternion(-0.5f, 1, 0, 0); // pointing down
            }
            else if (Input.GetKey(KeyCode.LeftArrow))
            {
                lastKey = 276;
                attackObj.transform.rotation = new Quaternion(-2, 1, 0, 0);  // pointing left
            }
             else if (Input.GetKey(KeyCode.RightArrow))
            {
                lastKey = 275;
                attackObj.transform.rotation = new Quaternion(0.5f, 1, 0, 0);// pointing right

            }
            else
            {
                if (lastKey == 273) attackObj.transform.rotation = new Quaternion(1, 0.5f, 0, 0);
                else if (lastKey == 274) attackObj.transform.rotation = new Quaternion(-0.5f, 1, 0, 0);
                else if (lastKey == 276) attackObj.transform.rotation = new Quaternion(-2, 1, 0, 0);
                else if (lastKey == 275) attackObj.transform.rotation = new Quaternion(0.5f, 1, 0, 0);
            }
            //*
            float startAngle = attackObj.transform.rotation.eulerAngles.z;
            float endAngle = startAngle + 90.0f;
            TweenFactory.Tween(null, startAngle, endAngle, 0.2f, TweenScaleFunctions.Linear, updateQuat);
            
            //*/

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
