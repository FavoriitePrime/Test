using System;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem.Layouts;


namespace UnityEngine.InputSystem.OnScreen
{
    [AddComponentMenu("Input/Trackpad")]
    public partial class Trackpad : OnScreenControl, IDragHandler, IPointerDownHandler
    {
        [InputControl(layout = "Vector2")]
        [SerializeField] private string _controlPath;
        private Vector2 _lastPos;

        protected override string controlPathInternal
        {
            get => _controlPath;
            set => _controlPath = value;
        }

        public void OnDrag(PointerEventData eventData)
        {
            if (eventData == null)
                throw new ArgumentNullException(nameof(eventData));

            UpdateDelta(eventData.position, eventData.pressEventCamera);
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            _lastPos = eventData.position;  
        }

        private void UpdateDelta(Vector2 pointerPosition, Camera uiCamera)
        {
            if (RectTransformUtility.ScreenPointToLocalPointInRectangle(GetCanvasRect(), pointerPosition, uiCamera, out var position))
            {
                var delta = position - _lastPos;
                SendValueToControl(delta.normalized);
                _lastPos = position;
            }
        }

        private RectTransform GetCanvasRect() 
        {
            var canvasRect = transform.parent?.GetComponentInParent<RectTransform>();
            if (canvasRect == null)
            {
                Debug.LogError("Trackpad needs to be attached as a child to a UI Canvas to function properly.");
                return null;
            }
            else
            {
                return canvasRect;
            }
        }


    }
}