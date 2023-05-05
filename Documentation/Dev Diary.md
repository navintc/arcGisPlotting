# Dev Diary
-Navin Thamindu

In this project, I'm following a task where I have to generate 3D cities with arcGis.

## Day 1
- Installed unity 2021 fresh, added the prerequists. (HDRP, arcGIS plugins)
- Tried to build a script to auto generate the cities by
giving lats and longs, but it took so much time and it failed. Then I moved to making three different scenes to hold the maps.
- Sucecsfully added sanfrisco, montreal and New york by looking into this https://tiles.arcgis.com/tiles/z2tnIkrLQ2BRzr6P/arcgis/rest/services/
- Added the main menu

## Day 2
- Added Sun Controller to all scenes
- Fixed the issue of being not able to click on the UI components by updating arcGisCameraComponent.
- Ammended minor UI updates. 

## Day 3
- Reading documentation and researching on a way to recieve information about the buildings
- Failed all attempts to make such a system

# Day 4
- Making the python UDP streamer and the Unity UDP reciever. Initially it was created to sendout floats by packaging them in to a Python struct as a bytes-like data type. These data was unpackable from the unity's end. Therefore changed the python script again to send out the values as strings by pacakaging them in to a bytes-like type. Then these data was converted back to float from unity.
- Started experimenting with Beizier curves to implement a sine curve.