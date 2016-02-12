//codded by matthew nelson
using UnityEngine;
using System.Collections;

public class torch_off_on : Activatable{

    private Light[] lights;//array of lights
    private ParticleSystem[] flames;//array of flames
    private AudioSource[] audios;//array of audios
    private bool isActive = true; //if the lights or on or off
    public bool On = true;//if the lights flames and audios should be on on start up

    public bool Active
    {
        get { return isActive; }
    }
    //start up funtion
    void Awake()
    {
        lights = gameObject.GetComponentsInChildren<Light>();//get all lights that are children of this object
        flames = gameObject.GetComponentsInChildren<ParticleSystem>();//get all flames that are children of this object
        audios = GetComponents<AudioSource>();//get all audios that are children of this object
        if (!On)//if the lights are to be off on start shut them off
        {
            isActive = false;
            for (int i = 0; i < lights.Length; i++)//shuts all lights off
            {
                lights[i].enabled = false;
            }
            for (int i = 0; i < flames.Length; i++)//turns all flames off
            {
                flames[i].Pause();
                flames[i].Clear();
            }

        }
    }

    void Update()//function that runs once every frame 
    {
        if (isActive == true)//if the lights are on
        {
            for (int i = 0; i < audios.Length; i++)//turn audios that were found as children of this object on
            {
                if (audios[i].isPlaying == false)//if the audio is off turn them on
                {
                    audios[i].Play();
                }
            }
        }
        else//turn audios that were found as children of this object off
        {
            for (int i = 0; i < audios.Length; i++)
            {
                audios[i].Stop();
            }
        }
    }
    //turn the lights and flames off 
    public override void Deactivate()
    {
        isActive = false;
        for (int i = 0; i < lights.Length; i++)
        {
            lights[i].enabled = false;
        }
        for (int i = 0; i < flames.Length; i++)
        {
            flames[i].Pause();
            flames[i].Clear();
        }

    }
    //turn the lights and flames on 
    public override void Activate()
    {
        isActive = true;
        for (int i = 0; i < lights.Length; i++)
        {
            lights[i].enabled = true;
        }
        for (int i = 0; i < flames.Length; i++)
        {
            flames[i].Play();
        }
    }
    //flip between on and off for lights and flame
    public void Toggle()
    {
        if (isActive)
        {
            isActive = false;
            for (int i = 0; i < lights.Length; i++)
            {
                lights[i].enabled = false;
            }
            for (int i = 0; i < flames.Length; i++)
            {
                flames[i].Pause();
                flames[i].Clear();
            }
        }
        else
        {
            isActive = true;
            for (int i = 0; i < lights.Length; i++)
            {
                lights[i].enabled = true;
            }
            for (int i = 0; i < flames.Length; i++)
            {
                flames[i].Play();
            }
        }
    }
    //do nothing on reset (may want to find out player pasition and find out if the light should be on or off)
    public override void Reset() { }
}
