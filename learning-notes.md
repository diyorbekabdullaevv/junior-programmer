# Unity Junior Programmer Learning Notes

![Unity](https://img.shields.io/badge/Unity-6.3-black?logo=unity)
![C#](https://img.shields.io/badge/C%23-Language-239120?logo=csharp)
![Unity Learn](https://img.shields.io/badge/Unity%20Learn-Junior%20Programmer-black?logo=unity)

Technical notes from completing the **Unity Junior Programmer** learning pathway.

These notes cover Unity fundamentals, C# programming, gameplay systems, physics, UI, debugging, optimization, Git, publishing, and other concepts learned throughout the course.

---

# Table of Contents

1. [Unity Fundamentals](#1-unity-fundamentals)
   - [GameObject](#gameobject)
   - [Components](#components)
   - [Transform](#transform)
   - [Prefabs](#prefabs)

2. [Unity Lifecycle](#2-unity-lifecycle)
   - [Awake](#awake)
   - [Start](#start)
   - [Update](#update)
   - [FixedUpdate](#fixedupdate)
   - [OnEnable / OnDisable](#onenable--ondisable)

3. [C# Fundamentals](#3-c-fundamentals)
   - [Variables](#variables)
   - [Public and Private](#public-and-private)
   - [Methods](#methods)
   - [Parameters](#parameters)
   - [Return Values](#return-values)
   - [Conditionals](#conditionals)
   - [Loops](#loops)
   - [Arrays and Lists](#arrays-and-lists)

4. [Unity Physics](#4-unity-physics)
   - [Rigidbody](#rigidbody)
   - [AddForce](#addforce)
   - [ForceMode](#forcemode)
   - [Collider](#collider)
   - [Trigger](#trigger)
   - [Collision vs Trigger](#collision-vs-trigger)
   - [Physics Material](#physics-material)

5. [Input System](#5-input-system)
   - [Input Actions](#input-actions)
   - [InputAction Lifecycle](#inputaction-lifecycle)
   - [Mouse Input](#mouse-input)

6. [Movement and Coordinates](#6-movement-and-coordinates)
   - [Vector2](#vector2)
   - [Vector3](#vector3)
   - [Global vs Local Coordinates](#global-vs-local-coordinates)
   - [Time.deltaTime](#timedeltatime)

7. [Gameplay Programming](#7-gameplay-programming)
   - [Instantiate](#instantiate)
   - [Destroy](#destroy)
   - [Random.Range](#randomrange)
   - [InvokeRepeating](#invokerepeating)
   - [Coroutines](#coroutines)

8. [Enemy AI](#8-enemy-ai)

9. [Powerups](#9-powerups)

10. [Animation](#10-animation)

11. [Audio](#11-audio)
    - [AudioClip](#audioclip)
    - [AudioSource](#audiosource)
    - [PlayOneShot](#playoneshot)

12. [Particle Systems](#12-particle-systems)

13. [User Interface](#13-user-interface)
    - [Canvas](#canvas)
    - [TextMeshPro](#textmeshpro)
    - [UI Buttons](#ui-buttons)
    - [Game States](#game-states)

14. [Raycasting](#14-raycasting)

15. [Scene Management](#15-scene-management)

16. [Data Persistence](#16-data-persistence)
    - [DontDestroyOnLoad](#dontdestroyonload)
    - [Static Members](#static-members)
    - [Singleton Pattern](#singleton-pattern)

17. [Saving and Loading Data](#17-saving-and-loading-data)
    - [JSON](#json)
    - [JsonUtility](#jsonutility)
    - [System.IO](#systemio)

18. [Object-Oriented Programming](#18-object-oriented-programming)
    - [Abstraction](#abstraction)
    - [Encapsulation](#encapsulation)
    - [Inheritance](#inheritance)
    - [Polymorphism](#polymorphism)

19. [Access Modifiers](#19-access-modifiers)
    - [Public](#public)
    - [Private](#private)
    - [Protected](#protected)

20. [Properties](#20-properties)

21. [Code Refactoring](#21-code-refactoring)

22. [Optimization](#22-optimization)
    - [Object Pooling](#object-pooling)

23. [Unity Profiler](#23-unity-profiler)

24. [Debugging](#24-debugging)
    - [Compilation Errors](#compilation-errors)
    - [Runtime Exceptions](#runtime-exceptions)
    - [Logic Errors](#logic-errors)

25. [Git and GitHub](#25-git-and-github)
    - [Important Git Concepts](#important-git-concepts)
    - [Typical Workflow](#typical-workflow)
    - [Merge Conflicts](#merge-conflicts)

26. [Publishing Unity Projects](#26-publishing-unity-projects)

27. [ECS and DOTS](#27-ecs-and-dots)
    - [ECS](#ecs)
    - [DOTS](#dots)

28. [Important Unity APIs](#28-important-unity-apis)

29. [Practical Gameplay Systems](#29-practical-gameplay-systems)
    - [Player Jump](#player-jump)
    - [Enemy AI](#enemy-ai-1)
    - [Powerup System](#powerup-system)
    - [Enemy Spawning](#enemy-spawning)
    - [Endless Runner](#endless-runner)
    - [Score UI](#score-ui)
    - [Efficient Spawning](#efficient-spawning)

30. [Key Takeaways](#30-key-takeaways)

---

# 1. Unity Fundamentals

## GameObject

A **GameObject** is the basic object/container in a Unity scene.

Examples:

- Player
- Enemy
- Camera
- Projectile
- Powerup
- UI element

GameObjects get their behavior and functionality through **Components**.

---

## Components

Components add functionality to GameObjects.

Common components:

- `Transform` — position, rotation, and scale
- `Rigidbody` — physics simulation
- `Collider` — collision detection
- `Mesh Renderer` — displays 3D objects
- `Animator` — controls animations
- `AudioSource` — plays audio

---

## Transform

Every GameObject has a Transform.

It controls:

- Position
- Rotation
- Scale

Example:

```csharp
transform.position = new Vector3(0, 1, 0);
```

---

## Prefabs

A **Prefab** is a reusable GameObject template.

Useful for:

- Enemies
- Projectiles
- Powerups
- Effects
- UI elements

Instead of creating the same object manually every time, a Prefab can be instantiated during gameplay.

---

# 2. Unity Lifecycle

Unity scripts have several important lifecycle methods.

## Awake

Called when the object is initialized.

Often used to set up references.

```csharp
void Awake()
{
    playerRb = GetComponent<Rigidbody>();
}
```

---

## Start

Called before the first frame update.

Commonly used for initial game setup.

```csharp
void Start()
{
    score = 0;
}
```

---

## Update

Called once per frame.

Useful for:

- Input
- Timers
- Game state
- Non-physics movement

```csharp
void Update()
{
    // Runs every frame
}
```

---

## FixedUpdate

Called at fixed time intervals.

Mainly used for physics-related operations.

```csharp
void FixedUpdate()
{
    playerRb.AddForce(Vector3.forward);
}
```

### Important Difference

- `Update()` → frame-based
- `FixedUpdate()` → physics timestep-based

---

## OnEnable / OnDisable

Useful when working with objects that are enabled and disabled.

A common Input System pattern is:

```text
Awake()
    ↓
Initialize

OnEnable()
    ↓
Enable input

OnDisable()
    ↓
Disable input
```

---

# 3. C# Fundamentals

## Variables

Variables store data.

```csharp
int score = 10;
float speed = 5.5f;
bool gameOver = false;
string playerName = "Player";
```

Common types:

- `int` — whole numbers
- `float` — decimal numbers
- `double` — higher-precision decimal numbers
- `bool` — true / false
- `string` — text
- `Vector2` — 2D vector
- `Vector3` — 3D vector

---

## Public and Private

```csharp
public float speed = 5f;
private int score;
```

- `public` → accessible from other scripts/classes
- `private` → accessible only inside the class

Use access control to avoid exposing data unnecessarily.

---

## Methods

Methods contain reusable blocks of code.

```csharp
void Jump()
{
    Debug.Log("Jump");
}
```

Methods make code easier to:

- Read
- Reuse
- Maintain
- Test

---

## Parameters

Parameters allow data to be passed into methods.

```csharp
void AddScore(int amount)
{
    score += amount;
}
```

Call:

```csharp
AddScore(10);
```

---

## Return Values

Methods can return values.

```csharp
int GetScore()
{
    return score;
}
```

The return type is written before the method name.

---

## Conditionals

Conditionals are used to make decisions.

```csharp
if (score > 10)
{
    Debug.Log("High Score");
}
else
{
    Debug.Log("Keep Playing");
}
```

Logical operators:

```text
&& → AND
|| → OR
!  → NOT
```

Example:

```csharp
if (isOnGround && !gameOver)
{
    Jump();
}
```

---

## Loops

Common C# loops include:

- `for`
- `while`
- `foreach`

Example:

```csharp
for (int i = 0; i < 10; i++)
{
    Debug.Log(i);
}
```

Loops are useful for:

- Spawning waves
- Processing collections
- Repeating operations

---

## Arrays and Lists

### Array

Arrays store a fixed number of elements.

```csharp
GameObject[] enemies;
```

### List

Lists are dynamic collections.

```csharp
List<GameObject> enemies = new List<GameObject>();
```

A `List` can grow or shrink during runtime.

---

# 4. Unity Physics

## Rigidbody

`Rigidbody` allows a GameObject to interact with Unity's physics system.

Common uses:

- Gravity
- Movement
- Forces
- Physics collisions

Example:

```csharp
private Rigidbody rb;

void Start()
{
    rb = GetComponent<Rigidbody>();
}
```

---

## AddForce

Used to apply a force to a Rigidbody.

```csharp
rb.AddForce(Vector3.up * jumpForce);
```

Useful for:

- Jumping
- Knockback
- Launching objects
- Physics-based movement

---

## ForceMode

Controls how a force is applied.

Example:

```csharp
rb.AddForce(
    Vector3.up * jumpForce,
    ForceMode.Impulse
);
```

`ForceMode.Impulse` is useful for immediate forces such as:

- Jumping
- Knockback
- Explosive forces

---

## Collider

Colliders define the physical shape of an object.

Examples:

- Box Collider
- Sphere Collider
- Capsule Collider
- Mesh Collider

---

## Trigger

A Collider can be configured as a Trigger.

Triggers detect overlap without creating a physical collision response.

```csharp
private void OnTriggerEnter(Collider other)
{
    // Trigger detected
}
```

---

## Collision vs Trigger

### Collision

Used when objects physically interact.

```csharp
void OnCollisionEnter(Collision collision)
{
}
```

### Trigger

Used when objects overlap without physical collision response.

```csharp
void OnTriggerEnter(Collider other)
{
}
```

---

## Physics Material

Physics Materials control physical behavior.

Common properties include:

- Friction
- Bounciness

Useful for:

- Balls
- Platforms
- Sliding objects
- Arcade physics

---

# 5. Input System

Unity's Input System provides a flexible way to handle player input.

## Input Actions

Input Actions represent gameplay actions.

Examples:

- Move
- Jump
- Attack
- Interact

Example:

```csharp
Vector2 movement =
    controls.Player.Move.ReadValue<Vector2>();
```

---

## InputAction Lifecycle

Input actions can be enabled and disabled.

```csharp
private void Awake()
{
    controls = new PlayerControls();
}

private void OnEnable()
{
    controls.Enable();
}

private void OnDisable()
{
    controls.Disable();
}
```

This ensures the input actions are active only when needed.

---

## Mouse Input

The Input System can detect mouse input.

```csharp
if (Mouse.current.leftButton.wasPressedThisFrame)
{
    // Mouse clicked
}
```

`wasPressedThisFrame` is true only during the frame when the button is pressed.

---

# 6. Movement and Coordinates

## Vector2

`Vector2` represents two-dimensional values.

```csharp
Vector2 movement;
```

It contains:

```text
X
Y
```

Common uses:

- 2D movement
- Player input
- UI coordinates

---

## Vector3

`Vector3` represents three-dimensional values.

```csharp
Vector3 direction;
```

It contains:

```text
X
Y
Z
```

Common uses:

- Position
- Direction
- Movement
- Rotation

---

## Global vs Local Coordinates

**Global coordinates** represent an object's position relative to the world.

**Local coordinates** represent an object's position relative to its parent.

This distinction is important when working with:

- Child objects
- Cameras
- Player movement
- Rotations

---

## Time.deltaTime

`Time.deltaTime` represents the time since the previous frame.

It is commonly used to make movement frame-rate independent.

```csharp
transform.Translate(
    Vector3.forward * speed * Time.deltaTime
);
```

Without `Time.deltaTime`, movement can depend on the number of frames per second.

---

# 7. Gameplay Programming

## Instantiate

Creates a copy of a GameObject or Prefab.

```csharp
Instantiate(
    enemyPrefab,
    spawnPosition,
    Quaternion.identity
);
```

Useful for:

- Enemies
- Projectiles
- Powerups
- Obstacles
- Effects

---

## Destroy

Removes a GameObject.

```csharp
Destroy(gameObject);
```

It can also be delayed:

```csharp
Destroy(gameObject, 2f);
```

---

## Random.Range

Generates a random value within a range.

```csharp
float randomValue =
    Random.Range(0f, 10f);
```

Useful for:

- Random spawning
- Random positions
- Random enemy types
- Random gameplay behavior

---

## InvokeRepeating

Calls a method repeatedly after a delay.

```csharp
InvokeRepeating(
    "SpawnEnemy",
    2f,
    3f
);
```

Useful for simple repeating systems such as enemy spawning.

---

## Coroutines

Coroutines allow code to execute over time.

```csharp
IEnumerator WaitAndSpawn()
{
    yield return new WaitForSeconds(2f);

    SpawnEnemy();
}
```

Start a Coroutine:

```csharp
StartCoroutine(WaitAndSpawn());
```

Useful for:

- Delays
- Timers
- Powerup durations
- Spawn sequences
- Temporary effects

---

# 8. Enemy AI

Simple enemy AI can be created by calculating the direction toward the player.

```csharp
Vector3 direction =
    player.transform.position -
    transform.position;

direction.Normalize();
```

Then apply movement:

```csharp
rb.AddForce(direction * speed);
```

Basic process:

```text
Find Player
     ↓
Calculate Direction
     ↓
Normalize Direction
     ↓
Apply Movement
     ↓
Repeat
```

This is simple target-following AI rather than a full pathfinding system.

---

# 9. Powerups

Powerups can temporarily change player abilities.

Examples:

- Speed boost
- Force boost
- Invincibility
- Extra health

A basic powerup system can use:

1. Trigger detection
2. A Boolean state
3. A Coroutine timer
4. Visual feedback

Example:

```csharp
private void OnTriggerEnter(Collider other)
{
    if (other.CompareTag("Player"))
    {
        StartCoroutine(PowerupRoutine());
    }
}
```

Basic structure:

```text
Player enters trigger
        ↓
Activate powerup
        ↓
Change player ability
        ↓
Start timer
        ↓
Timer expires
        ↓
Restore normal ability
```

---

# 10. Animation

Unity uses the **Animator** component to control animations.

Animator parameters can include:

- `Trigger`
- `Bool`
- `Integer`
- `Float`

### Trigger

Useful for one-time events.

```csharp
animator.SetTrigger("Jump");
```

### Bool

Useful for states.

```csharp
animator.SetBool("IsRunning", true);
```

### Integer

Useful for selecting between multiple states or variations.

```csharp
animator.SetInteger("State", 1);
```

Animations can represent gameplay states such as:

- Running
- Jumping
- Attacking
- Dying
- Winning

---

# 11. Audio

## AudioClip

An `AudioClip` contains an audio file.

Examples:

- Music
- Jump sound
- Explosion
- Button click
- Hit sound

---

## AudioSource

An `AudioSource` plays audio in Unity.

```csharp
AudioSource audioSource;

void Start()
{
    audioSource =
        GetComponent<AudioSource>();
}
```

---

## PlayOneShot

Plays a sound effect.

```csharp
audioSource.PlayOneShot(clip);
```

Useful for:

- Sound effects
- Player actions
- Collisions
- UI interactions

---

# 12. Particle Systems

Particle Systems are used for visual effects.

Examples:

- Smoke
- Fire
- Dirt
- Explosion
- Sparks
- Splatter

Particle systems can be controlled through code:

```csharp
particle.Play();
```

Stop a particle system:

```csharp
particle.Stop();
```

Particle effects provide visual feedback and make gameplay interactions feel more responsive.

---

# 13. User Interface

## Canvas

The Canvas contains Unity UI elements.

Common UI elements include:

- Text
- Buttons
- Images
- Panels
- Sliders

---

## TextMeshPro

TextMeshPro is commonly used for high-quality UI text.

Example:

```csharp
scoreText.text =
    "Score: " + score;
```

It can be used for:

- Score
- Timers
- Menus
- Instructions
- Game-over messages

---

## UI Buttons

Buttons can trigger methods when clicked.

Common uses:

- Start Game
- Restart
- Quit
- Difficulty selection
- Main Menu

---

## Game States

UI often changes depending on the current game state.

Common states:

```text
Main Menu
    ↓
Playing
    ↓
Game Over
    ↓
Restart
```

Other possible states include:

- Paused
- Victory
- Loading

---

# 14. Raycasting

Raycasting sends an imaginary line from one point in a specific direction to detect objects.

Basic idea:

```text
Origin ───────────────→ Direction

             Object
```

Example:

```csharp
Ray ray =
    Camera.main.ScreenPointToRay(
        Input.mousePosition
    );

if (Physics.Raycast(
    ray,
    out RaycastHit hit))
{
    Debug.Log(hit.collider.name);
}
```

Useful for:

- Mouse interaction
- Shooting
- Object selection
- Detecting objects in front of the player
- Click-based gameplay

---

# 15. Scene Management

Unity projects can contain multiple scenes.

Examples:

- Main Menu
- Gameplay
- Game Over
- Level 1
- Level 2

Unity provides `SceneManager` for scene management.

Import:

```csharp
using UnityEngine.SceneManagement;
```

Load a scene:

```csharp
SceneManager.LoadScene("Game");
```

Scenes help organize different parts of a game.

---

# 16. Data Persistence

Data persistence means keeping data available when changing scenes or during gameplay.

## DontDestroyOnLoad

Normally, GameObjects are destroyed when changing scenes.

`DontDestroyOnLoad()` keeps a GameObject alive.

```csharp
DontDestroyOnLoad(gameObject);
```

Useful for:

- Game managers
- Audio managers
- Player data
- Settings

---

## Static Members

Static members belong to the class rather than a specific object.

Example:

```csharp
public static int score;
```

They can be used to share simple data between objects or scenes.

Static data should be used carefully because it creates shared global state.

---

## Singleton Pattern

A Singleton provides one central instance of a class.

Common examples:

- Game Manager
- Audio Manager
- Save Manager

Basic idea:

```text
One manager instance
        ↓
Other systems access it
```

Singletons can be useful, but they should not be overused because excessive global state can make systems harder to maintain.

---

# 17. Saving and Loading Data

Game data can be saved using formats such as JSON.

## JSON

JSON is a text-based data format.

Example:

```json
{
	"score": 100,
	"coins": 25
}
```

A typical saving process is:

```text
Game Data
    ↓
Serialize
    ↓
JSON
    ↓
File
```

Loading reverses the process:

```text
File
    ↓
JSON
    ↓
Deserialize
    ↓
Game Data
```

---

## JsonUtility

Unity provides `JsonUtility` for basic JSON serialization and deserialization.

Serialize:

```csharp
string json =
    JsonUtility.ToJson(data);
```

Deserialize:

```csharp
Data data =
    JsonUtility.FromJson<Data>(json);
```

---

## System.IO

`System.IO` provides file-handling functionality.

Write data:

```csharp
File.WriteAllText(path, json);
```

Read data:

```csharp
string json =
    File.ReadAllText(path);
```

It can be used to:

- Create files
- Read files
- Write files
- Check whether files exist

---

# 18. Object-Oriented Programming

OOP is a programming approach based on objects and classes.

The four main principles are:

```text
Abstraction
Encapsulation
Inheritance
Polymorphism
```

## Abstraction

Shows only the necessary details while hiding implementation complexity.

Example:

```text
Player.Move()
```

Other systems can use the method without needing to know every internal movement calculation.

**Goal:** simplify usage and reduce complexity.

---

## Encapsulation

Controls access to an object's internal data.

Example:

```csharp
private int health;
```

Instead of allowing every script to modify `health` directly, controlled access can be provided through methods or properties.

**Goal:** protect data and control how it changes.

---

## Inheritance

Allows one class to inherit functionality from another class.

Example:

```csharp
class Enemy : Character
{
}
```

Conceptually:

```text
Character
   ↓
Player
Enemy
```

Unity scripts commonly inherit from:

```csharp
MonoBehaviour
```

---

## Polymorphism

Allows different classes to provide different implementations through a shared type or interface.

Conceptually:

```text
Character
   ↓
Player
Enemy
```

Both can share a common interface while behaving differently.

---

# 19. Access Modifiers

Access modifiers control who can access variables and methods.

Common modifiers:

```text
public
private
protected
```

## Public

Accessible from other classes.

```csharp
public float speed;
```

---

## Private

Accessible only inside the class.

```csharp
private int score;
```

---

## Protected

Accessible inside the class and derived classes.

```csharp
protected int health;
```

General rule:

> Keep fields as restricted as possible and expose only what other systems need.

---

# 20. Properties

Properties provide controlled access to data.

Example:

```csharp
private int health;

public int Health
{
    get { return health; }
    set { health = value; }
}
```

Properties can be useful for:

- Encapsulation
- Validation
- Read-only access
- Controlled modification

Example:

```csharp
public int Score { get; private set; }
```

This allows other classes to read the score but prevents them from directly changing it.

---

# 21. Code Refactoring

Refactoring means improving the structure of code without changing its intended behavior.

Examples:

- Break large methods into smaller methods.
- Remove duplicated code.
- Use meaningful variable names.
- Organize related functionality.
- Reduce unnecessary complexity.
- Improve readability.

Instead of one large method:

```text
Movement
Spawning
Random calculations
UI updates
Game state
```

Separate the functionality:

```text
Move()
Spawn()
GenerateRandomPosition()
UpdateScore()
HandleGameState()
```

Benefits:

- Easier debugging
- Easier maintenance
- Better readability
- Better code reuse
- Easier testing

---

# 22. Optimization

Optimization improves performance while maintaining the desired game behavior.

Important techniques include:

- Object pooling
- Reducing unnecessary object creation
- Avoiding unnecessary calculations
- Reducing expensive operations
- Profiling before optimizing
- Organizing code efficiently

## Object Pooling

Object Pooling reuses objects instead of constantly creating and destroying them.

Instead of:

```text
Instantiate()
    ↓
Use
    ↓
Destroy()
    ↓
Instantiate()
    ↓
Destroy()
```

Use:

```text
Create objects
      ↓
Store in pool
      ↓
Activate when needed
      ↓
Use
      ↓
Deactivate
      ↓
Reuse
```

Useful for:

- Bullets
- Enemies
- Particles
- Obstacles
- Projectiles

Benefits:

- Reduces repeated allocations
- Reduces Instantiate/Destroy overhead
- Can reduce garbage collection
- Useful for frequently spawned objects

---

# 23. Unity Profiler

The Unity Profiler helps identify performance problems.

It can help analyze:

- CPU usage
- Memory usage
- Rendering
- Scripts
- Garbage Collection

General optimization process:

```text
Run the game
      ↓
Measure performance
      ↓
Find bottleneck
      ↓
Optimize the relevant area
      ↓
Measure again
```

Important principle:

> **Profile before optimizing.**

Do not optimize based only on assumptions. First identify the actual bottleneck.

---

# 24. Debugging

A basic debugging workflow:

```text
Run the game
      ↓
Observe the problem
      ↓
Check the Console
      ↓
Read the error
      ↓
Inspect the related script
      ↓
Identify the cause
      ↓
Fix the problem
      ↓
Test again
```

## Compilation Errors

Compilation errors prevent the project from compiling correctly.

Example:

```text
CS0103: The name 'example' does not exist in the current context
```

Possible causes:

- Syntax errors
- Missing references
- Incorrect class names
- Missing namespaces
- Invalid code

---

## Runtime Exceptions

Runtime exceptions occur while the game is running.

Common example:

```text
NullReferenceException
```

This often means the code is trying to access something that is `null`.

---

## Logic Errors

The code runs without an error, but the game behaves incorrectly.

Examples:

- Player moves in the wrong direction.
- Enemy spawns at the wrong position.
- Score increases incorrectly.
- Game ends unexpectedly.

Logic errors often require inspecting the program's behavior and checking assumptions in the code.

---

# 25. Git and GitHub

Git is a version control system.

GitHub is a platform for hosting Git repositories.

## Important Git Concepts

- Repository
- Commit
- Branch
- Push
- Pull
- Merge
- Merge conflict

---

## Typical Workflow

After making changes:

```bash
git add .
git commit -m "Add gameplay changes"
git push
```

To receive changes from the remote repository:

```bash
git pull
```

Typical workflow:

```text
Modify files
    ↓
git add
    ↓
git commit
    ↓
git push
```

---

## Merge Conflicts

A merge conflict happens when Git cannot automatically combine changes.

Basic process:

1. Run `git pull` or merge.
2. Open the conflicting file.
3. Decide which changes to keep.
4. Remove conflict markers.
5. Save the file.
6. Commit the resolved changes.

Git is useful for:

- Tracking project history
- Collaborating with others
- Maintaining backups
- Managing different versions of a project

---

# 26. Publishing Unity Projects

Unity can build projects for different platforms.

Examples:

- Windows
- macOS
- Linux
- WebGL

Before publishing, consider:

- Target platform
- Resolution
- Quality settings
- Input
- Performance
- Build size
- Platform-specific behavior

A build should be tested on the target platform before being released.

Basic process:

```text
Finish development
      ↓
Configure build settings
      ↓
Select target platform
      ↓
Build project
      ↓
Test build
      ↓
Publish
```

---

# 27. ECS and DOTS

## ECS

ECS stands for **Entity Component System**.

It separates game data and behavior into:

- **Entity** — represents an object.
- **Component** — contains data.
- **System** — processes entities and their data.

Conceptually:

```text
Entity
   ↓
Components
   ↓
Systems process data
```

---

## DOTS

DOTS stands for **Data-Oriented Technology Stack**.

It is Unity's technology approach focused on high-performance, data-oriented development.

The main idea is to organize data and processing in ways that can improve performance, especially when dealing with large numbers of objects.

---

# 28. Important Unity APIs

| API                        | Purpose                             |
| -------------------------- | ----------------------------------- |
| `GetComponent<T>()`        | Get a component from a GameObject   |
| `GameObject.Find()`        | Find a GameObject by name           |
| `Instantiate()`            | Create an object                    |
| `Destroy()`                | Remove an object                    |
| `AddForce()`               | Apply physics force                 |
| `Random.Range()`           | Generate random values              |
| `InvokeRepeating()`        | Repeatedly call a method            |
| `StartCoroutine()`         | Start a Coroutine                   |
| `WaitForSeconds()`         | Wait inside a Coroutine             |
| `SetActive()`              | Enable/disable a GameObject         |
| `CompareTag()`             | Check an object's tag               |
| `FindObjectsByType()`      | Find objects of a specific type     |
| `SetTrigger()`             | Set an Animator trigger             |
| `SetBool()`                | Set an Animator Boolean             |
| `SetInteger()`             | Set an Animator integer             |
| `Play()`                   | Play a particle effect              |
| `Stop()`                   | Stop a particle effect              |
| `PlayOneShot()`            | Play an audio clip once             |
| `ScreenPointToRay()`       | Create a ray from a screen position |
| `SceneManager.LoadScene()` | Load a Unity scene                  |
| `DontDestroyOnLoad()`      | Preserve an object between scenes   |

---

# 29. Practical Gameplay Systems

This section connects the concepts above to common gameplay systems implemented during the learning pathway.

## Player Jump

A typical jump system can use:

- Rigidbody
- `AddForce()`
- `ForceMode.Impulse`
- Ground detection
- Input System

Basic process:

```text
Player presses Jump
        ↓
Check if player is grounded
        ↓
Apply upward impulse
        ↓
Player jumps
```

Example:

```csharp
if (isOnGround && jumpAction.triggered)
{
    playerRb.AddForce(
        Vector3.up * jumpForce,
        ForceMode.Impulse
    );
}
```

---

## Enemy AI

Basic enemy chasing:

```text
Find Player
     ↓
Calculate Direction
     ↓
Normalize Direction
     ↓
Apply Movement / Force
     ↓
Repeat
```

The direction can be calculated using:

```csharp
Vector3 direction =
    player.transform.position -
    transform.position;

direction.Normalize();
```

---

## Powerup System

A temporary powerup can follow this structure:

```text
Player enters trigger
        ↓
Activate powerup
        ↓
Change player ability
        ↓
Start timer
        ↓
Timer expires
        ↓
Restore normal ability
```

Coroutines are useful for controlling the duration.

---

## Enemy Spawning

A Spawn Manager can:

1. Store an enemy Prefab.
2. Generate a spawn position.
3. Instantiate the Prefab.
4. Repeat spawning based on game conditions.

Conceptually:

```text
Spawn Manager
      ↓
Generate position
      ↓
Instantiate Prefab
      ↓
Enemy appears
      ↓
Repeat
```

---

## Endless Runner

In an endless runner:

- The player may remain mostly in place.
- Obstacles move toward the player.
- Background objects can also move.
- Objects can be destroyed or repositioned after leaving the playable area.

This creates the illusion of continuous forward movement.

---

## Score UI

A score system can update a TextMeshPro element.

```csharp
scoreText.text =
    "Score: " + score;
```

The score can change when the player:

- Collects an item.
- Hits a target.
- Survives for a period of time.
- Completes an objective.

---

## Efficient Spawning

When many objects are repeatedly created and destroyed, Object Pooling can be used.

Instead of:

```text
Instantiate
    ↓
Use
    ↓
Destroy
```

Use:

```text
Create
    ↓
Store
    ↓
Activate
    ↓
Use
    ↓
Deactivate
    ↓
Reuse
```

This is especially useful for:

- Bullets
- Projectiles
- Enemies
- Obstacles
- Particle effects

---

# 30. Key Takeaways

After completing the Unity Junior Programmer pathway, the main concepts learned include:

- Unity GameObjects and Components
- Transform and Prefabs
- C# fundamentals
- Unity lifecycle methods
- Input System
- Vector2 and Vector3
- Player movement
- Physics and Rigidbody
- Collision and Triggers
- Physics Materials
- Instantiate and Destroy
- Random spawning
- Coroutines
- Enemy AI
- Powerups
- Animation
- Audio
- Particle Systems
- UI and TextMeshPro
- Game states
- Raycasting
- Scene Management
- Data Persistence
- JSON
- Saving and Loading
- Object-Oriented Programming
- Access Modifiers
- Properties
- Code Refactoring
- Object Pooling
- Optimization
- Unity Profiler
- Debugging
- Git and GitHub
- Publishing Unity projects
- ECS and DOTS

The most important next step is to **apply these concepts independently** by building original projects instead of only following tutorials.
