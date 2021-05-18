# Unity: Value Objects
This package includes ScriptableObject variables and some example scripts on how to implement them.  
The Value Objects are reset to their default value everytime you start the game, but keep their value even on scene change.  
The concept is based on this idea:  
https://unity.com/how-to/architect-game-code-scriptable-objects#architect-variables

The Value Objects are extendable for your own custom types and come with a custom editor that shows you the ingame value.

## How to install
* Open the Package Manager
* Plus-Icon: Add package from git URL...
* Use the HTTPS adress found in "Clone" (https://github.com/KWaldt/value-objects.git)

# Usage

## Creating new variable objects
* Project Folder > Right click > Create > Data > Variables

## Variable Settings
* Default Value: The value the ScriptableObject is reset to at game start.
* IntObject: Optiona minimum value. Useful for things like health that should never fall below zero.

## In Scripts / UnityEvents
* You can create serialized fields that either reference the type directly (e.g. BoolValue) or the parent (ValueObject).
  ```[SerializeField] private ValueObject valueObject;```  
  ```[SerializeField] private GameObjectObject playerObject;```
  * You can't use GenericValueObject because Unity doesn't do well with generic fields.
  * Value object lacks all type-specific things like "RuntimeValue", but it supports the "ValueChanged" event and a "StringOutput" of the value.  
* Values
  * RuntimeValue (Property): The current value. Can read and write.
  * ValueChanged (Event): Gets called when the value changes.
  * ValueChangedTo (Event): Gets called when the value changes and sends the current value.
  * StringOutput : Gets the RuntimeValue as a string. Sometimes that's a changed result.
    * e.g. GameObjetObject outputs gameObject.name
  * Some types have extra methods to make them more comfortable or easier to use in UnityEvents. 
    * e.g. "Add" in IntObject
    
# Extending
(TODO)

# Content
## Basics
* ValueObject: You can use this as a variable type if you're only interested in ValueChanged.
* GenericValueObject: This is what you inherit from when you make your own ScriptableObject variables.

## Variable Types
(TODO)

## Implementations
(TODO)
