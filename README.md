# Project 1 - Robo_Puncher

## 1. GitHub Repository Link:
https://github.com/TKOWF/Project-1.git

## 2. Scripts & What They Do:
- PlayerMovement.cs: Handles overall player movement, such as left and right movements, their corresponding facing directions, jumping, and movement animations, through Unity's new Input System and Rigidbody2D
- PlayerHealth.cs: Manages player health, damage, healing from medkits, death, level restart from death, and saving the death count value using PlayerPrefs.
- PlayerCombat.cs: Handles the players attack animations, melee attack, detecting enemies within melee range and applying damage to them.
- EnemyPool.cs: Creates and manages reusable enemy instances through object pooling.
- EnemySpawner.cs: Places pooled enemies at designated spawn points that I've chosen throughout the level.
- EnemyAI.cs: Controls enemy detection, chasing behavior, movement, facing direction, and animations.
- EnemyHealth.cs: Tracks enemy health, processes damage, deactivates fallen enemies, and handles level completion since the level only ends when the final enemy is slain.
- MedKit.cs: Detects when the player enters its trigger and restores health.
- GameplayMenu.cs: Controls the pause menu, allowing the functions to pause and resume gameplay, and return to the main menu.
- MainMenuManager.cs: Handles the start button and displays the saved total death count value.

## 3. Scene Descriptions:
### MainMenu Scene is simply the start of the game.
- Main Camera: Displays the Main Menu
- Canvas: Contains the game's title, start button, and total death counter value.
- MainMenuManager: Handles the start button, loads the Gameplay scene, and displays the total deaths saved through PlayerPrefs.
Background: Displays the background art.
Global Light 2D: Provides general lighting for sprites using compatible lit materials in the MainMenu scene.
    How to Interact: The user can start up the game by pressing the start button. The user can also return to this menu, through the Gameplay pause menu, or defeating the final enemy.

### Gameplay Scene is the pixelated side scrolling game-level, where the player has to fight enemies and perform some minor platforming to progress through the level.
- Player: Uses Rigidbody2D and Capsule Collider 2D for movement and collision. Its scripts control movement, combat, and health.
- PlayerVisual: Displays the player's animations.
- Grid/Ground: Contains the custom ground Tilemap and Tilemap Collider 2D, allowing the player and enemies to interact with the environment.
- EnemyPool: Creates and manages reusable enemies.
- EnemySpawner: Uses designated spawn points to position enemies from the pool throughout the level.
- EnemyVisual: Displays the enemies' animations.
- MedKit: Restores player's health by two hitpoints (if health isn't already full) once player enters its trigger zone.
- CinemachineCamera: Follows the player throughout the level.
- GameplayCanvas/GameplayMenu: Provides the pause menu, resume button, and Quit-to-Menu button.
- Background: Displays the background art.
- Global Light 2D/ColorfulLight: Provides lighting effects within the level, specifically to light the medkits with a soft green aura behind it.
    How to Interact: Enemies will chase and damage the player through physical contact, while the player defeats them using melee attacks (space bar). Slain enemies are then deactivated for reuse through object pooling. If the player dies however, the level begins anew. Defeating the final enemy at the top of the highest platform in the final room returns the user to the Main Menu scene.

## 4. How the Game Satisfies the Eight Requirements
1. Scene Management: The game contains two scenes, MainMenu and Gameplay. The Start button loads Gameplay, while the pause menu's Quit option and defeating the final enemy return the player to MainMenu.
2. New Input System: The player uses Unity's new Input System with an Input Actions asset to move, jump, and attack. Rigidbody2D and Capsule Collider 2D handle movement and collisions.
3. Tilemap Level: The Gameplay scene uses a custom industrial Tilemap for its platforms and ground, with a Tilemap Collider 2D providing physical collision.
4. Object Pooling: The EnemyPool script creates reusable enemy prefab instances, while EnemySpawner positions them throughout the level. Defeated enemies are deactivated rather than destroyed.
5. Tags, Layers, and Triggers: MedKits use OnTriggerEnter2D and CompareTag("Player") to detect the player and restore health. The game also uses tags for identifying enemies and the ground.
6. Pause Menu: GameplayCanvas contains a pause menu that uses Time.timeScale to pause and resume gameplay. It also provides a Quit-to-Menu button.
7. PlayerPrefs Persistence: The game saves the player's total death count using PlayerPrefs. The saved value is displayed in MainMenu and persists after closing and reopening the standalone executable.
8. Lighting and Materials: The Gameplay scene uses Unity's 2D lighting system, including a Global Light 2D and a colored Spot Light 2D that creates a soft green glow behind MedKits.

## 5. Third-Party Assets:
### CRAFTPIX.NET - Artwork
- Free 3 Cyberpunk Sprites Pixel Art: Used Punk idle, attack_1, and run animations. Used Cyborg idle, and run animations.
    https://craftpix.net/freebies/free-3-cyberpunk-characters-pixel-art/?utm_campaign=Website&utm_source=itch.io&utm_medium=public
- Free Industrial Zone Tileset Pixel Art: Used 4 square tile assets, and a background asset.
    https://craftpix.net/freebies/free-industrial-zone-tileset-pixel-art/?utm_campaign=Website&utm_source=itch.io&utm_medium=public

### Unity Packages
- Unity Input System: Used for player movement, jumping, and attacking.
- Cinemachine: Used to make the camera follow the player.
- Universal Render Pipeline (URP): Used for 2D lighting and rendering.
- TextMeshPro: Used for user-interface text.

### AI Assistance
- ChatGPT (OpenAI): Was used for guidance on debugging and scripting, and explaining Unity systems for better understanding during development.