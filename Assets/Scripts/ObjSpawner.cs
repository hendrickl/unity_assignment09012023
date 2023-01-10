using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjSpawner : MonoBehaviour
{
    [SerializeField] private float _thrust;
    [SerializeField] private float _repeatRate = 3f;
    [SerializeField] private float _timeToInvoke = 3f;
    [SerializeField] private float _distanceToCam = 5.0f;
    [SerializeField] private GameObject _objtToSpawn;
    // [SerializeField] private Vector3 _spawnPosition;

    private List<GameObject> _poolObj = new List<GameObject>();

    void Start()
    {
        InvokeRepeating("InstantiateObjFrontOfCam", _timeToInvoke, _repeatRate);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            CancelInvoke();
        }
    }

    void InstantiateObjFrontOfCam()
    {
        Vector3 _spawnPosition = new Vector3(Random.Range(0, Screen.width), Random.Range(0, Screen.height), _distanceToCam);
        Vector3 worldPosition = Camera.main.ScreenToWorldPoint(_spawnPosition);

        GameObject prefab = Instantiate(_objtToSpawn, worldPosition, Quaternion.identity);
        prefab.GetComponent<Rigidbody>().AddForce(Camera.main.transform.forward * -_thrust, ForceMode.Impulse);
    }

    void InstantiateObjFromPool()
    {
        // Vector3 worldPosition = Camera.main.ScreenToWorldPoint(_spawnPosition);

        // GameObject prefab = Instantiate(_objtToSpawn, worldPosition, Quaternion.identity);
    }

    void ComputeWorldPosition(Vector3 _spawnPos)
    {
        Vector3 worldPosition = Camera.main.ScreenToWorldPoint(_spawnPos);
    }
}
