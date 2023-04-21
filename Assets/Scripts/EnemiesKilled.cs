using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;

public class EnemiesKilled : MonoBehaviour
{
    [SerializeField]private List<GameObject> _objsMustDied;

    public UnityEvent allObjDies;

    private int updateNum = 0;

    private void Update()
    {
        if(updateNum >= 15)
        {
            updateNum = 0;
            CheckDeads();
        }
        else updateNum++;
    }

    public void CheckDeads()
    {
        try
        {
            _objsMustDied = _objsMustDied.Where(баг => баг != null).ToList();
        }
        catch { allObjDies?.Invoke();
            Debug.Log($"catch");
        }

        Debug.Log($"----{_objsMustDied.Count}");
        if(_objsMustDied.Count <= 0) allObjDies?.Invoke();
    }
}
