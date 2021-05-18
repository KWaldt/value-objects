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
* Description: Not accessible in scripts - that one's just for you in case the variable name isn't clear enough.
* ID: GUID, auto-generated on creation. If you duplicate the ScriptableObject please hit the "Generate" button for a new ID.
  * You don't necessarily need the ID, but it works well with save systems. In that case you might also want to write a checker to make sure that they are all unique.
* IntObject: Optiona minimum value. Useful for things like health that should never fall below zero.

## In Scripts / UnityEvents
* You can create serialized fields that either reference the type directly (e.g. BoolValue) or the parent (ValueObject).  
  ```[SerializeField] private ValueObject valueObject;```  
  ```[SerializeField] private GameObjectObject playerObject;```
  * You can't use GenericValueObject because Unity doesn't do well with generic fields.
  * Value object lacks all type-specific things like "RuntimeValue", but it supports the "ValueChanged" event and a "StringOutput" of the value.  
* Values
  * RuntimeValue (Property: T): The current value. Can read and write.
  * ID (Field: string): Useful if you want to use it with a save system.
  * ValueChanged (Event): Gets called when the value changes.
  * ValueChangedTo (Event: T): Gets called when the value changes and sends the current value.
  * StringOutput : Gets the RuntimeValue as a string. Sometimes that's a changed result.
    * e.g. GameObjetObject outputs gameObject.name
  * Some types have extra methods to make them more comfortable or easier to use in UnityEvents. 
    * e.g. "Add" in IntObject
    
# Extending
* Create a new script.
  * If you use Script Templates: the one for ScriptableObjects will do just fine.
* Inherit from GenericValueObject<YOURTYPE>.
* Add the CreateAssetMenu attribute.
  * If you want, you can use the constant "MenuPath" to have your ValueObject in the same place as the others.
* You can add some quality of life functions to it. 

Here's the bare-minimum example:
```
using KristinaWaldt.ValueObjects;
using UnityEngine;

[CreateAssetMenu(fileName = "AudioSource", menuName = MenuPath + "AudioSource")]
public class AudioSourceObject : GenericValueObject<AudioSource>
{
}
```

And if you love yourself, you could so something like this:
```
using KristinaWaldt.ValueObjects;
using UnityEngine;

[CreateAssetMenu(fileName = "AudioSource", menuName = MenuPath + "AudioSource")]
public class AudioSourceObject : GenericValueObject<AudioSource>
{
    public bool IsAssigned()
    {
        return RuntimeValue != null;
    }

    public void PlayIfPossible()
    {
        if (!IsAssigned())
            return;

        RuntimeValue.Play();
    }

    public void PlayOneShotIfPossible(AudioClip clip, float volumeScale = 1f)
    {
        if (!IsAssigned())
            return;

        RuntimeValue.PlayOneShot(clip, volumeScale);
    }
}
```
Of course this depends on your needs. You can always add QoL functions later when you realise that you're doing something often.

# Content
## Basics
* ValueObject: You can use this as a variable type if you're only interested in ValueChanged.
* GenericValueObject: This is what you inherit from when you make your own ScriptableObject variables.

## Variable Types
* Bool
* Float
* GameObjectObject
* Int
* String

## Example Components
* AssignToGameObjectObject
  * Assigns the current gameObject to the ScriptableObject in Awake. Useful for storing the player and similar. Remember that if you want to use the RuntimeValue of the GameObjectObject in another script, you need to do so in Start. (Or else it isn't assigned yet.)
* OnValueObjectChange
  * Invokes a UnityEvent when a ValueObject changes. (Works with any type, e.g bool, float, string...) Useful to connect behaviours without scripting.
    * Example: If the coinCount (IntObject) changes, play sounds, particles, deactivate an object etc.
* SetTextToIntObject
  * Sets the TextMeshProUGUI to an IntObject with optinal padding. (e.g. 1 → 001)
* SetTextToValueObject
  * Sets the TextMeshProUGUI to StringOutput() of a ValueObject. That's typically the RuntimeValue, but that can be overwritten. (e.g. GameObjectObject doesn't output "gameObject" but either the gameObject.name or "(none)".)
