using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjSpawner : MonoBehaviour
{
    [SerializeField] private float _thrust;
    [SerializeField] private float _repeatRate;
    [SerializeField] private float _timeToInvoke;
    [SerializeField] private float _distanceToCam;
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

    // Method that instantiates a new object in front of the camera
    void InstantiateObjFrontOfCam()
    {
        Vector3 _spawnPosition = ComputeSpawnPosition();
        Vector3 worldPosition = ComputeWorldPosition(_spawnPosition);

        GameObject prefab = Instantiate(_objtToSpawn, worldPosition, Quaternion.identity);
        prefab.GetComponent<Rigidbody>().AddForce(Camera.main.transform.forward * -_thrust, ForceMode.Impulse);
    }

    // Method that returns the world position of the spawn position
    Vector3 ComputeWorldPosition(Vector3 _spawnPos)
    {
        return Camera.main.ScreenToWorldPoint(_spawnPos);
    }

    // Method that computes the spawn position
    Vector3 ComputeSpawnPosition()
    {
        return new Vector3(Random.Range(0, Screen.width), Random.Range(0, Screen.height), _distanceToCam);
    }

    // Method that stops spawning when the space key is pressed
    void StopInvokeRepeating()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            CancelInvoke();
        }
    }
}
