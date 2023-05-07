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

## Day 4
- Making the python UDP streamer and the Unity UDP reciever. Initially it was created to sendout floats by packaging them in to a Python struct as a bytes-like data type. These data was unpackable from the unity's end. Therefore changed the python script again to send out the values as strings by pacakaging them in to a bytes-like type. Then these data was converted back to float from unity.
- Started experimenting with Beizier curves to implement a sine curve.

## Day 5
- Initially tried to make an array which moves the incomming data starting from the last element to the first. So it could be used to make a functional graph. While building it, I got an idea to build a plotter using a custom trail with unity particle systems. It is successfully implemented in the scene view, but it's not visible in the game view due to camera complications of HDRP. Then I implemented a sprite generator to simulate the effect of a plotter.
- Dockerizing the python app
- Figma designing

## Day 6
- Scraping Camera Altitude from arcGIS scripts was not so easy as I expected it to be. Serialization did not work on those scripts for some reasons, thus I looked in to an automated solution to do it. Using tags to locate an UI element and then updating it, was the best solution came into my mind.
- Adding the JsonParser
- Adding the new functionalities to San Fransisco and Montreal from the New York Scene.
- Updating the documentation
- Looking again for the way to implement OSM - Failed