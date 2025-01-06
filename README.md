
# <img src="https://img.icons8.com/?size=100&id=66800&format=png&color=000000" alt="Star" width="50"> Santa's Magic Ball Hunt <img src="https://img.icons8.com/?size=100&id=80817&format=png&color=000000" alt="Star" width="50">
Welcome to Santa's Magic Ball Hunt, a console-based adventure game where you help Santa recover his stolen magic balls! Explore rooms, 
collect items, and avoid obstacles to save Christmas!


<img src="https://images.unsplash.com/photo-1733213567778-3eeba46f4642?w=800&auto=format&fit=crop&q=60&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxzZWFyY2h8N3x8Q3V0ZSUyMFNhbnRhfGVufDB8fDB8fHww" alt="Star" width="800">

## Game Overview
An evil character named Marcus has stolen Santa’s magic balls, which are crucial for Christmas! It’s up to you, the player, 
to help Santa find them before time runs out. Along the way, 
you’ll explore different rooms, and overcome challenges.


## Features

<img src="https://img.icons8.com/?size=100&id=q3dcjBmvz9SL&format=png&color=000000" alt="Star" width="30"> ** Player Customization**: 
- Start the game by entering your player name.

<img src="https://img.icons8.com/?size=100&id=EDZuk72S1FJ7&format=png&color=000000" alt="rooms" width="30"> ** Room Exploration ** : 
- Explore unique rooms like the Living Room, Toy Workshop, and Snowy Forest.

<img src="https://img.icons8.com/?size=100&id=Q5LIfHMi8J61&format=png&color=000000" alt="present" width="30"> ** Inventory Management **:
- Collect and manage items like magic balls, wooden toys, and other surprises.

 <img src="https://img.icons8.com/?size=100&id=80923&format=png&color=000000" alt="warning" width="30"> ** Obstacles **:
- Beware of Marcus, who may try to hinder your progress.

<img src="https://img.icons8.com/?size=100&id=80832&format=png&color=000000" alt="box" width="30"> ** Save and Load ** :
- Save your progress and continue later.

# How to Play
### 1. Start a New Game
Launch the game and enter your name.
Explore rooms to collect magic balls and other items.
### 2. Explore Rooms
Choose from available rooms to find hidden items.
Each room may contain magic balls or surprises.
### 3. View Inventory
Check what items you’ve collected so far.
Magic balls will help you win the game!
### 4. Win or Lose
Win: Collect all the magic balls to save Christmas!
Lose: If Marcus takes away all your lives, the game ends.

# <img src="https://img.icons8.com/?size=100&id=66168&format=png&color=000000" alt="Star" width="30"> Game Menu Options
### 1. Start New Game:

- Begin a fresh adventure with a new player name.
### 2. Load Game:
- Resume your progress from a previous session. 
### 3. Explore a Room:

- Visit rooms to find items and advance in the game.
### 4. View Inventory:

- Check all the items you’ve collected so far.
### 5. Exit Game:

- Exit the game when you're done playing.


# <img src="https://img.icons8.com/?size=100&id=66423&format=png&color=000000" alt="Star" width="30"> Technical Overview
## Key Components
### Player:
 - Tracks player-specific data like name, inventory, and progress.
### Rooms:
- Each room contains items the player can collect.
### Items:
- Represents items like magic balls and toys.
### GameState:
- Manages the player, rooms, and game progress.
### MainMenu:
- Handles navigation through the game's main menu options.

# File Structure
```
Models/
├── Items.cs           # Defines game items
├── Player.cs          # Tracks player data
├── Rooms.cs           # Handles room initialization
├── LivingRoom.cs      # Example room
├── SnowyForest.cs     # Example room
├── ToyWorkshop.cs     # Example room

Logic/
├── GameState.cs       # Manages game state
├── CommandHandler.cs  # Processes commands like exploring rooms
├── GameEngine.cs      # Runs the main game loop

UI/
├── MainMenu.cs        # Displays the main menu
├── GameDisplay.cs     # Handles game output
├── InputHandler.cs    # Handles user input

Program.cs             # Entry point for the game

```


# How to Run
1. Clone the repository or download the game files.
2. Open the project in Visual Studio or your preferred IDE.
3. Run the project:
    - Press F5 or use the command line to start the game.
4. Follow the on-screen instructions to play.

# <img src="https://img.icons8.com/?size=100&id=66418&format=png&color=000000" alt="Star" width="30"> Future Enhancements
- Add multiplayer mode.
- Use a database like  LiteDB for persistent save/load functionality.
- Introduce more characters with unique roles.
- Add more rooms and items for exploration.

# Contributing
Feel free to contribute to this project! If you have ideas for new features or improvements, 
open an issue or submit a pull request.

# License
This game is released under the MIT License.

## Background Music 🎵

<iframe style="border-radius:12px" src="https://open.spotify.com/embed/track/6DJ6Va1jpFcErKtQi7BAJv?utm_source=generator" width="100%" height="352" frameBorder="0" allowfullscreen="" allow="autoplay; clipboard-write; encrypted-media; fullscreen; picture-in-picture" loading="lazy"></iframe>