Alexander Dolk	
The beginning of a larger scale project that is aimed to atleast mimic a mmorpg game.
As of now the game contains a simple statemachine, a custom eventsystem and a singleton driven Inventory

-------------------------------------------------------------------------------------------------

Patterns:
-Custom Event System in Assets/System/Event Base in 'BaseGameEvent.cs', in
'BaseGameEventListener.cs', and 'IGameEventListener.cs'. The code found in
'class BaseGameEvent', in 'class BaseGameEventListener' and in 'interface 
IGameEventListener'.

With these three base classes I can create my own custom events that also can send
data between scripts without having any dependencies. I can pass references from one 
class to another with these events which makes the code very modular in terms of just
taking one script and putting it in a different scene as there are nearly 
no dependencies. 

-------------------------------------------------------------------------------------------------

-State Machine in Assets/System/StateMachine in 'State.cs' and 'StateManager.cs'. 
Code found in 'class State' and 'class StateMachine'.

With the use of this statemachine it is easier to create the ai behaviour that I need
as having my states as seperate scripts it's easier to keep track of what code is run
where and when and reduces the amount of if statements that I would need otherwise to
an absolute minimum.

-------------------------------------------------------------------------------------------------

-Singleton in Assets/Player in 'PlayerInventory.cs'. Code found in 'class PlayerInventory'.

One of the coremechanics of an mmorpg is having an inventory where the player can store all of their possessions that 
they loot on their adventure. By making the inventory into a singleton it makes it really easy to access the inventory
without the need for dependencies when trying to look inside of the inventory. If the player is at a locked door and wants to open it
for example, I can have a script on the door itself that looks inside of the players inventory whether the player has a key for the door or not
instead of having to find the object that the inventory sits at in the scene and then doing a "GetComponent<PlayerInventory>()" to then access
the inventory.