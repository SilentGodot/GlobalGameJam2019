using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClipPlaylist : MonoBehaviour {
    [SerializeField] List<AudioClip> clips;
    [SerializeField] bool shuffle = true;

    private AudioSource m_audio;
    private int m_ind = 0;

	// Use this for initialization
	void Start () {
        m_audio = GetComponent<AudioSource>();
        
        if (!m_audio.playOnAwake)
        {
            m_ind = shuffle ? 
                Random.Range(0, clips.Count) : 
                m_ind % clips.Count;
            m_audio.clip = clips[m_ind++];
            m_audio.Play();
        }
    }
	
	// Update is called once per frame
	void Update () {

        if (!m_audio.isPlaying)
        {
            m_ind = shuffle ?
                Random.Range(0, clips.Count) :
                m_ind % clips.Count;
            m_audio.clip = clips[m_ind++];
            m_audio.Play();
        }
    }
}
