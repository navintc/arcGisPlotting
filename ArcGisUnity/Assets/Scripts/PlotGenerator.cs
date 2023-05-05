using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlotGenerator : MonoBehaviour
{
    [SerializeField]
    public GameObject plotNode;
    [SerializeField]
    public GameObject parentObj;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var newplotnode = Instantiate(plotNode, transform.position, transform.rotation);
        newplotnode.transform.parent = parentObj.transform;
    }
}
