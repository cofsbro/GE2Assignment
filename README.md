# GE2Assignment
**GE-2 Assignment **

*My project:*

The aim of my project is to recreate/reimagine a space battle scene from Stargate and Stargate Atlantis. Originally was planing on using the battle over Antarctica, using swarm following and attacking other ships. Use free assets I could find and get working with unity, I plan on using various space battles as refrences to create a space battle.

My aim is to try and make a space battle having a space ship travel from a space stargate to another part of the galaxy to engage the enemy.

*Storyboard Idea*
Still with what assests can work for me my plan is to have a space ship move from one stargate to another, to another region of space avoiding enemies and asteroids. With the possibility shooting enemy ships. And as said previously maybe have a swarm attack go through the stargate to destroy the enemy ships.
 
 
 ![20200228_123223](https://user-images.githubusercontent.com/10131994/75550153-2d656480-5a29-11ea-92ff-3d715645a661.jpg)
 
 ![20200228_123237](https://user-images.githubusercontent.com/10131994/75549707-33a71100-5a28-11ea-8f57-45f3e4818151.jpg)


*Resources:*

- SG-1 Battle over Antarctica (https://www.youtube.com/watch?v=3UZlgjuqnHY)

- SG-Atlantis wraith battle (https://www.youtube.com/watch?v=mHt45Q77ftA)

- Atlantis battles 
  - (https://www.youtube.com/watch?v=J3BvHp8ukF40)
  - (https://www.youtube.com/watch?v=8Y_roXrOP1I)
  
- SG1 Supergate battle 
  - (https://www.youtube.com/watch?v=xLSDFoa8zJc)
  - (https://www.youtube.com/watch?v=tFiOkijgBkc)
  
- SG Midway space station (https://www.youtube.com/watch?v=solkV-DbgGo)

- SG-Universe battles (https://www.youtube.com/watch?v=ClE9S6OdL9Y)

- SG-Universe star scenes 
  - (https://www.youtube.com/watch?v=vhAYMnLso2k)
  - (https://www.youtube.com/watch?v=M7o4br2EOAw)
  - (https://www.youtube.com/watch?v=1nHqfMNETyM)
  
  

**Changes from Original Design **

The original Design was changed was more so have a ship launching and then travel to a new galaxy to face a ship.

*Coding Resources:*

Used various Youtube tutorials mixing with code from the lecturer's git hub and mixing aspects learned previously.

First was the Bezier curve. Was looking up ways to see how could make the ship emulate pathfinding alot more fluidly. 
With that found out about the Bezier formula and the various aspects in how it creates a curve between points of an angle. 
Tried vaious turtorials on youtube all were in designed with 2D in mind so tried to see if could change it into 3D, one person did have a free asset tool avilable (By Sebastian Lague who did one of the 2D samples) that did give a 3D option but did not use or look at it as tried figuring out how they done it myself first.
Bezier was the first code when learnt about implementing the curve.
While the TestPath, TestPathCreator, Pathway, follower code code used within these videos, yet trying to manipulate the 2D aspects into a 3D envioment with variating results.

Learning about the curve
- (https://www.youtube.com/watch?v=AxhCKFbIkmM)
- (https://www.youtube.com/watch?v=RF04Fi9OCPc)
- (https://www.youtube.com/watch?v=11ofnLOE8pw)


When implementing and trying to make game look more space like was going to add random space assets from the store to add asteroids, nebulas stars etc..
(https://assetstore.unity.com/packages/3d/environments/sci-fi/vast-outer-space-38913)

This unity asset also had a smaple scene inbeded into it where it had a sphereical skybox instead of using the built in square skybox.
So that gave the idea of how to have the marterial on the inside of a sphere to emulate a better skybox. 
Finding and using another turtorial do the inverse. Finding out how the triangles that make up the sphere needs to be roateded and material mirrored so it does the correct pattered like your turning it inside out.
Though noticed inside needed to fix lighting, and add more light sources within the darkness of inside something. Within the ReverseShpere code:
- (https://www.youtube.com/watch?v=HEHn4EUUyBk&t=342s)


Other Samples used all mostly Youtube to see the various ways how AI movement from traveling to random points, following/chasing an object, and AI operate and tweaking, Sound effects etc.. into the code:

- (https://www.youtube.com/watch?v=aEPSuGlcTUQ&t=11s)
- (https://www.youtube.com/watch?v=8eWbSN2T8TE)
- (https://www.youtube.com/watch?v=pRyI_1QlEak)
- (https://www.youtube.com/watch?v=T1hqJcHTVJI)
- (https://www.youtube.com/watch?v=6OT43pvUyfY&t=524s)
- (https://www.youtube.com/watch?v=QL29aTa7J5Q&t=495s)
- (https://www.youtube.com/watch?v=sOLfxVbUrAc)

