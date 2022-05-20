
# **Completion Graph**
![Completion Graph](https://user-images.githubusercontent.com/45337205/169548123-0855803c-e46e-4161-915d-c07c593c13f3.png)
# **Game Design (Completion: %100)**

We jumped from idea to idea a lot during the development process but, in the end, we finally managed to maintain our focus on something. Basically, what you do is enter a level, avoid robots, get the objective and get out.

## **Completed**

-Determining the core loop of the game

-Determining the goal of the player

-Determining the challenge

-Determining the reward

-Determining the abilities of enemies

-Determining the abilities of the player

-Determining the throwable items

-Determining the interactable items

## Challenges

-The biggest challenge here is to not bite more than you can chew. You should be realistic about what can you do in a limited time.

-It is easy to get lost in details. Keep your focus on the main goal and note down the details. After the main goal is complete you can look at the details.

-There will be a lot of trial and error. You may have to give up many of your ideas. Because an idea may sound nice in mind or on paper but that does not mean it will be fun to play.

# **Gameplay Mechanics (Completion: %90)**

## Work In Progress

-Endgame door (Completion: %10)

## Completed

-Player movement controller

-Player eyesight controller

-Player inventory controller

-Enemy animation controller

-Enemy chase mechanic

-Enemy detection mechanic

-Throwable mechanics

-Interactable object mechanics

-Main menu controller

-Game over controller

-Level complete controller

-Level controller

## Challenges

-We developed many things from scratch. Character movement controller, animation controller, inventory controller,...

-Enemy AI mechanics are also developed from scratch. We used NavMesh for enemy AI and it is the only support we used. But we had to spend a very long time learning and using NavMesh properly.

-Unity's new input system is published recently. It makes inputs easy to control. However, it is hard to learn and use inside a new project. The setup is harder and more time-consuming compared to the old one.

-We have used URP (Universal Render Pipeline) which is a prebuilt Scriptable Render Pipeline, made by Unity. URP provides artist-friendly workflows that let you quickly and easily create optimized graphics across a range of platforms, from mobile to high-end consoles and PCs. But if you don't use it from the beginning of your project it may need some time to resolve errors and conflicts. Also, built-in shaders are not supported with URP. Therefore you have to readjust all of your materials and textures.

# **Level Design (Completion: %80)**

There are currently five levels in the game. Each of them can be considered a small puzzle.

## Work In Progress

-Polishing state (Completion: %20)

-Endgame door (Completion: %10)

## **Completed**

-Research on other games

-Creating levels on paper

-Creating levels in Unity

-Decorating levels with assets

## Challenges

-The hard part is to think of a level in the first place. It is hard to come up with something both clever and fun at the same time. Research on similar games is a must.

-There will be a lot of trial and error here as well. You will have to give up many of your ideas. Because an idea may sound nice in mind or on paper but that does not mean it will be fun to play.

# **3D Art (Completion: %100)**

## **Completed**

-3D model of Watcher

-3D model of Listener

-3D model of Light Bomb

-3D model of Sound Bomb

-3D model of Objective

-Adjusting the assets made by others according to our needs

-Adjusting the materials

## Challenges

-Unity is unable to understand some material adjustments made in Blender. To solve this, you need to bake a new texture in Blender with the adjustments you made and then import this texture to Unity. After that, you should assign this baked texture to the 3D model.

-Optimization is always a challenge. It prevents 3D artists from creating whatever they want. They have to keep the number of triangles of an object as low as possible.

# **Character Rigging and Animations (Completion: %100)**

## **Completed**

-Enemy "Watcher" animations

-Enemy "Listener" animations

## **Challenges**

-Mixamo speeds up this process quite a lot. However, it also limits us if we want to create custom animations. It is a challenge to add custom-made animations to a skeleton of Mixamo.

# **Lighting (Completion: %80)**

We completed the basic lighting. The rest is to polish it as we test the game.

## Work In Progress

-Polishing state (Completion: %10)

-World light adjustment (Completion: %0)

## **Completed**

-Light placement to the levels

## Challenges

-We want to create a tense environment for the player and lighting is an important factor in this. We need to pay attention to little details about lights.

# **Optimization (Completion: %80)**

## Work In Progress

-Light baking (Completion: %70)

## **Completed**

-Asset optimization

-Texture optimization

# **Story (Completion: %100)**

We have written a basic story and presented it as a sliding text at the start of the game.

## Challenges

-Our goal was never to write a perfect story that had not been seen before. However, we want it to be compatible with the game world. As a result, whenever we want to add something to the game, we ask ourselves "How can we explain this storywise?".

# **Sound Effects (Completion: %20)**

## Work In Progress

-Player walking sound (Completion: %0)

-Enemy walking sound (Completion: %0)

-Detected by the enemy sound (Completion: %0)

-Level win sound (Completion: %0)

-Game over sound (Completion: %0)

## **Completed**

-Determining the needed sound effects

-Alarm sound

## Challenges

-The challenge here is to find sound effects that can make the player nervous.

# **Music (Completion: %50)**

## Work In Progress

-Implementing the music to the Main Menu (Completion: %20)

-Implementing the music to the Story screen (Completion: %20)

## **Completed**

-Finding a suitable music

## Challenges

-The challenge here was to find music that matches the concept.

# **User Interface (Completion: %65)**

We do not have many UI elements in gameplay because we want to give an immersive experience. However, this does not mean we can keep it at zero percent. The player still needs some little UI elements to play the game.

## Work In Progress

-Starting screen (Completion: %80)

-Main Menu (Completion: %50)

-Level Completed screen (Completion: %60)

-Game Over screen (Completion: %50)

## **Completed**

-Credits screen

-Story screen

-Object interaction indicator

-Aim marker

# **User Testing (Completion: %0)**

Currently, the game is not ready for user testing. However, it is very close to being ready. We are estimating that we will start user testing in the next week.

## **Challenges**

-We should have started the user testing much earlier. Testers will undoubtedly find problems in the game and we will have little time to fix them.

# **Multiplayer (Completion: %0)**

During the development process, it was decided that multiplayer is redundant and will not improve the user experience. As a result, we did not implement it in the current version.
# **In Game Screenshots**
![1](https://user-images.githubusercontent.com/45337205/169548677-ae324670-1cde-43ec-b17c-3d9ec16ad550.png)
![2](https://user-images.githubusercontent.com/45337205/169548694-7d054db6-c72c-4c62-bc2d-3f329a040df9.png)
![3](https://user-images.githubusercontent.com/45337205/169548702-fea86cc1-57d9-4625-905d-33e5a5efa854.png)
![4](https://user-images.githubusercontent.com/45337205/169548716-2893e20a-dc71-410d-82c5-a0e883c2af90.png)
