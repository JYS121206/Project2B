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

    private Transform selectedRabbit = null;
    private Vector3 selectedDistance;

    private bool isSpawning = false;

    void Start()
    {
        characterManager = CharacterManager1.GetInstance();
    }

    void Update()
    {
        PlaceObject();
    }

    private void PlaceObject()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            RaycastHit hit;
            ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);

            int rabbitLayer = 1 << LayerMask.NameToLayer("Rabbit");
            bool hitRabbit = Physics.Raycast(ray, out hit, Mathf.Infinity, rabbitLayer);

            switch (touch.phase)
            {
                case TouchPhase.Began:
                    if (hitRabbit)
                    {
                        selectedRabbit = hit.transform;
                        selectedDistance = selectedRabbit.position - Camera.main.transform.position;
                    }
                    break;

                case TouchPhase.Moved:
                case TouchPhase.Stationary:
                    if (selectedRabbit == null)
                        return;

                    Vector3 movePos = Vector3.zero;
                    Quaternion lookDir = Quaternion.LookRotation(selectedRabbit.transform.position, Camera.main.transform.position);

                    List<ARRaycastHit> hits = new List<ARRaycastHit>();
                    if (arRaycaster.Raycast(touch.position, hits, UnityEngine.XR.ARSubsystems.TrackableType.Planes))
                        movePos = hits[0].pose.position;
                    else
                        movePos = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position) + selectedDistance;

                    selectedRabbit.position = Vector3.Lerp(selectedRabbit.transform.position, movePos, Time.deltaTime * 5);
                    break;

                case TouchPhase.Ended:
                case TouchPhase.Canceled:
                    selectedRabbit = null;
                    break;
            }
        }
    }



    public void PickRabbit(int idx)
    {
        if (isSpawning)
            return;

        StartCoroutine(SpawnRabbit(characters[idx]));
    }

    IEnumerator SpawnRabbit(GameObject rabbit)
    {
        isSpawning = true;

        var originSize = rabbit.transform.localScale;
        var screenCenter = new Vector3(Camera.main.pixelWidth / 2, Camera.main.pixelHeight / 2);
        var centerPos = Camera.main.ScreenToWorldPoint(screenCenter);
        var spawnedRabbit = Instantiate(rabbit, centerPos + Camera.main.transform.forward, Quaternion.identity);
        spawnedRabbit.transform.localScale = Vector3.zero;
        spawnedRabbit.transform.LookAt(Camera.main.transform);

        while (true)
        {
            Vector3 scale = Vector3.Lerp(spawnedRabbit.transform.localScale, originSize, Time.deltaTime * 4);
            spawnedRabbit.transform.localScale = scale;

            if (scale.x > originSize.x - 0.005f)
            {
                spawnedRabbit.transform.localScale = originSize;
                break;
            }

            yield return null;
        }

        isSpawning = false;
    }

    public void BookmarkCharacter()
    {
        characters2.Add(1, spawnCharacter);

    }

    public void OpenUICharacterList()
    {
        UICharacterList.gameObject.SetActive(true);

        UICharacterList.SetCharacterList();
        //UIPopGetRB.SetActive(false);
    }
}