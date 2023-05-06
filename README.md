# ArcGis + Python UDP Experiment with Unity

## Figma Mockup:
[https://www.figma.com/file/xtWqocti4BRFquL8IjfJfo/nexTwin-UI?type=design&node-id=3%3A96&t=FkZijA7V0wcvp0rK-1](https://www.figma.com/file/xtWqocti4BRFquL8IjfJfo/nexTwin-UI?type=design&node-id=3%3A96&t=FkZijA7V0wcvp0rK-1)

## How to run

### Python UDP Server
1. Make sure you have Python installed on your system.
2. Open a terminal or command prompt and navigate to the directory where the code.py file is located.
3. Run the Python script by executing the following command:
    python code.py
4. The script will start running and continuously send UDP messages to the specified IP address and port.
Note: Make sure the IP address and port specified in the script (UDP_IP and UDP_PORT) are appropriate for your setup. You may need to modify them accordingly.
5. You will see the printed data in the terminal, indicating the values being sent as UDP messages.
6. To stop the script, you can press Ctrl+C in the terminal or command prompt.


*Running with Docker*
1. Make sure you have Docker installed on your system. You can download and install Docker from the official Docker website (https://www.docker.com/).
2. Open a terminal or command prompt and navigate to the directory where your Dockerfile and code.py files are located.
3. Build the Docker image by executing the following command: 
    docker build -t sinegenerator-img .
4. Once the Docker image is built successfully, you can run a Docker container based on that image using the following command:
    docker run --name sinegenerator-container sinegenerator-img
5. The script inside the Docker container will start running, and you should see the printed data in the terminal.

Note: The UDP messages will be sent from within the Docker container, so make sure the IP address and port specified in the script (UDP_IP and UDP_PORT) are appropriate for your setup.

6. To stop the Docker container, you can use the following command:
    docker stop sinegenerator-container

### Unity
1. Generate an API key from https://developers.arcgis.com/unity/
2. Open the project with Unity 2021 and install the ArcGis SDK using the Unity package manager. (https://developers.arcgis.com/unity/install-and-set-up/)
3. For the moment the API key is not centralized as a constant. So, paste the API key in to the serialized variable "API key" in "arcGis map" component in each "ArcGISMap" object in each map (New York, Montreal & San Fransisco)
4. Play the Unity scene, "Main Menu"