# GestureBasedURI

## Project requirements
Develop an application with a Natural User Interface. There are a number of options available to you and this is an opportunity to combine a lot of technology that you have worked with over the past four years. 

At the very least, this should be a local implementation of the application using gestures to interact with it. For example, a voice controlled application fits the parameters of gesture basedcontrol. You can expand out to include real-world hardware and use this as an opportunity to prove a concept. The Internet of Things is a common phrase, so you could implement a solution taking advantage of hardware like the Raspberry Pi, using the cloudfor data transfer and creating a real-world scenario through this medium.

You can reproducea classic game or system using a gesture-based interface. For example, a platformer game or a navigation application using Kinect or voice control. Maybe Tetris using the Myo armbands to control the blocks, or Flappy Bird using the Kinect as the controller. Applications with multiple users are also acceptable. 

Voice control applications need to be more complex and achieve something. Creating a skill in Alexa for the sake of creating a skill is not enough. You need to take the application further than this. You could, for example, implement a simple learning mechanism that will build a conversational skill as time progresses and demonstrate this. You could use the voice control to progress through a game or achieve a task. If you are doing this, then you need to distinguish the code you write from the samples available.

## Solution
We decided to make the classic arcade game Pacman in unity controlled using the MYO armband. The user would control the menu navigation and player through predefined default gestures. 

## Installation
To clone this repository to your machine navigate to where you want it cloned to in you directory, open a command prompt and run the following command:
```
git clone https://github.com/JKinsella1991/GestureBasedURI.git
```
The Nuget package is needed in order to run this project more specifically the windows input simulator version 1.0.4.0. Nuget can be acquired through the unity asset store and the input simulator can be gotten through Nuget. A break down of the Nuget package can be found [here](https://assetstore.unity.com/packages/tools/utilities/nuget-for-unity-104640?fbclid=IwAR3McRhKURJPsJBCiFGsY5xkG2060H2IPHUfvyFwPV-JR3mL0y2Lj8y9uSc) and a break down of the input simulator can be found [here](https://www.nuget.org/packages/InputSimulator).

### MYO
The relevant imports for the MYO armband for unity can be found here
```
https://github.com/thalmiclabs/myo-unity.git
```
To install in unity open Assets go to import package select "custom package" and find where the package you downloaded is and import all
