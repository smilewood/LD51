using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class MessageInteraction : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
   private bool dragging;
   private Vector3 deltaMove;
   // Start is called before the first frame update
   void Start()
   {

   }

   // Update is called once per frame
   void Update()
   {
      if (dragging)
      {
         this.transform.position = this.transform.position + deltaMove;
      }
   }

   public void OnBeginDrag(PointerEventData eventData)
   {
      dragging = true;
   }
   public void OnDrag(PointerEventData eventData)
   {
      this.transform.position = this.transform.position + new Vector3(eventData.delta.x, eventData.delta.y, 0);
   }

   public void OnEndDrag(PointerEventData eventData)
   {
      dragging = false;
   }

}
