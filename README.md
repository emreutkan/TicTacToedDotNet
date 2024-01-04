# Tic Tac Toe 

  - Programming language   : `C#` 
  - Framework              : `.NET 8` 
  - IDE                    : `Visual Studio 2022`
  - Developer Platform     : `Windows 11`
  - Supported Platform(s)  : `Windows`

## Functions
  - All fields generated at runtime, allowing future upgrade to size changes
    - This means. The size of the gui can be changed by altering  `int boxSizeWidth = 120;` for width, `int boxSizeHeight = 120;` for height. These variables are in the `initializeMultiplayer()` method of `Form1`
  - Checks for winners only if the `placedCounter >= 5 ` which is the minimum moves it takes for a win
  - automatically resets the fields when a player wins or all the fields are filled without a winner. (no reset button) 
  
