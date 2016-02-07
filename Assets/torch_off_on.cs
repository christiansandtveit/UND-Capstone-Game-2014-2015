using UnityEngine;
using System.Collections;

public class torch_off_on : Activatable{

    private Light[] lights;
    private ParticleSystem flames;
    private bool isActive = true;

    public bool Active
    {
        get { return isActive; }
    }

    void Awake()
    {
        lights = gameObject.GetComponentsInChildren<Light>();
        flames = gameObject.GetComponentInChildren<ParticleSystem>();
    }

    void Update()
    {
        if (isActive == true)
        {
            if (GetComponent<AudioSource>().isPlaying == false)
            {
                GetComponent<AudioSource>().Play();
            }
        }
        else
        {
            GetComponent<AudioSource>().Stop();
        }
    }

    public override void Deactivate()
    {
        isActive = false;
        for (int i = 0; i < lights.Length; i++)
        {
            lights[i].enabled = false;
        }
        flames.Pause();
        flames.Clear();
    }

    public override void Activate()
    {
        isActive = true;
        for (int i = 0; i < lights.Length; i++)
        {
            lights[i].enabled = true;
        }
        flames.Play();
    }

    public void Toggle()
    {
        if (isActive)
        {
            isActive = false;
            for (int i = 0; i < lights.Length; i++)
            {
                lights[i].enabled = false;
            }
            flames.Pause();
            flames.Clear();
        }
        else
        {
            isActive = true;
            for (int i = 0; i < lights.Length; i++)
            {
                lights[i].enabled = true;
            }
            flames.Play();
        }
    }

    public override void Reset() { }
}
