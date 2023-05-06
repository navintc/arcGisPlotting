# ArcGis + Python UDP Experiment with Unity
### Technical Documentation


# Figma Sketch Mockup
This is the sketch mockup of the UI designs of the Unity scenes.
[https://www.figma.com/file/xtWqocti4BRFquL8IjfJfo/nexTwin-UI?type=design&node-id=3%3A96&t=FkZijA7V0wcvp0rK-1](https://www.figma.com/file/xtWqocti4BRFquL8IjfJfo/nexTwin-UI?type=design&node-id=3%3A96&t=FkZijA7V0wcvp0rK-1)

# ArcGIS usage
ArcGis SDK is imported into the project as is and then changed some of the sample scripts to make them work as intended for this project,

### CameraController Update
The camera will move When you click on UI elements as well. To stop this from hapenning a simple checker is added to the update() function of ArcGISCameraControllerComponent.cs. (line 190)

    if (EventSystem.current != null &&
    EventSystem.current.IsPointerOverGameObject())
    {
        return;
    }

To have this system working `EventSystem` object should be included into the hierachy.

# Unity Scripts

## SunController.cs
This script controls the behavior of a sun object in the scene. It includes a slider and a text element for displaying the city name. The sun's rotation is determined by the value of the slider, which can be adjusted by the user. The sun smoothly rotates based on the sun direction using Quaternion.Slerp. The city name is displayed in the UI text element.

## SceneManager.cs
This script is used to manage all the scene transition related activities and this script should be added into an empty game object. Then this object will remain as a "dontdestroyonload" object through out the scenes.

| Member         | Type              | Access  | Static | Description                                                                                                              |
| -------------- | ---------------- | ------- | ------ | ------------------------------------------------------------------------------------------------------------------------ |
| `selectedScene` | `string`         | `public`| `true` | Used to store the name of the next scene the user wishes to load. This value is updated by external scripts and will be actively used by the `loadButton()` function. |
| `loadButton()`  | `void` function  | `public` | `false` | Calls the `SceneLoader()` function by passing down the `selectedScene`. Used in buttons in the scenes.                     |
| `SceneLoader()` | `void` function  | `private`| `false` | Loads the scene with the name of the parameterized string.                                                               |

## UdpReciever.cs
This script will grab the data streamed in the port 5000. The recieved data will be parsed into to float and will be stored into a public static variable (UDPSineValue) so that it would be accessed to other scripts in the system.

## StartParticles.cs
This script is responsible for starting a particle system attached to the game object it is attached to. The script retrieves the Particle System component attached to the game object using GetComponent<ParticleSystem>(). It then calls the Play() function on the Particle System component to start the particle emission.

## PlotGenerator.cs
This instantiates small sprites from the update lifecycle which will simulate a custom plotter. The `parentObj` field should have the parent object of the sprite which moves according to the data. And the `plotNode` should the sprite prefab. I was intended to implement a line drawer which would connect these sprites, but the time constraint was not in the favorable state.

## PlotImg.cs
This script controls the movement of the plotNode objects in the scene, simulating a plotter effect.

Serializable Fields:

| Field   | Type  | Description                                                       |
|---------|-------|-------------------------------------------------------------------|
| speed   | float | Controls the horizontal movement speed of the node image.              |
| time    | float | Determines the duration for which the image will move before being destroyed. |
| closing | float | Accumulates the distance traveled by the image and determines when it should be destroyed. |

## BeizierDraw.cs
This script enables drawing a Bezier curve using a LineRenderer component in Unity. It requires the presence of a LineRenderer component on the same GameObject. The control points are specified as an array of Transforms. The curve is drawn by iterating through each segment of the curve and calculating the position using the cubic Bezier equation. The resulting points are then set as positions in the LineRenderer component to visualize the curve.

*This script is not currently used*


# Python Script
This script will create a UDP pipe at the loopback IP in the port 5005 and generate 10Hz sine curve values in an infinite loop.

First the sine value will be generated according to the time and the frequency. Then it will be mapped to a value between 1 and 100 so it would be easier to be handled at Unity's end. It is a bit hard to send these floats as is, therefore they are converted to utf-8 strings before packaging them as python structs. Utf-8 is used to reduce data usage and to improve compatibility. 

    sine = math.sin(2*math.pi*FREQUENCY*t)
    mapped_value = str(((sine + 1) / 2) * 99 + 1)
    data = bytes(mapped_value, 'utf-8')

A dockerfile also available in the project.