using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SineNodeController : MonoBehaviour
{

    [SerializeField]
    private float Xnormalizer;
    [SerializeField]
    private float Ynormalizer;
    [SerializeField]
    private float Znormalizer;



    [SerializeField]
    private float midValue = 50;
    [SerializeField]
    private float normalizationValue = 50;

    [SerializeField]
    public float renderValue = 0; 

    private
    // Start is called before the first frame update
    void Start()
    {
       /* ParticleSystem par = GetComponent<ParticleSystem>();
        par.Play();*/
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("Received: " + UdpReciever.UDPSineValue);
        renderValue = UdpReciever.UDPSineValue - normalizationValue;
        midValue = renderValue / 2;
        renderValue = midValue - renderValue;
        transform.position = new Vector3(Xnormalizer, renderValue - Ynormalizer, Znormalizer);

    }
}
