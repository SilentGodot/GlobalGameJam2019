using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DespawnAfterSec : MonoBehaviour {

    public float sec = 10f;
    bool timerStarted = false;
    void Start()
    {
    }

    IEnumerator LateCall()
    {

        yield return new WaitForSeconds(sec);

        gameObject.SetActive(false);
    }

    void Update()
    {
        if (gameObject.activeInHierarchy && !timerStarted)
            StartCoroutine(LateCall());

    }
}
