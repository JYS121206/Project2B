using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class SetRabbitMode : MonoBehaviour
{
    public ARRaycastManager arRaycaster;
    public GameObject[] characters;

    public GameObject go;

    GameObject spawnCharacter;

    Dictionary<int, GameObject> characters2 = new Dictionary<int, GameObject>();

    CharacterManager1 characterManager;

    public UISetModeMenu UISetModeMenu;
    public UICharacterList1 UICharacterList;

    Ray ray;
    RaycastHit rayHit;

    public LayerMask Rabbit;

    Camera cam;


    void Start()
    {
        characterManager = CharacterManager1.GetInstance();
    }

    void Update()
    {
        //PlaceObject();
        PlaceCharacter();
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

                if(Physics.Raycast(ray, out rayHit, Rabbit))
                {
                    spawnCharacter = rayHit.transform.gameObject;
                    spawnCharacter.transform.position = transform.position = hitPose.position;
                }
                
                //if (spawnCharacter == null)
                //    spawnCharacter = Instantiate(characters, hitPose.position, hitPose.rotation);
                //else
                //{
                //    spawnCharacter.transform.position = hitPose.position; 
                //    spawnCharacter.transform.rotation = hitPose.rotation;
                //}
                    
            }
        }
    }

    public void PlaceCharacter()
    {
        GameObject placeCharacter;

        ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Input.GetMouseButton(0))
        {
            if (Physics.Raycast(ray, out rayHit))
            {
                placeCharacter = rayHit.transform.gameObject;
                placeCharacter.transform.position = new Vector3(rayHit.point.x, rayHit.point.y, 5);
            }
        }
    }


    public void PickRabbit(int idx)
    {
        Debug.Log("aaaa");
        int placeCharacter = 0;

        if (spawnCharacter == null)
        {
            Debug.Log("bbb");
            spawnCharacter = (GameObject)Instantiate(characters[idx], go.transform);
            
            placeCharacter++;
        }
        if (placeCharacter >= 2)
            return;
        
        //Characters[idx]
    }

    public void OpenUICharacterList()
    {
        UICharacterList.gameObject.SetActive(true);

        UICharacterList.SetCharacterList();
        //UIPopGetRB.SetActive(false);
    }
}