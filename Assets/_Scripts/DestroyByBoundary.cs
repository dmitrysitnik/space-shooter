using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByBoundary : MonoBehaviour {
    void OnTriggerExit(Collider any)
    {
        // Destroy everything that leaves the trigger
        Destroy(any.gameObject);
    }
}
