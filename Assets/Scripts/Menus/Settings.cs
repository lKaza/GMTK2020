using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class Settings : MonoBehaviour
{
    public AudioMixer audioMixer;

    private void Start() {
        audioMixer.SetFloat("volume",-20);
    }
    public void SetVolume(float volume){
        audioMixer.SetFloat("volume",volume);
    }
}
