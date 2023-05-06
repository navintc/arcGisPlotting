using UnityEngine;


    public class JSONReader : MonoBehaviour
    {
        [SerializeField]
        public TextAsset jsonFile;

        private static TextAsset _jsonFile;

        private void Start()
        {
            _jsonFile = jsonFile;
        }
        public static string getCity(string featureID)
        {
            Cities citiesInJson = JsonUtility.FromJson<Cities>(_jsonFile.text);

            foreach (City city in citiesInJson.cities)
            {
                if (featureID == city.featureID)
                {
                    return ("Number of Chairs: " + city.numberofchairs + " , Number of People: " + city.numberofpeople + " , Fire Exits: " + city.fireexits + " , Engineer: " + city.Engineer);
                }
            }
            return ("No metadata found");


        }
    }

