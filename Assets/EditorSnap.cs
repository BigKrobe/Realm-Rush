using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class EditorSnap : MonoBehaviour
{
    [SerializeField] [Range(1f, 20f)] float _gridSize = 10f;
    // Update is called once per frame
    void Update()
    {
        Vector3 snapPos;
        snapPos.x = Mathf.RoundToInt(transform.position.x / 10f) * _gridSize;
        snapPos.z = Mathf.RoundToInt(transform.position.z / 10f) * _gridSize;
        transform.position = new Vector3(snapPos.x, 0f, snapPos.z);
    }
}
