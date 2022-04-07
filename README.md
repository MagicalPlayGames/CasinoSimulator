Casino-Simulator
This project is meant to showcase functionality of a slot machine

Introduction
In 2 days, I created this simulation to showcase examples of my code with comments. There are 4 algorithms, and if I improve this project, Algorithm 5 will incoporate a convulsive neural network that keeps high interest of the player, while keeping a low payout rate.

User Manuel
Each runnable application is stored under Executable The UI overlay is not perfect, but it is natural at most application window aspect ratios.

UI The menu is on the left, and when a button is hovered over, a description pops up to follow the mouse Each button on this first level, expands the menu by the appropriate settings menu

Algorithm Button: Expands the menu to select the win algorithm used Card Settings: Expands the menu to edit the probablitiy and score value of each card color Win Settings: Expands the menu to edit the probablitiy and score value of each win pattern Algorithm 4 Settings: Specific settings for Algorithm 4, where there is a lose, winning streak, and losing streak probablities Sping Settings: Expands the menu to edit the speed and number of turns for the card wheels

X: Quit button Press To Spin (Mobile only): spins the machine

Spin to win Spin the wheel by pressing the big red button, or the Press To Spin button. The machine will determine the card colors by the selected algorithm. The machine will compare the win patterns to the current card matrix to find a win

Algorithm 1
Cards are picked at complete random

Algorithm 2
Cards are picked radomly with weighted probabilities

Algorithm 3
Cards are picked to match a single win statement, multiple wins are possible because all the other cards not pertaining to the pattern are chosen by Algorithm 2

Algorithm 4
If the player is on a hotstreak they automatically win
If the player is on a coldstreak they automatically lose
If the player just won,
  The algorithm decides between 
    a hotStreak, 
    a coldStreak,
    or a general win lose rate
If the player did not just win, the player loses
based off their current win ratio.
Hot streaks and cold streak length are determined randomly