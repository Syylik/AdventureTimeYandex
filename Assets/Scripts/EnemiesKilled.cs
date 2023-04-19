using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemiesKilled : MonoBehaviour
{
    private List<GameObject> _objsMustDied;

    public UnityEvent allObjDies;

    private void Awake()
    {
        foreach(var obj in FindObjectsOfType<Enemy>()) _objsMustDied.Add(obj.gameObject);
        foreach(var obj in FindObjectsOfType<Target>()) _objsMustDied.Add(obj.gameObject);
    }

    public void CheckDeads()
    {
        _objsMustDied.RemoveAll(null);
        if(_objsMustDied.Count <= 0) allObjDies?.Invoke();
    }
}
