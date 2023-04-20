using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Portal2 : MonoBehaviour
{
    [SerializeField]UnityEvent _onPortalEnter;
    private void OnTriggerEnter(Collider other)
    {
        _onPortalEnter?.Invoke();
    }
}

