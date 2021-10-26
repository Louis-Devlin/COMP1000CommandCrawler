# Crawler

## How To Open Crawler

I have compiled the project so that it can be executed on both Mac and Windows below are the instructions on how to execute it

### On Windows

Navigate to the Windows folder in Coursework submit and in a PowerShell window and enter the following command `.\Crawler.exe`

### On Mac ( you will need [mono](https://www.mono-project.com/download/stable/) for this)

Navigate to the Mac folder in Coursework submit in a terminal window and enter the following command
`mono Crawler.exe`

Video Submission - https://youtu.be/ICXL2tfMdxk

## Description of Project

Crawler is a command-line based dungeon crawler made as part of my COMP1000 assignment. We were given a starting code base with all the functions that we needed to be able to complete the game. This gave us a structure to work on the project along with tests that needed to pass to confirm that the program met the requirements set. <br></br>
Set structures included :

- Using a jagged array to store the map - this brought complexity to the project as figuring out how to iterate through an array where the size of each row varied was confusing to start with

- storing the current player action using an enum

## Controls

- W - Move up
- A - Move left
- S - Move down
- D - Move right
- E - Pickup gold
- Spacebar - Attack monster

## Advanced Features

- Added collectable gold <br></br>
  ![Added collectable gold ](https://i.gyazo.com/3bcc6f28ee72581ae5a0e96a41e94215.gif)
- Move the player without enter needing to be pressed <br></br>
- Added being able to attack Monsters <br></br>
  ![Attack Monsters](https://i.gyazo.com/d85db2d56ce2b323ba2efcffe0d2b802.gif)
- Allow the player to be able to replay the game (This feature is not implemented currently as it causes a hang at the tests, it has been commented out but can work as shown below) <br></br>
  [![Image from Gyazo](https://i.gyazo.com/428be7c705c7cf4aa0758b9dafdc5e38.gif)](https://gyazo.com/428be7c705c7cf4aa0758b9dafdc5e38)
- Advanced map can be loaded and played <br></br>
  [![Image from Gyazo](https://i.gyazo.com/b31b95ca8d3835f60d2cebd7e427c2e4.gif)](https://gyazo.com/b31b95ca8d3835f60d2cebd7e427c2e4)
  
## Updates to code (11/01/21)
I have wrapped the Console.Clear() in the start of my game loop in a try/catch to not cause it to fail the automarker

## Resources used

https://guides.github.com/features/mastering-markdown/ - Gyazo for GIFs showing advanced features
https://stackoverflow.com/questions/36583502/how-to-force-a-linebreak - Forcing linebreak in markdown
https://www.geeksforgeeks.org/c-sharp-jagged-arrays/ - Looping through a jagged array
