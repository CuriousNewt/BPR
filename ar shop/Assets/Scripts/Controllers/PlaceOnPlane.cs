using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

/// <summary>
/// Listens for touch events and performs an AR raycast from the screen touch point.
/// AR raycasts will only hit detected trackables like feature points and planes.
///
/// If a raycast hits a trackable, the <see cref="placedPrefab"/> is instantiated
/// and moved to the hit position.
/// </summary>
[RequireComponent(typeof(ARRaycastManager))]
public class PlaceOnPlane : MonoBehaviour
{
    GameObject prefabToPlace;
    [SerializeField] GameObjectAction gameObjectAction;
    [SerializeField] UIAction UIAction;

    static List<ARRaycastHit> s_Hits = new List<ARRaycastHit>();
    ARRaycastManager m_RaycastManager;

    public GameObject spawnedObject { get; private set; }

    void Awake()
    {
        gameObjectAction.onSelectedChange += ChangePlacedPrefab;
        m_RaycastManager = GetComponent<ARRaycastManager>();
    }

    void ChangePlacedPrefab(GameObject go) {
        prefabToPlace = go;
        UIAction.MenuHide();
    }

    bool TryGetTouchPosition(out Vector2 touchPosition)
    {
#if UNITY_EDITOR
        if (Input.GetMouseButton(0))
        {
            var mousePosition = Input.mousePosition;
            touchPosition = new Vector2(mousePosition.x, mousePosition.y);
            return true;
        }
#else
        if (Input.touchCount > 0)
        {
            touchPosition = Input.GetTouch(0).position;
            return true;
        }
#endif

        touchPosition = default;
        return false;
    }

    void Update()
    {
        if (!TryGetTouchPosition(out Vector2 touchPosition))
            return;

        if (m_RaycastManager.Raycast(touchPosition, s_Hits, TrackableType.PlaneWithinPolygon))
        {
            // Raycast hits are sorted by distance, so the first one
            // will be the closest hit.
            var hitPose = s_Hits[0].pose;

            if (spawnedObject == null && spawnedObject != prefabToPlace)
            {
                Quaternion hitRot = hitPose.rotation;

                Quaternion rot = new Quaternion(hitRot.x, 0, hitRot.z, hitRot.w);
                spawnedObject = Instantiate(prefabToPlace, hitPose.position, hitPose.rotation);
                spawnedObject.transform.LookAt(transform.GetChild(0));
                spawnedObject.transform.rotation = new Quaternion(rot.x, spawnedObject.transform.rotation.y, rot.z, rot.w);
            }

            else
            {
                spawnedObject.transform.position = hitPose.position;
            }
        }
    }

    private void OnDestroy()
    {
        gameObjectAction.onSelectedChange -= ChangePlacedPrefab;
    }
}
