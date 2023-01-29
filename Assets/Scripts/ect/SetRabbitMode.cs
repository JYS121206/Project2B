using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class SetRabbitMode : MonoBehaviour
{
    public ARRaycastManager arRaycaster;
    public GameObject placeCharacter;

    GameObject spawnCharacter;

    Dictionary<int, GameObject> characters = new Dictionary<int, GameObject>();


    void Start()
    {

    }

    void Update()
    {

    }

    private void PlaceObject()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            List<ARRaycastHit> hits = new List<ARRaycastHit>();
            if(arRaycaster.Raycast(touch.position, hits, UnityEngine.XR.ARSubsystems.TrackableType.Planes))
            {
                Pose hitPose = hits[0].pose;

                if (spawnCharacter == null)
                    spawnCharacter = Instantiate(placeCharacter, hitPose.position, hitPose.rotation);
                else
                {
                    spawnCharacter.transform.position = hitPose.position; 
                    spawnCharacter.transform.rotation = hitPose.rotation;
                }
                    
            }
        }
    }
}