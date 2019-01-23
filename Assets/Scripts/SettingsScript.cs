using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsScript : MonoBehaviour
{
    public static float masterVolume;
    public Slider volumeSLider;
    AudioSource _audio;


    // Start is called before the first frame update
    void Awake()
    {
        volumeSLider = GameObject.Find("Slider").GetComponent<Slider>();
        _audio = GameObject.FindGameObjectWithTag("Music").GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        print(_audio.volume);
        masterVolume = volumeSLider.value;
        _audio.volume = masterVolume;
    }
}
