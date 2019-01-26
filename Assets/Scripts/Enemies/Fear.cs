using System.Collections;
using System.Collections.Generic;
using Events;
using UnityEngine;

public class Fear : MonoBehaviour


{
    [SerializeField] private GameObject instance;
    [SerializeField] private SplineWalker walker;

    public GameObject Instance
    {
        get { return instance; }
    }

    public SplineWalker Walker
    {
        get
        {
            return walker;
        }

        set
        {
            walker = value;
        }
    }


    // Use this for initialization
    void Start()
    {

    }



    public void ResetInstance()
    {
        gameObject.SetActive(false);
    }

    public void InitInstance()
    {
        gameObject.SetActive(true);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // TODO Collision with sword?

        // if (collision.tag == "FearDestroyer")
        //    ResetInstance();

    }
}
