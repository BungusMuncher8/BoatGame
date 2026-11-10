using UnityEngine;

[RequireComponent(typeof(BackGroundScroller))]
public class BGCameraZoom : MonoBehaviour
{
   public Camera cam;

   [Header("Settings")]
    public float distance;
    public float zoomTargetSize;
    public float zoomSpeed;
    public float moveAmount;


   private void Update() 
   {
        if(CheckDistance())
        {
            Zoom();
        }
   }
   private bool CheckDistance()
   {
        if(Vector2.Distance(cam.transform.position,this.transform.position) < distance)
        {
            return true;
        }
        return false;
   }
   private void Zoom()
   {

   }
}
