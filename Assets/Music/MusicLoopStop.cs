using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicLoopStop : MonoBehaviour
{
    public string tagName;

    void Start()
    {
        GameObject.FindGameObjectWithTag(tagName).GetComponent<MenuMusicLoop>().StopMusic();
    }
}
