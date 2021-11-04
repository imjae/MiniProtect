using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRotation : MonoBehaviour
{
    public void InputRotation()
    {
        Vector3 playerRotate = 
            Vector3.Scale(Camera.main.transform.forward, new Vector3(1, 0, 1));
            // Debug.Log($"{_camera.transform.forward} / {new Vector3(1, 0, 1)} / { Vector3.Scale(_camera.transform.forward, new Vector3(1, 0, 1))}");
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(playerRotate), Time.deltaTime * 100f);
    }
}
