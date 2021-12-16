using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public List<AudioSource> sfx;
    public List<AudioSource> music;

    public void SwitchMusic(int index)
    {
        foreach (AudioSource thing in music) thing.Stop();
        music[index].Play();
    }
    public void PlaySound(int index)
    {
        sfx[index].Play();
    }
}
