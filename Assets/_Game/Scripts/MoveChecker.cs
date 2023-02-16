using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMOD.Studio;

public class MoveChecker : MonoBehaviour
{
    private Vector3 lastPos;
    private EventInstance rabbitSteps;

    private void Start()
    {
        lastPos = transform.position;
        rabbitSteps = AudioManager.Instance.CreateInstance(FMODEvents.Instance.RabbitSteps);
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position - lastPos != Vector3.zero)
        {
            rabbitSteps.getPlaybackState(out PLAYBACK_STATE playbackState);
            if(playbackState.Equals(PLAYBACK_STATE.STOPPED))
            {
                rabbitSteps.start();
            }
        }
        else
        {
            rabbitSteps.stop(STOP_MODE.ALLOWFADEOUT);
        }

        lastPos = transform.position;
    }
}
