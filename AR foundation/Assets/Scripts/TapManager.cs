using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

namespace KitsuneYuki{
    [RequireComponent(typeof(ARRaycastManager))]
    public class TapManager : MonoBehaviour
    {
        [SerializeField] GameObject spawn_object;
        ARRaycastManager raycast_manager;
        Vector2 touch_point;
        List<ARRaycastHit> raycast_hits = new List<ARRaycastHit>();
        private void Awake() {
            raycast_manager = GetComponent<ARRaycastManager>();
        }
        void TapAndSpawn(){
            if(Input.GetKeyDown(KeyCode.Mouse0)){
                touch_point = Input.mousePosition;
                if(raycast_manager.Raycast(touch_point , raycast_hits , TrackableType.PlaneWithinPolygon)){
                    Pose pose = raycast_hits[0].pose;
                    GameObject obj = Instantiate(spawn_object , pose.position , Quaternion.identity);
                    Vector3 cam_position = transform.position;
                    cam_position.y = obj.transform.position.y;
                    obj.transform.LookAt(cam_position);
                }
            }
        }
    }
}