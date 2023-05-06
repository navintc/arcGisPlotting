using UnityEngine;

    public class JSONReader : MonoBehaviour
    {
        public static TextAsset jsonFile;
        private void Start()
        {

        }
        public static string getCity(string featureID)
        {
            Cities citiesInJson = JsonUtility.FromJson<Cities>(jsonFile.text);

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
