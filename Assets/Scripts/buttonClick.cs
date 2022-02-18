using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class buttonClick : MonoBehaviour , IPointerDownHandler
{

    Camera _camera;

    private void Start()
    {
        _camera = Camera.main;
    }

    void Update()
    {
        transform.LookAt(new Vector3(0, 0, -_camera.transform.position.z));
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        TouchControl.instance.settotrue();
        GameObject go = EventSystem.current.currentSelectedGameObject;
        foreach (Text t in TouchControl.instance.textListHolder)
        {
            if (t.gameObject.transform != go)
            {
                Color textColor = t.color;
                textColor = t.color;
                textColor.a = 0.2f;
                Debug.Log(textColor.a);
                t.color = textColor;
            }
         
        }
        

        Color textColor1 = go.GetComponent<Text>().color;
        textColor1.a = 1;
        go.GetComponent<Text>().color = textColor1;
    }

}
