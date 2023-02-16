using System;
using System.Collections;
using System.Collections.Generic;
using FMOD.Studio;
using UnityEngine;
using FMODUnity;

public class AudioManager : MonoBehaviour
{
    #region Singleton

    public static AudioManager Instance;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            DestroyImmediate(gameObject);
            return;
        }

        Instance = this;
        _eventInstances = new List<EventInstance>();
    }

    #endregion

    private List<EventInstance> _eventInstances;

    public void PlayOneShot(EventReference sound, Vector3 worldPos)
    {
        RuntimeManager.PlayOneShot(sound, worldPos);
    }

    public EventInstance CreateInstance(EventReference eventReference)
    {
        EventInstance eventInstance = RuntimeManager.CreateInstance(eventReference);
        _eventInstances.Add(eventInstance);
        return eventInstance;
    }

    private void CleanUp()
    {
        foreach (var eventInstance in _eventInstances)
        {
            eventInstance.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
            eventInstance.release();
        }
    }

    private void OnDestroy()
    {
        CleanUp();
    }

    private void Start()
    {
        PlayOneShot(FMODEvents.Instance.RelaxedTheme, transform.position);
    }
}