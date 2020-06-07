using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using System.Collections.Generic;

[RequireComponent(typeof(ARRaycastManager))]
public class TapToPlaceObject : MonoBehaviour
{
    [Header("想放置的物件")]
    public GameObject tapObject;

    private ARRaycastManager arRaycast;

    private List<ARRaycastHit> hits = new List<ARRaycastHit>();

    private Vector2 mousePos;

    private void Start()
    {
        arRaycast = GetComponent<ARRaycastManager>();
    }

    private void Update()
    {
        TapObject();
    }
    private void TapObject()
    {
        if(Input.GetKeyDown(KeyCode.Mouse0))
        {
            mousePos = Input.mousePosition;
            if(arRaycast.Raycast(mousePos, hits, TrackableType.PlaneWithinPolygon))
            {
                Pose pose = hits[0].pose;

                GameObject temp = Instantiate(tapObject, pose.position, pose.rotation);
                Vector3 look = transform.position;
                look.y = temp.transform.position.y;
                temp.transform.LookAt(look);
            }
        }
    }
}
