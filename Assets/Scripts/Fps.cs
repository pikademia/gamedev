using System.Collections;
using UnityEngine;

public class Fps : MonoBehaviour
{
    private float count;

    private IEnumerator Start()
    {
        while (true)
        {
            count = 1f / Time.unscaledDeltaTime;
            yield return new WaitForSeconds(0.2f);
        }
    }

    private void OnGUI()
    {
        GUI.depth = 2;
        GUI.skin.label.fontSize = 40;
        GUI.color = Color.white;
        Rect location = new Rect(40, 40, 400, 60);
        string text = $"FPS: {Mathf.Round(count)}";
        GUI.Label(location, text);
    }

}
