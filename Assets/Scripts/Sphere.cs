using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Sphere : MonoBehaviour
{
    public GameObject[] prefab;
    public GameObject canvas;
    public int radius=150;
    TouchControl touchControl;


    private void Awake()
    {
        touchControl = canvas.GetComponent<TouchControl>();
        this.SphereFormation(6, radius, 10);
    }

    public void Start()
    {

        touchControl.FindList();
    }


    private List<GameObject> HalfCircleFormation(int numberOfPoints, int radius)
    {
        int pieces = numberOfPoints-1 ;

        List<GameObject> spheres = new List<GameObject>();

        GameObject container = new GameObject("SphereContainer");
  
        container.transform.SetParent(canvas.transform);


        // Loop through the numberOfPoints that are in the half circle.
        for (int i = 0; i < numberOfPoints; i++)
        {
            GameObject instance = Instantiate(prefab[Random.Range(0, prefab.Length)]);

            float theta = Mathf.PI * i / pieces;
            float X = Mathf.Cos(theta) * radius;
            float Y = Mathf.Sin(theta) * radius;

            instance.transform.position = new Vector3(X, Y, 0);
            instance.transform.SetParent(container.transform);
            spheres.Add(instance);
        }
        return spheres;
    }
    private void SphereFormation(int numberOfPoints, int radius, int numberOfMeridians)
    {
        List<GameObject> spheres = HalfCircleFormation(numberOfPoints, radius);
        GameObject sphereContainer = GameObject.Find("SphereContainer");

        for (int i = 1; i < numberOfMeridians; i++)
        {
            float phi = 2 * Mathf.PI * ((float)i / (float)numberOfMeridians);

            for (int j =1; j < numberOfPoints-1; j++)
            {
                GameObject instance = Instantiate(prefab[Random.Range(0, prefab.Length)]);

                float X = spheres[j].transform.position.x ;
                float Y = spheres[j].transform.position.y * Mathf.Cos(phi) - spheres[j].transform.position.z * Mathf.Sin(phi);
                float Z = spheres[j].transform.position.z * Mathf.Cos(phi) + spheres[j].transform.position.y * Mathf.Sin(phi);

                instance.transform.position = new Vector3(X, Y, Z);
                instance.transform.SetParent(sphereContainer.transform);
            }
           
        }
    }
}
