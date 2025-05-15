using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BKMusic : MonoBehaviour
{
    private static BKMusic instance;
    public static BKMusic Instance => instance;
    private AudioSource audioSource;
    private void Awake()
    {
        instance = this;
        audioSource = GetComponent<AudioSource>();
    }

    public void ChangeOpen(bool isOpen)
    {
        audioSource.mute = !isOpen;
    }

    public void ChangeValue(float value)
    {
        audioSource.volume = value;
    }
}
