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
    public ScoreController scoreController;
    public AudioClip rythmA;
    public AudioClip rythmB;
    public AudioClip dumsA;
    public AudioClip drumsB;
    public AudioClip bassA;
    public AudioClip bassB;
    public AudioClip leadA;
    public AudioClip leadB;
    public AudioClip transitionAB;
    public string musicTrack = "A";
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //switch to other song if combo is high enough
        if (scoreController.combo >= 10 && musicTrack == "A" && rythm.time >= rythm.clip.length-0.1f)
        {
            drums.Stop();
            lead.Stop();
            bass.Stop();
            rythm.clip = transitionAB;
            rythm.Play();
            musicTrack = "T";


        }
        if (musicTrack == "T" && rythm.time >= rythm.clip.length - 0.1f) {
            rythm.clip = rythmB;
            drums.clip = drumsB;
            lead.clip = leadB;
            bass.clip = bassB;
            rythm.Play();
            drums.Play();
            lead.Play();
            bass.Play();
            musicTrack = "B";
        }
        //engine sounds
        engineClip.pitch = rb.velocity.magnitude / 20 + Mathf.Abs(transform.InverseTransformDirection(rb.velocity).x) / 100;
        //airborn sounds and music
        if (carCon.airborn)
        {
            rythm.volume = Mathf.Lerp(rythm.volume, 1f, Time.fixedDeltaTime * musicShiftSpeed);
            drums.volume = Mathf.Lerp(drums.volume, 1f, Time.fixedDeltaTime * musicShiftSpeed); 
            lead.volume = Mathf.Lerp(lead.volume, 1f, Time.fixedDeltaTime * musicShiftSpeed);
            hiPassFilter.cutoffFrequency += 1;
        }
        else
        {
            hiPassFilter.cutoffFrequency = 0;
            //drifting sounds and music
            if (carCon.driftingBool)
            {
                skidClip.pitch = rb.velocity.magnitude / 20;
                lead.volume = Mathf.Lerp(lead.volume, rb.velocity.magnitude / 20, Time.fixedDeltaTime * musicShiftSpeed);
                if (!skidClip.isPlaying)
                {
                    skidClip.Play();
                }

            }
            else
            {
                lead.volume = Mathf.Lerp(lead.volume, 0.35f, Time.fixedDeltaTime * musicShiftSpeed);
                skidClip.Stop();
            }

            //boosting sounds and music
            if (carCon.boosting)
            {
                rythm.volume = Mathf.Lerp(rythm.volume, 1f, Time.fixedDeltaTime);
            }
            else
            {
                rythm.volume = Mathf.Lerp(rythm.volume, 0.35f, Time.fixedDeltaTime * musicShiftSpeed);
            }

            //driving sounds and music
            if (carCon.driving)
            {
                drums.volume = rb.velocity.magnitude / 20 + Mathf.Abs(transform.InverseTransformDirection(rb.velocity).x) / 30;
            }
            else
            {
                drums.volume = 0.5f;
            }
        }
    }
}
