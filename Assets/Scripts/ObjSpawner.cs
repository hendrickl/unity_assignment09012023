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

    private List<GameObject> _poolObj = new List<GameObject>();

    void Start()
    {
        InvokeRepeating("InstantiateObjFrontOfCam", _timeToInvoke, _repeatRate);
    }

    private void Update()
    {
        StopInvokeRepeating();
    }

    void InstantiateObjFrontOfCam()
    {
        Vector3 _spawnPosition = ComputeSpawnPosition();
        Vector3 worldPosition = ComputeWorldPosition(_spawnPosition);

        GameObject prefab = Instantiate(_objtToSpawn, worldPosition, Quaternion.identity);
        prefab.GetComponent<Rigidbody>().AddForce(Camera.main.transform.forward * -_thrust, ForceMode.Impulse);
    }

    Vector3 ComputeWorldPosition(Vector3 _spawnPos)
    {
        return Camera.main.ScreenToWorldPoint(_spawnPos);
    }

    Vector3 ComputeSpawnPosition()
    {
        return new Vector3(Random.Range(0, Screen.width), Random.Range(0, Screen.height), _distanceToCam);
    }

    void StopInvokeRepeating()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            CancelInvoke();
        }
    }
}
