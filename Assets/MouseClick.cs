using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace DefaultNamespace
{
    public class MouseClick : UnityEngine.MonoBehaviour
    {
        private ClickObject clobj;
        public GameObject obj;

        private void Start()
        {
            obj = transform.gameObject;
        }

        void OnMouseDown()
        {
            if (!EventSystem.current.IsPointerOverGameObject())
            {
                {
                    clobj = new ClickObject();
                    clobj.ReloadSceneOnClick(obj);
                }
            }
        }

    }
}
