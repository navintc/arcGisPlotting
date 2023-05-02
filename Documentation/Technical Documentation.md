# ArcGis + Python UDP Experiment with Unity
### Technical Documentation

# ArcGIS usage
ArcGis SDK is imported into the project as is and avoided changing the original SDK sources to reduce future confusions *except for the camera controller*.

### CameraController Update
The camera will interact When you click on UI elements as well. To stop this from hapenning a simple checker is added to the update() function of ArcGISCameraControllerComponent.cs. (line 190)

    if (EventSystem.current != null &&
    EventSystem.current.IsPointerOverGameObject())
    {
        return;
    }

To have this system working `EventSystem` object should be included into the hierachy.

# Scripts

## SceneManager.cs
This script is used to manage all the scene transition related activities and this script should be added into an empty game object. Then this object will remain as a "dontdestroyonload" object through out the scenes.

| Member         | Type              | Access  | Static | Description                                                                                                              |
| -------------- | ---------------- | ------- | ------ | ------------------------------------------------------------------------------------------------------------------------ |
| `selectedScene` | `string`         | `public`| `true` | Used to store the name of the next scene the user wishes to load. This value is updated by external scripts and will be actively used by the `loadButton()` function. |
| `loadButton()`  | `void` function  | `public` | `false` | Calls the `SceneLoader()` function by passing down the `selectedScene`. Used in buttons in the scenes.                     |
| `SceneLoader()` | `void` function  | `private`| `false` | Loads the scene with the name of the parameterized string.                                                               |
