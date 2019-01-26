using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DigitalRuby.Tween;

public class attackFunc : Events.Tools.MonoBehaviour_EventManagerBase, Events.Groups.Level.IAll_Group_Events
{

    [SerializeField] Rigidbody2D playerObj;
    [SerializeField] GameObject attackObj;
    [SerializeField] int lastKey; // for enum
    [SerializeField] SpriteRenderer img;
    [SerializeField] PolygonCollider2D attackCollider;
    [SerializeField] ParticleSystem particle1;
    [SerializeField] ParticleSystem particle2;
    [SerializeField] AudioClip swingSound;

    //    [SerializeField] Quaternion rot; // Nice for figuring out angles


    bool activated;
    float attackTime;
    bool haveAxe = false;

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

    public void OnLevelEnd()
    {
    }

    public void OnLevelStart()
    {
        haveAxe = true;
    }


    // Use this for initialization
    void Start () {
        attackObj.SetActive(true);
        lastKey = 276;
        img.enabled = false;//MAKE INVISIBLE
        attackCollider.enabled = false;
        particle1.Stop();
        particle2.Stop();
    }

    // Update is called once per frame
    void Update () {
        if (!haveAxe)
            return;

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
           img.enabled = true;//MAKE VISIBLE
           attackCollider.enabled = true;

            particle1.Play();
            particle2.Play();
            particle1.transform.parent = attackObj.transform;
            particle2.transform.parent = attackObj.transform;
            GetComponent<AudioSource>().PlayOneShot(swingSound);


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
            TweenFactory.Tween(null, startAngle, endAngle, 0.3f, TweenScaleFunctions.Linear, updateQuat);

            //*/

            
            AttackTime = 0.3f;

        }
        
        

        if (AttackTime > 0)
        {
            AttackTime -= Time.deltaTime;
            if (AttackTime < 0f)
            {
                Activated = false;
                img.enabled = false; //MAKE INVISIBLE
                attackCollider.enabled = false;
                particle1.Stop();
                particle2.Stop();
            }


        }
    }

}

class PositionReferences : MonoBehaviour
{

    public Transform[] positions;
    private int index = 0;

    public Vector3 GetNextPosition()
    {
        Vector3 result = positions[index].localPosition;
        index = index + 1;
        return result;
    }
}
