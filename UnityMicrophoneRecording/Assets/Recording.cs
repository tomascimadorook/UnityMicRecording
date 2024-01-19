using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Recording : MonoBehaviour
{

    // Not mandatory
    [SerializeField] AudioSource _audioSource;

    AudioClip _audioClip;

    public void Record()
    {
        _audioClip = Microphone.Start(null, true, 120, 44100);
        Debug.Log("Recording...");
    }

    public void Save()
    {
        Microphone.End(null);
        
        // Not mandatory
        _audioSource.clip = _audioClip;
        _audioSource.time = 0;
        _audioSource.Play();
       
        string path = SavWav.Save("MicTest", _audioSource.clip, true);
        Debug.Log("Saved to " + path);
    }
}
