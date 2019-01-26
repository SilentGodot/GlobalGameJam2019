using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GhostCounter : Events.Tools.MonoBehaviour_EventManagerBase, Events.Groups.Fear.IAll_Group_Events
{

    [SerializeField] public List<GhostTrigger> triggers;
    public Image spookImage;
    public Image foreground;
    public float foregroundDarkenStep = 0.1f;
    public float timeOnScreen;

    private uint fearCount = 0;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void FearDies()
    {
        fearCount++;
        var triggeredTriggers = triggers.FindAll(x => x.Count == fearCount);

        for (int i = 0; i < triggeredTriggers.Count; i++)
        {
            var trigger = triggeredTriggers[i];
            StartCoroutine(ShowImage(trigger.Image));
        }
    }

    public void FearsFlee()
    {
    }

    public IEnumerator ShowImage(Sprite im)
    {
        spookImage.sprite = im;

        // show spooktext
        spookImage.enabled = true;
        // Play spooky sound
        GetComponent<AudioSource>().Play();
        // shake screen
        CameraShake.Shake(timeOnScreen/3, 0.09f);
        //darken foreground
        var c = foreground.color;
        c.a += foregroundDarkenStep;
        foreground.color = c;

        //wait and remove image
        yield return new WaitForSeconds(timeOnScreen);
        spookImage.enabled = false;
    }
}

[System.Serializable]
public class GhostTrigger
{
    [SerializeField] private uint count;
    [SerializeField] private Sprite image; 

    public uint Count
    {
        get
        {
            return count;
        }

        set
        {
            count = value;
        }
    }

    public Sprite Image
    {
        get
        {
            return image;
        }

        set
        {
            image = value;
        }
    }
}
