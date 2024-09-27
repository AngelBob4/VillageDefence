using System.Collections.Generic;
using UnityEngine;

public class PauseService
{
    [SerializeField] private Dictionary<GameObject, bool> _pauseObjects = new Dictionary<GameObject, bool>();

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
    }

    public bool Unpause(GameObject gameObject)
    {
        _pauseObjects[gameObject] = false;

        if (_pauseObjects.ContainsValue(true))
            return false;
        else
            return true; 
    }
}