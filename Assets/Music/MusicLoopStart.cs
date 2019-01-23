using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicLoopStart : MonoBehaviour
{
    public string tagName;

    void Start()
    {
        GameObject.FindGameObjectWithTag(tagName).GetComponent<MenuMusicLoop>().PlayMusic();
    }
}
