# SokobanMVCGame
# Philippa Crawshaw, July 2017

This repository is for the game of Sokoban. The purpose of the game is for the player to push the blocks onto the goals. 

It has been designed as an exercise to test the ability to use the MVC model on a game. 
In actual fact it is more a MVP model however for the purposes of this exercise the connection between the model and the view is called Controller.

There is basic error handling however this would need to be expanded if the game was to be made available for public use.

This is the fourth iteration. 
  * The first iteration was the creation of the models for the game and filer with unit tests to test their functionality. There are a large number of unit tests that should be run regularly to ensure no errors have crept in.
  * The second iteration had the ability to play the game but no ability to design or save levels.

  * The third iteration (Using Forms branch) which has some basic functionality such as:
    * Move the player around using the arrow keys 
      (note. only basic error checking of cmd key presses is implemented)
    * Checking to ensure the player and/or blocks are unable to move onto walls
    * Sequentially undo moves
    * Choose the game board from a list of levels 
      (note. at this point invalid game formats will create an error message but the file will not be deleted and the default game will be loaded. Removing of invalid games will need to be done outside of the program) 
    * Design a game
    * Basic checking of the designed game to ensure there are an equal number of Goals and Boxes and only a single player 
    (note. There is also checking to ensure there are blocks on all the outside walls however this can be overridden should a more complicated pattern with indented outside walls be desired)
    * Saving a designed game to the levels directory
 
 This is the fourth iteration (Using Multiple Forms branch).
   * It builds upon the third iteration but seperates out the Game Play, Level Design, and Level Selection into three different views/forms
  
The game is 'as is where is'. Feel free to use it but be aware there are and will be bugs it is after all just an exercise not a fully functioning program.
