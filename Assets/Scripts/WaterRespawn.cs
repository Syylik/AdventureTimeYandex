using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterRespawn : MonoBehaviour
{
    [SerializeField] Transform _pointSpawn;

    private void OnTriggerEnter(Collider other)
    {
        other.transform.position = _pointSpawn.position;
    }

}
