using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetSize : MonoBehaviour
{
    float setSize;

    void Start()
    {
        float height = Camera.main.orthographicSize * 2;
        float width = height * Screen.width / Screen.height;

        Debug.Log($"height: {height} | width: {width}");

        setSize = (width / 4.5f) * 1;

        if (width == 4.5f)
            gameObject.transform.localScale = new Vector3(1, 1, 1);

        gameObject.transform.localScale = new Vector3(setSize, setSize, setSize);
        gameObject.transform.position = new Vector3(0, 0, 0);
    }
}
