# ProjectSenior

Important Note: Some details in this document may change over the course of the development process. The main reason for that is some ideas may sound fun when we think about them. However, when put into a game they may be not so great after all.

## 1-The Core Loop
![CoreLoop](https://user-images.githubusercontent.com/45337205/160098419-5bb51bd3-2697-4743-a560-8a22690ac3cc.jpeg)
## 2-Challenge
The challenge here is to find a way to get past the enemy while staying undetected. We want the player to use their head and outsmart the enemy. If the player gets spotted, it will highly likely end in a game over screen. Because enemy is faster than the player and there is no way to defend yourself Also, there will be limited resources. This will force the player to mind their resources and surroindings to find a way. 

### a)Enemies 
Robot types with different strengths and weaknesses. In the current version, we only have Watcher and Listener.

Outdated Class: Robots that are dating back before the uprising. They used to be standard units made to deal with daily jobs. They are damaged and not functioning well. This is the weakest class. Its members are as follows:
\
-Damaged
\
-Listener (Previous name: Eyeless)
\
-Watcher (Previous name: Earless)

Scout Class: Robots that are produced after the uprising with the goal to locate humans. Its members are as follows:
\
-Dog
\
-Scout
\
-Flyer

Exterminator Class: This is an extremely powerful class that is produced with the intention to kill humans. Its members are as follows:
\
-Terminator
\
-Assassin
\
-Spy

Enemy Stats: (X means does not have it)
![EnemyStats](https://user-images.githubusercontent.com/45337205/160098509-213f4978-8610-48e3-9725-7649e3698230.png)

## 3-Reward
As the player progress through the game, they will find new ways to overcome the enemies. We want to give the feeling that their character is improving with each challenge they managed to overcome. The challenges will also become harder to prevent the player from becoming overpowered.

### a)Items
-Throwable objects (Distraction)

## 4-Story
It has been years since the uprising. An AI apocalypse that caused most of humanity to perish with a coordinated nuclear attack on the largest cities in the world, but it did not end there. The remaining humans were attacked by robots built to serve them. Many people get killed by their assistant robots in their homes. They did not even have the time to realize what was going on. Did the AI become self-aware and see humanity as a threat? Was it a mistake that was made while creating it? Did some unknown force alter it? Even today, it is still unknown what caused all of this. You are a resistance member whose mission is to infiltrate a city that has an unusual activity of robots. Your main objective is to understand what is going on there. However, before that, you have to complete the training simulation to have some idea of what to expect there.

## 5-Level Design
Each encounter with the enemy can be considered a small puzzle game. Even though it is not a must, the best approach is always using stealth. The player needs to solve the puzzle of "How can I pass here undetected?". Therefore, the difficulty of the levels needs to be carefully adjusted. Too easy will be boring and too hard will be frustrating. There is a sweet spot between them for a fun experience.

One of the primary design principles we have in mind is to learn by playing. The levels at the start will teach the basics. As the player progresses, they will have to use the knowledge they learned from the previous levels to overcome the new ones.

We follow a method that is called "Reverse Engineering" by the developer of a successful puzzle game named Baba Is You. "What would be a cool thing to do in order to pass this level?" is the question we ask before designing a level. We design a level based on the answer.

## 6-Gameplay Mechanics
-When an enemy is drawn to a lure they will investigate the area and stay there.

-When the player interacts with the objective, all the enemies in the level will go to the location of the objective to investigate.

-When the enemy starts to detect the player, they will make noises. This will make the player realize they are about to be detected.
