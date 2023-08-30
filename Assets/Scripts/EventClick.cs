using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class EventClick : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IPointerClickHandler
{
    public Transform buttonTransform;

    private void Awake()
    {
        
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        print("LIGHT ON");
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        print("LIGHT OFF");
    }
    
    public void OnPointerClick(PointerEventData eventData)
    {
        print("CLICKED");
    }
}
