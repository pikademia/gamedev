using System;
using UnityEngine;

public class Youtuber : MonoBehaviour
{
    public static event Action<string> NewVideo;


    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            NewVideo?.Invoke("https://www.youtube.com/watch?v=_f6gdsncpdY");
        }
    }

}
