using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//https://www.youtube.com/watch?v=qTbXxSns-zE

public class GameManager : MonoBehaviour
{
     void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            RaycastHit hit;
            //El rayo sale de la posicion de la cámara
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            //Si el rayo golpea con un objeto con fisicas, devuelveme el objeto en hit
            if(Physics.Raycast(ray, out hit))
            {
                //Debug.LogError(hit.transform.gameObject.name);
                hit.transform.gameObject.SetActive(false);
            }

        }
    }
}
