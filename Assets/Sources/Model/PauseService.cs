using System.Collections.Generic;
using UnityEngine;

public class PauseService
{
    private Dictionary<GameObject, bool> _pauseObjects = new Dictionary<GameObject, bool>();

    public void Pause(GameObject gameObject)
    {
        if (_pauseObjects.ContainsKey(gameObject))
        {
            _pauseObjects[gameObject] = true;
        }
        else
        {
            _pauseObjects.Add(gameObject, true);
        }

        Time.timeScale = 0;
    }

    public void Unpause(GameObject gameObject)
    {
        _pauseObjects[gameObject] = false;

        Time.timeScale = _pauseObjects.ContainsValue(true) ? 0 : 1; 
    }
}