using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class launch : MonoBehaviour {

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
        attackObj.transform.position = playerObj.position + new Vector2(0.2f, 0f);
    }


    // Use this for initialization
    void Start () {
        attackObj.SetActive(false);

    }
	
	// Update is called once per frame
	void Update () {
        Move();

        if (Input.GetKeyDown(KeyCode.Z))
        {
            
            Activated = true;
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
