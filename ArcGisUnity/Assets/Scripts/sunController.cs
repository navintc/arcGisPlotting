using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class sunController : MonoBehaviour
{
    [SerializeField]
    private Slider _slider;
    [SerializeField]
    private TMP_Text _cityName;
    float sunDirection = 90f;
    float smooth = 5.0f;
    // Start is called before the first frame update
    void Start()
    {
        _cityName.text = SceneManagerScript.selectedScene;
        _slider.onValueChanged.AddListener((v) =>
        {
            sunDirection = v;
        });
    }

    // Update is called once per frame
    void Update()
    {

        // Rotate the cube by converting the angles into a quaternion.
        Quaternion target = Quaternion.Euler(sunDirection, 0f, 0f);
        transform.rotation = Quaternion.Slerp(transform.rotation, target, Time.deltaTime * smooth);
    }
}
