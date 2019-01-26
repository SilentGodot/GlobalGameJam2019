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
        instance.SetActive(false);
    }

    public void InitInstance()
    {
        instance.SetActive(true);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // TODO Collision with sword?

        // if (collision.tag == "FearDestroyer")
        //    ResetInstance();

    }

    public void FlyAwayFromPlayer(Vector3 player_location, float speed)
    {
        Vector3 my_location = instance.transform.position;
        var direction_from_player = my_location - player_location;
        // direction_from_player = Quaternion.Euler(0, 0, -180) * direction_from_player;
        
    }
}
