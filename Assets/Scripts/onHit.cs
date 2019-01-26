using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class onHit : MonoBehaviour {

    [SerializeField] ParticleSystem death_particle;
    [SerializeField] SpriteRenderer img;
    [SerializeField] GameObject gameObj_fear;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    // Works when two objects have 'Is Trigger' turned off.
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Attack" && collision.gameObject.active)
        {
            img.enabled = false;
            death_particle.Play();
            // Detach children
            gameObj_fear.transform.DetachChildren();

            this.gameObject.SetActive(false);
            Events.Groups.Fear.Invoke.FearDies();
            //Destroy(gameObject);
        }

    }

}
