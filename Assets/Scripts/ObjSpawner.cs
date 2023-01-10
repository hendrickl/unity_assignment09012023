using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjSpawner : MonoBehaviour
{
    [SerializeField] private float _thrust;
    [SerializeField] private float _repeatRate = 3f;
    [SerializeField] private float _distanceToCam = 5.0f;
    [SerializeField] private GameObject _objtToSpawn;
    [SerializeField] private Vector3 _spawnPosition;

    void Start()
    {
        InvokeRepeating("InstantiateObjFrontOf", 3f, _repeatRate);
    }

    void InstantiateObjFrontOf()
    {
        _spawnPosition = new Vector3(Random.Range(0, Screen.width), Random.Range(0, Screen.height), _distanceToCam);
        Vector3 worldPosition = Camera.main.ScreenToWorldPoint(_spawnPosition);

        GameObject prefab = Instantiate(_objtToSpawn, worldPosition, Quaternion.identity);
        prefab.GetComponent<Rigidbody>().AddForce(0, 0, -_thrust, ForceMode.Impulse);
    }
}
