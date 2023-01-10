using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjSpawner : MonoBehaviour
{
    [SerializeField] private float _distanceToCam = 5.0f;
    [SerializeField] private GameObject _objtToSpawn;
    [SerializeField] private Vector3 _spawnPosition;

    void Start()
    {
        InvokeRepeating("InstantiateObjFrontOf", 3f, 3f);
    }
    // Update is called once per frame
    void Update()
    {
    }

    void InstantiateObjFrontOf()
    {
        _spawnPosition = new Vector3(Random.Range(0, Screen.width), Random.Range(0, Screen.height), _distanceToCam);
        Vector3 worldPosition = Camera.main.ScreenToWorldPoint(_spawnPosition);

        GameObject prefab = Instantiate(_objtToSpawn, worldPosition, Quaternion.identity);
    }
}
