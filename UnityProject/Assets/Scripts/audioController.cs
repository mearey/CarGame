using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class audioController : MonoBehaviour
{
    public CarController carCon;
    public AudioSource skidClip;
    public AudioSource engineClip;
    public AudioSource rythm;
    public AudioSource drums;
    public AudioSource bass;
    public AudioSource lead;
    public AudioHighPassFilter hiPassFilter;
    public Rigidbody rb;
    public float musicShiftSpeed = 0.1f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //engine sounds
        engineClip.pitch = rb.velocity.magnitude / 20 + Mathf.Abs(transform.InverseTransformDirection(rb.velocity).x) / 100;
        //airborn sounds and music
        if (carCon.airborn)
        {
            rythm.volume = Mathf.Lerp(rythm.volume, 1f, Time.deltaTime*musicShiftSpeed);
            drums.volume = Mathf.Lerp(drums.volume, 1f, Time.deltaTime * musicShiftSpeed);
            lead.volume = Mathf.Lerp(lead.volume, 1f, Time.deltaTime * musicShiftSpeed);
            hiPassFilter.cutoffFrequency += 1;
        }
        else
        {
            hiPassFilter.cutoffFrequency = 0;
            //drifting sounds and music
            if (carCon.driftingBool)
            {
                skidClip.pitch = rb.velocity.magnitude / 20;
                lead.volume = Mathf.Lerp(lead.volume, rb.velocity.magnitude / 20, Time.deltaTime * musicShiftSpeed);
                skidClip.Play();
            }
            else
            {
                lead.volume = Mathf.Lerp(lead.volume, 0.2f, Time.deltaTime * musicShiftSpeed);
                skidClip.Stop();
            }

            //boosting sounds and music
            if (carCon.boosting)
            {
                rythm.volume = Mathf.Lerp(rythm.volume, 0.6f, Time.deltaTime * musicShiftSpeed);
            }
            else
            {
                rythm.volume = Mathf.Lerp(rythm.volume, 0, Time.deltaTime * musicShiftSpeed);
            }

            //driving sounds and music
            if (carCon.driving)
            {
                drums.volume = rb.velocity.magnitude / 20 + Mathf.Abs(transform.InverseTransformDirection(rb.velocity).x) / 70;
            }
            else
            {
                drums.volume = 0.3f;
            }
        }
    }
}
