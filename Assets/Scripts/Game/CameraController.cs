using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] float smoothness = 0.1f;
    [SerializeField] Transform playerTransform;
   
    private void FixedUpdate()
    {
        if(playerTransform!= null)
        {
            Vector3 newCameraPosition = new Vector3(
            playerTransform.position.x,
            playerTransform.position.y,
            this.transform.position.z);

            this.transform.position = Vector3.Lerp(transform.position, newCameraPosition, smoothness);
        }
        
    }
}
