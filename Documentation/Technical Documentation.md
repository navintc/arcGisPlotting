# ArcGis + Python UDP Experiment with Unity
### Technical Documentation

# ArcGIS usage
ArcGis SDK is imported into the project as is and avoided changing the original SDK sources to reduce future confusions *except for the camera controller*.

### CameraController Update
The camera will move When you click on UI elements as well. To stop this from hapenning a simple checker is added to the update() function of ArcGISCameraControllerComponent.cs. (line 190)

    if (EventSystem.current != null &&
    EventSystem.current.IsPointerOverGameObject())
    {
        return;
    }

To have this system working `EventSystem` object should be included into the hierachy.

# Unity Scripts

## SceneManager.cs
This script is used to manage all the scene transition related activities and this script should be added into an empty game object. Then this object will remain as a "dontdestroyonload" object through out the scenes.

| Member         | Type              | Access  | Static | Description                                                                                                              |
| -------------- | ---------------- | ------- | ------ | ------------------------------------------------------------------------------------------------------------------------ |
| `selectedScene` | `string`         | `public`| `true` | Used to store the name of the next scene the user wishes to load. This value is updated by external scripts and will be actively used by the `loadButton()` function. |
| `loadButton()`  | `void` function  | `public` | `false` | Calls the `SceneLoader()` function by passing down the `selectedScene`. Used in buttons in the scenes.                     |
| `SceneLoader()` | `void` function  | `private`| `false` | Loads the scene with the name of the parameterized string.                                                               |

## UdpReciever.cs
This script will grab the data streamed in the port 5000. The recieved data will be parsed into to float and will be stored into a public static variable (UDPSineValue) so that it would be accessed to other scripts in the system.

# Python Script
This script will create a UDP pipe at the loopback IP in the port 5005 and generate 10Hz sine curve values in an infinite loop.

First the sine value will be generated according to the time and the frequency. Then it will be mapped to a value between 1 and 100 so it would be easier to be handled at Unity's end. It is a bit hard to send these floats as is, therefore they are converted to utf-8 strings before packaging them as python structs. Utf-8 is used to reduce data usage and to improve compatibility. 

    sine = math.sin(2*math.pi*FREQUENCY*t)
    mapped_value = str(((sine + 1) / 2) * 99 + 1)
    data = bytes(mapped_value, 'utf-8')