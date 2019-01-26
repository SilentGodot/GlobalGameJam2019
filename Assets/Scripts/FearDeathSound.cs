using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FearDeathSound : Events.Tools.MonoBehaviour_EventManagerBase, Events.Groups.Fear.IAll_Group_Events
{
    [SerializeField] AudioClip fearDeath;
    public void FearDies()
    {
        GetComponent<AudioSource>().PlayOneShot(fearDeath);
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
