using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollCanvasHover : MonoBehaviour
{
    [SerializeField]
    GameObject exclamationPoint;
    [SerializeField]
    GameObject scrollText;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ActivateText()
    {
        exclamationPoint.SetActive(false);
        scrollText.SetActive(true);
    }
}
