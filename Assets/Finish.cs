using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Finish : MonoBehaviour
{
    private void Start()
    {
        GameObject canvas = GameObject.Find("Canvas");
        canvas.transform.Find("Panel").gameObject.SetActive(false);
    }
    private void OnTriggerEnter(Collider other)
    {
        GameObject canvas = GameObject.Find("Canvas");
        canvas.transform.Find("Panel").gameObject.SetActive(true);
    }

}
