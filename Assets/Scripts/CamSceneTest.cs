using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.UI;

public class CamSceneTest : MonoBehaviour
{
    ARRaycastManager arRaycast;

    public List<GameObject> prfList = new List<GameObject>();
    public GameObject prf;

    GameObject curPrf;

    public Button[] UICamSceneBtns;

    private void Awake()
    {
        arRaycast = GetComponent<ARRaycastManager>();
    }

    void Update()
    {
        var screenPoint = Camera.current.ViewportToScreenPoint(new Vector2(0.5f, 0.5f));

        List<ARRaycastHit> hits = new List<ARRaycastHit>();
        
        if(arRaycast.Raycast(screenPoint, hits, UnityEngine.XR.ARSubsystems.TrackableType.Planes))
        {
            Pose planePos = hits[0].pose;
            prf.transform.position = planePos.position;
            prf.transform.LookAt(Camera.current.transform);
            prf.SetActive(true);
        }
        else
        {
            prf.SetActive(false);
        }
    }
}
