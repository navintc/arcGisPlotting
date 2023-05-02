using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class cityDropdown : MonoBehaviour
{
    [SerializeField]
    public TMPro.TMP_Dropdown m_Dropdown;
    string ddItem;
    int m_DropdownValue;

    void Start()
    {
        getCityDropdownValue();
    }

    public void getCityDropdownValue()
    {
        m_DropdownValue = m_Dropdown.value;
        Debug.Log("Starting Dropdown Value : " + m_Dropdown.value);
        ddItem = m_Dropdown.options[m_DropdownValue].text;
        SceneManagerScript.selectedScene = ddItem;
    }
}