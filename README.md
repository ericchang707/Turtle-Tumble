Team: Turtle Shell Studios
Game: Turtle Tumble
Members (name, email, canvas name): 
-Injae Cho, icho40@gatech.edu, Alexander Injae Cho
-Ashley Cain, acain36@gatech.edu, Ashley Leora Cain
-Adib Hasan, ahasan47@gatech.edu, Adib Belhaj Hasan
-Colby Heist, cheist6@gatech.edu, Colby Ivan Heist
-Eric Chang, echang89@gatech.edu, Eric Luntian Chang
-Omotomilola Adefila, oadefila@gatech.edu, Omotomilola Oyindamola Adefila

Start Scene: Main Menu

How to play:
-WASD or arrow keys to move
-Q to Roll Attack, stunning enemies.
-Spacebar to Jump
-Press G to open the Shop
-Press I to open the Inventory
-Select the desired power up in the Inventory menu, and activate the power up with E (extra lives are used automatically upon death).
-The attack power up boosts the Roll Attack, allowing the stun functionaity to become a kill functionality to permanently disable ghost enemies.
-Key for first level is in the top left portion of the map, key for the second level is in the top left portion of the map, key for the third level is upon one of the arches, key for the fourth level is at the end of the basement in the pirate shaft.
--For level 1 eneter the mineshaft that the rails lead to after collecting the key to progress to level 2
--For level 2 reach the beginning of the docks after collecting the key to progress to level 3
--For level 3 enter to gate of the city after collecting the key to progress to level 4
--For level four jump off the right side of the ship to a nearby dinghy to complete the game.

Assignment Requirements:

3D Game Feel: 
-Found in: main character movement

Precursors to Fun Gameplay: 
-Found in: Collect coins to buy powerups and collect keys to progress while avoiding/defeating enemies.

3D Character: 
-Found in: main character

3D World with Physics: 
-Found in: main character (gravity)

Real-time NPC:
-Found in: Video

-Known problem areas: 
-Coins are not persistent throughout the levels, reseting at the beginning of each level.

Manifest:
Injae Cho:
-Scripts:
--PlayerController.cs
--CameraControllerTopDown.cs
--AudioManager.cs
--Sound.cs
--Bug fixes and polish for most scripts
-Assets:
--Music
--SFX
--Fonts

Ashley Cain:
-Scripts:
----Note: I don't recall if she worked on anything other than models/assets
-Assets:
--All stage/level-related assets
--Level design and modeling for all scenes, rigging and animation of the player, modeling of characters in Blender, creation of collectable coins and animation of objects

Adib Hasan:
-Scripts:
--Movement.cs
--Body.cs
--IdleState.cs
--WalkState.cs
--WalkState1.cs
--DetectPlayer.cs
--Bullet.cs
-Assets:
--Enemy.prefab
--Shooting_Enemy.prefab
--Worked on Animation Controller for the main character and Enemy

Colby Heist:
-Scripts:
--ButtonInfo.cs
--InventoryInfo.cs
--InventoryManager.cs
--PowerUpController.cs
--ShopManager.cs
--CoinRotator.cs
--KeyRotator.cs
--Movement.cs (worked on)
--PlayerController.cs (worked on)
--DetectPlayer.cs (worked on)
-Assets:
--Design of collectables on levels
--Shop assets (Inventory, Shop, PowerUp and Revive UI screens)
--Title graphic
--Reworked 3D camera and player controls to have a better third person game feel
--Power up implementation

Eric Chang:
-Scripts:
--TimeBasedBonus
--Collector.cs
--SceneTransition.cs
--WinLoseManager.cs
--SpinAttack.cs
-Assets:
--Helped with collectables
--Score and text UI
--Helped with turtle mixamo animations

Omotomilola Adefila:
-Scripts:
--ScoreTracker.cs
--PlayerController.cs
----Note: Tomi's changes for these were unable to be merged with main. They had to do with the special ability bar asset "MoneyBar." They had problems finding the repository and as a result was working on a very outdated version of the project.
-Assets:
--Bar.png
--Heart.png
--newcoin.png
--MoneyBar.prefab
