using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunFollowMouse : MonoBehaviour
{
    private void Update() {
        Vector3 mouseScreenPosition = Input.mousePosition;
        Vector3 mouseWorldPosition = Camera.main.ScreenToWorldPoint(mouseScreenPosition);
        Vector3 direction = mouseWorldPosition - transform.position;
        direction.z = 0;

        transform.up = direction.normalized;
    }
}
