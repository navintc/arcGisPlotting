using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlotImg : MonoBehaviour
{
    [SerializeField]
    public float speed;
    [SerializeField]
    public float time;
    [SerializeField]
    private float closing;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = transform.position - new Vector3(speed, 0, 0);
        closing += speed;
        if (closing > time)
        {
            Destroy(gameObject);
        }

    }
}
