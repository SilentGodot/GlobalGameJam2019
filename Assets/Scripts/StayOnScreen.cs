using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StayOnScreen : MonoBehaviour {

    public float xMargin = 0.03f;
    public float yMargin = 0.04f;

	// Use this for initialization
	void Start () {
		
	}

    // Update is called once per frame
    void Update()
    {
        // Stay on screen!!!
        Vector3 pos = Camera.main.WorldToViewportPoint(transform.position);
        pos.x = Mathf.Clamp(pos.x, xMargin, 1f - xMargin);
        pos.y = Mathf.Clamp(pos.y, yMargin, 1f - yMargin);
        transform.position = Camera.main.ViewportToWorldPoint(pos);
    }
}
