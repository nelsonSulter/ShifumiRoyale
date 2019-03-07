using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GUIController : MonoBehaviour
{
    Text statusText;
    
    // Start is called before the first frame update
    void Start()
    {
        statusText = GameObject.Find("StatusText").GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        statusText.text = "Status : " + PhotonNetwork.connectionStateDetailed.ToString();
    }
}
