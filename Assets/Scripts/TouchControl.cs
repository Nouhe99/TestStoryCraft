using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TouchControl : MonoBehaviour
{
    public static TouchControl instance;

    public float rotateSpeed = 0.1f;

    Touch touch;
    Vector3 touchPos1;
    Vector3 touchPos2;

    [HideInInspector]
    public List<RectTransform> textList;
    [HideInInspector]
    public List<Text> textListHolder;

    public bool clicked = false;
   
    private void Start()
    {
        instance = this;
       
    }

    public void FindList()
    {
        GameObject[] go = GameObject.FindGameObjectsWithTag("word1");
        foreach (GameObject g in go)
        {
            textList.Add(g.GetComponent<RectTransform>());
            textListHolder.Add(g.GetComponent<Text>());

        }
    }

    void Update()
    {
        if (!clicked)
        {
            foreach (Text t in textListHolder)
            {

                Color textColor = t.color;

                if (t.rectTransform.position.z >= 0)
                {

                    textColor = t.color;
                    textColor.a = (t.rectTransform.position.z / 123.5459f) -0.5f;
                    t.color = textColor;
                }
                else
                {

                    textColor = t.color;
                    textColor.a = Mathf.Abs(t.rectTransform.position.z / 123.5459f) + 0.5f;
                    t.color = textColor;
                }
            }

        }

        if (Input.touchCount > 0)
        {
            touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                touchPos1 = touch.position;
            }
            if (touch.phase == TouchPhase.Moved)
            {
                touchPos2 = touch.position;
                Vector3 direction = touchPos1 - touchPos2;


                foreach (RectTransform g in textList)
                {
                    g.transform.RotateAround(transform.position, new Vector3(-direction.y, direction.x, 0), direction.magnitude * rotateSpeed);
                }

            }

        }
        else
        {
            clicked = false;
        }

    }

    public void settotrue() 
    { clicked = true; }

}

