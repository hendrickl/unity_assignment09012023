using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastDetection : MonoBehaviour
{
    private void Update()
    {
        DestroyObj();
    }

    void DestroyObj()
    {
        Vector3 position = Input.mousePosition;
        Ray ray = Camera.main.ScreenPointToRay(position);
        RaycastHit hit;

        if (Input.GetMouseButtonDown(0) && Physics.Raycast(ray, out hit) && hit.transform.CompareTag("Spawned"))
        {
            Destroy(hit.transform.gameObject);
        }
    }
}
