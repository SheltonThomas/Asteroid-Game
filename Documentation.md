|Shelton Thomas|
|----|
|s198053|
|Math For Games|
|Asteroid Survival Game|

## I. Requirements

1. Description of Problem
    - **Name**: Math For Games

    - **Problem Statement**: Create math classes that implement Vector and Matrix objects for use in real-time applications.

    - **Problem Specifications**: Create Vector, Matrix, and Color classes that will pass all the tests in the Unit Test. With those classes make a 'technology demonstration' that demonstrates hierarchy and transformations with these classes and simple collision detection. Complete peer review where someone tests out my 'technology demonstration' and I test theirs. Be able to convert binary to decimal and decimal to binary.

2. Input Information:
    - Use the W, A, S and D keys to control your ship, space to shoot, and the arrow keys to rotate the gun.

## II. Design

1. Program Flow:

    - The player is spawned in and waits 5 seconds for the game to actually begin(which is when the first piece of debris spawns). The first spawner for debris is randomized between a 'space rock' and a satellite(it is more likely to get a 'space rock' than to be a satellite), 'space rocks' deal more damage if they hit you while the satellites can shoot while they are rotating.

        - Space Rocks:

        |
        |:---
        |![Space Rocks](https://media.giphy.com/media/YrrDGOrQ9Y5IxDDNpS/giphy.gif)
        |

        - Satellites:

        |
        |:---
        |![Satellites](https://media.giphy.com/media/S3JaI2sUR5qZoYI9tR/giphy.gif)
        |

    - The player must shoot the space debris and the bullets from the satellite to survive as long as possible, but the longer the game lasts the more spawners are spawned. Every bullet or space debris that the player destroy give the player points, which is displayed on the top right corner.

        - Score:

        |
        |:---
        |![Score](https://media.giphy.com/media/dyvNdSsidmFDOh1F5r/giphy.gif)
        |

    - The player will gain a bullet ever 1.5 seconds up to 10 bullets, the program shows ammo information on the top left corner of the screen.

        - Bullets:

        |
        |:---
        |![Bullets](https://media.giphy.com/media/lQC55LFSBgEcEoeH8T/giphy.gif)
        |

    - If the player is hit by a bullet or space debris they lose health.

        - Health:

        |
        |:---
        |![Health](https://media.giphy.com/media/dykC068kG9ptkIeX7c/200.gif)
        |

2. Object Information

    **File**: AABB.cs

    Description: Used for hitboxes and collision.

    **Attributes**:

        Name: Width
            Description: Used for the width of the hitboxes.
            Type: float
            Visibility: public

        Name: Height
            Description: Used for the height of the hitboxes.
            Type: float
            Visibility: public

        Name: Top
            Description: Used to get the top of the hitboxes.
            Type: float
            Visibility: public

        Name: Bottom
            Description: Used to get the bottom of the hitboxes.
            Type: float
            Visibility: public

        Name: Left
            Description: Used to get the left of the hitboxes.
            Type: float
            Visibility: public

        Name: Right
            Description: Used to get the right of the hitboxes.
            Type: float
            Visibility: public

        Name: AABB
            Description: Constructor for AABB.
            Visibility: public
            Parameters: float width, float height

        Name: DetectCollion
            Description: Used to detect if two hitboxes have collided.
            Type: bool
            Parameters: AABB other
            Visibility: public

        Name: DetectCollision
            Description: Used to detect if a hitbox has collided with a vector.
            Type: bool
            Parameters: Vector point
            Visibility: public

        Name: Draw
            Description: Used to draw the hitboxes on screen.
            Visibility: public

    **File**: Actor.cs

    Description: Used to as a base class for everything, including the scene.

    **Attributes**:

        Name: StartEvent
            Decription: Delegate to hold the start events for objects on a scene.
            Type: delegate void

        Name: UpdateEvent
            Description: Delegate to hold all update events for objects on a scene.
            Type: delegate void
            Parameters: float deltaTime

        Name: DrawEvent
            Description: Delegate to hold all draw events for objects on a scene.
            Type: delegate void

        Name: OnStart
            Descrption: Used to call all events that need to happen on the start of a scene.
            Type: StartEvent
            Visibility: public

        Name: OnUpdate
            Descrption: Used to call all events that need to be updated on a scene.
            Type: UpdateEvent
            Visibility: public

        Name: OnDraw
            Descrption: Used to call all events that need to be dran on a scene.
            Type: DrawEvent
            Visibility: public

        Name: Started
            Description: Used to check if an object has been initialized.
            Type: bool
            Visibility: public

        Name: Parent
            Decription: Used to hold the parent of an object.
            Type: Actor
            Visibility: public

        Name: _children
            Description: Holds the children of an object.
            Type: List<Actor>
            Visibility: protected

        Name: _additions
            Description: Used for anytime there is an object added to a scene.
            Type: List<Actor>
            Visibility: private

        Name: _removals
            Description: Used for anytime there is an object removed to a scene.
            Type: List<Actor>
            Visibility: private

        Name: _localTransform
            Description: Used to track the trnsform of individual objects.
            Type: Matrix3
            Visibility: private

        Name: _globalTransform
            Description: Used to track the trnsform of objects and their parent.
            Type: Matrix3
            Visibility: private

        Name: GetChildren
            Descrption: Get the all of the children of an actor.
            Type: List<Actor>
            Visibility: public

        Name: GetM11
            Description: Gets m11 of the global transform, used to get the direction an object is facing.
            Type: float
            Visibility: public

        Name: GetM12
            Description: Gets m12 of the global transform, used to get the direction an object is facing.
            Type: float
            Visibility: public

        Name: X
            Description: Gets the X position of an object.
            Type: float
            Visibility: public

        Name: XAbsolute
            Description: Gets the X absolute position of an object.
            Type: float
            Visibility: public


        Name: Y
            Description: Gets the Y position of an object.
            Type: float
            Visibility: public

        Name: Y
            Description: Gets the Y absolute position of an object.
            Type: float
            Visibility: public

        Name: GetRotation
            Description: Gets the rotation of an object.
            Type: float
            Visibility: public

        Name: Rotate
            Description: Rotates an object by a given radian.
            Type: void
            Visibility: public
            Parameters: float radian

        Name: GetScale
            Description: Gets the scale of an object.
            Type: float
            Visibility: public

        Name: Scale
            Description: Scales an object.
            Type: void
            Visibility: public
            Parameters: float scale

        Name: AddChild
            Description: Adds a child to an object.
            Type: void
            Visibility: public
            Parameters: Actor child

        Name: AddChild
            Description: Removes a child to an object.
            Type: void
            Visibility: public
            Parameters: Actor child

        Name: UpdateTransform
            Description: Updatesthe transform of objects.
            Type: void
            Visibility: public

        Name: Start
            Description: Initializes objects that need it.
            Type: void
            Visibility: public

        Name: Update
            Description: Updates objects that need it.
            Type: void
            Visibility: public
            Parameters: float deltaTime

        Name: Draw
            Description: Draws objects that need it.
            Type: void
            Visibility: public

    **File**: Bullet.cs

    Description: Used for Bullets.

    **Attributes**:

        Name: _texture
            Description: Used for the texture of the bullet.
            Type: Sprite
            Visibility: private

        Name: _hitbox
            Description: Used for the hitbox of the bullet.
            Type: AABB
            Visibility: private

        Name: _origin
            Description: Used to keep track of the object that shot the bullet.
            Type: Entity
            Visibility: private

        Name: _damage
            Description: Used to say how much damage the bullet does.
            Type: int
            Visibility: private

        Name: ~Bullet
            Description: Bullet Deconstructor.

        Name: Move
            Description: Used to move the bullet.
            Type: Void
            Visibility: public
            Parameters: float deltaTime

        Name: Destroy
            Decription: Used to destroy a bullet.
            Type: void
            Visibility: public

        Name: CheckCollision
            Description: Used to check to see if the bullet collides with something.
            Type: void
            Visibility: public
            Parameters: float deltaTime

    **File**: Debris.cs

    Description: Used as a base class for 'space rocks' and satellites

    **Attributes**:

        Name: _hitbox
            Description: Used for the hoybox of the debris.
            Type: AABB
            Visibility: protected

        Name: _damage
            Description: Used to say how much damage a piece of debris would do if it collided with the player.
            Type: int
            Visibility: protected

        Name: Debris
            Decritption: Constructor for the Debris class.
            Visibility: public

        Name: Debris
            Description: Consrtuctor for the debris class.
            Visibility: public
            Parameters: float x, float y

        Name: DetectCollision
            Description: Used to check if debris collides with anything.
            Type: bool
            Visibility: public
            Parameters: AABB other

        Name: WrapScreen
            Description: Used to wrap debris around the screen.
            Type: void
            Visibility: public
            Parameters: void

    **File**: DebrisSpawner

    Description: Used to spawn debris onto the scene.

    **Attributes**:

        Name: random
            Description:Used to get random direction and speed of debris.
            Type: Random

        Name: _spawnerType
            Description: Used to track what kind of spawner it is.
            Type: Debris
            Visibility: private

        Name: _debrisSpawnTimer
            Description: Used to track how much time until the next piece of debris spawns.
            Type: Timer
            Visibility: private

        Name: _debrisSpawnRate
            Description: Used to track how long it'll take for a piece of debris to spawn.
            Type: float
            Visibility: private

        Name: _activationTimer
            Description: Used to control how long until a spawner becomes active.
            Type: Timer
            Visibility: private

        Name: _timeToActivate
            Decription: Used to control how long it takes for a spawner to become active.
            float: float
            Visibility: private

        Name _newSpawnerTimer
            Description: Used to control how much time is left until a new spawner spawns in.
            Type: Timer
            Visibility: private

        Name: _timerToSpawnNewSpawner
            Description: Used to control how long it takes for a spawner to spawn a new spawner.
            Type: float
            Visibility: private

        Name: _isActive
            Description: Used to say if the spawner is active.
            Type: bool
            Visibility: private

        Name: _canSpawnMore
            Description: Used to say if a spawner can spawn more spawners.
            Type: bool
            Visibility: private

        Name: DebrisSpawner
            Description: Constructor for the DebrisSpawner class.
            Visibility: public
            Parameters: float timeToActivate, Debris spawnerType, bool canSpawnMore

        Name: RandomRotate
            Description: Used to randomly rotate a spawner.
            Type: void
            Visibility: public
            Parameters: float deltaTime

        Name: Activate
            Description: Used to activate a spawner.
            Type: void
            Visibility: public
            Parameters: float deltaTime

        Name: CreateNewSpawner
            Description: Used to spawn new spawners.
            Type: void
            Visibility: public
            Parameters: float deltaTime

        Name: CreateDebris
            Description: Used to create a new piece of debris.
            Type: void
            Visibility: public
            Parameters: float deltaTime

    **File**: Entity

    Description: Used as a base class for anything that is going to be in the scene.

    **Attributes**:

        Name: _velocity
            Description: Used to control the velocity of an object.
            Type: Vector3
            Visibility: private

        Name: _acceleration
            Description: Used to control the acceleration of an object.
            Type: Vector3
            Visibility: private

        Name: XVelocity
            Description: Used to control the x velocity of an object.
            Type: float
            Visibility: public

        Name: XAcceleration
            Description: Used to control the x acceleration of an object.
            Type: float
            Visibility: public

        Name: YVelocity
            Description: Used to control the y velocity of an object.
            Type: float
            Visibility: public

        Name: YAcceleration
            Description: Used to control the y acceleration of an object.
            Type: float
            Visibility: public

        Name: Entity
            Description: Constructor for the Entity class.
            Visibility: public
            Parameters: float x, float y

        Name: override Update
            Description: Used to update an object.
            Visibility: public
            Parameters: float deltaTime

    **File**: Games.cs

    Description: Used for anything that has to do with the game.

    **Attributes**:

        Name: _root
            Description: Used to get the current scene.
            Type: Actor
            Visibilty: private

        Name: _next
            Description: Used to get the next scene.
            Type: Actor
            Visibility: private

        Name: _gameTimer
            Description: Used to keep track of the game passed in the game.
            Type: Timer
            Visibilty: private

        Name: Game
            Description: Constructor for the Game class
            Visibility: public
            Parameters: int width, int height, string title

        Name: Run
            Description: Used to run the game.
            Type: void
            Visibility: public

        Name: Root
            Description: Used to get and set the root.
            Type: Actor
            Visibility: public

    **File**: Gun.cs

    Description: Used for the ships gun.

    **Attributes**:

        Name: _bullet
            Description: Used for the ship's gun.
            Type: Bullet
            Visibility: private

        Name: _texture
            Description: Used for the gun's texture.
            Type: Sprite
            Visibility: private

        Name: _ammo
            Description: Used for the ship's gun's ammo.
            Type: int
            Visibility: private

        Name: _maxAmmo
            Description: Used for the ship's gun's max ammo.
            Type: int
            Visibility: private

        Name: _bulletLoadingTime
            Description: Used for the amount of time to load a bullet.
            Type: float
            Visibility: private

        Name: _addBulletTimer
            Description: Used to control the amount of time until adding a bullet.
            Type: Timer
            Visibility: private

        Name: Gun
            Description: Constructor for the Gun class.
            Visibility: public

        Name: TurnLeft
            Description: Used for turning the turret left.
            Type: void
            Visibility: public
            Parameters: float deltaTime

        Name: TurnRight
            Description: Used for turning the turret left.
            Type: void
            Visibility: public
            Parameters: float deltaTime

        Name: Shoot
            Description: Used for shooting the gun.
            Type: void
            Visibility: public
            Parameters: float deltaTime

        Name: AddBullet
            Description: Used for adding bullets to the gun.
            Type: void
            Visibility: public
            Parameters: float deltaTime

        Name: DrawAmmoCount
            Description: Used to draw ammo on screen.
            Type: void
            Visibility: public

    **File**: Input.cs

    Description: Used for player input.

    **Attributes**:

        Name: IsKeyPressed
            Description: Returns whether the key was pressed since the last frame.
            Type: bool
            Visibility: public static

        Name: IsKeyDown
            Description: Returns whether the key is currently down.
            Type: bool
            Visibility: public static

        Name: IsKeyReleased
            Description: Returns whether the key was release since the last frame.
            Type: bool
            Visibility: public static

        Name: IsKeyReleased
            Description: Returns whether the key is currently up.
            Type: bool
            Visibility: public static

    **File**: Matrix3.cs

    Description: Used for the matrix math.

    **Attributes**:

        Name: Matrix3
            Description: Constructor for the Matrix3 class.
            Visibility: public

        Name: Matrix3
            Description: Constructor for the Matrix3 class.
            Visibility: public
            Parameter: float m11, float m12, float m13, float m21, float m22, float m23, float m31, float m32, float m33

        Name: Matrix3
            Description: Constructor for the Matrix3 class.
            Visibility: public
            Parameter: Matrix3 other

        Name: Matrix3 operator
            Description: Used for matrix multiplication.
            Visibility: public
            Parameter: Matrix3 lhs, Matrix3 rhs

        Name: Vector3 operator
            Description: Used for multiplying a matrix by a vector.
            Visibility: public
            Parameter: Matrix3 lhs, Vector3 rhs

        Name: Vector3 operator
            Description: Used for multiplying a matrix by a vector.
            Visibility: public
            Parameter: Vector3 rhs, Matrix3 lhs

        Name: SetScaled
            Description: Used for setting the scale of the matrix.
            Type: void
            Visibility: public
            Parameter: Vector3 scale

        Name: Scaled
            Description: Used for setting the scale of the matrix.
            Type: void
            Visibility: public
            Parameter: float x, float y, float z

        Name: Scaled
            Description: Used for setting the scale of the matrix.
            Type: void
            Visibility: public
            Parameter: Vector3 scaleVector

        Name: RotateX
            Description: Used for rotating the matrix.
            Type: void
            Visibility: public
            Parameter: double radian

        Name: SetRotateX
            Description: Used for rotating matrix.
            Type: void
            Visibility: public
            Parameter: double radian

        Name: RotateY
            Description: Used rotating matrix.
            Type: void
            Visibility: public
            Parameter: double radian

        Name: SetRotateY
            Description: Used for rotating matrix.
            Type: void
            Visibility: public
            Parameter: double radian

        Name: RotateZ
            Description: Used rotating matrix.
            Type: void
            Visibility: public
            Parameter: double radian

        Name: SetRotateZ
            Description: Used for rotating matrix.
            Type: void
            Visibility: public
            Parameter: double radian

        Name: Set
            Description: Used for setting the matrix.
            Type: void
            Visibility: public
            Parameter: float m11, float m12, float m13, float m21, float m22, float m23, float m31, float m32, float m33

        Name: SetTranslation
            Description: Used for translating the matrix.
            Type: void
            Visibility: public
            Parameter: float x, float y, float z

    **File**: Satellite.cs

    Desription: Used for creating a satellite.

    **Attribute**:

        Name: random
            Description: Used for randomly moving and rotating the satellite.
            Type: Random

        Name: _texture
            Description: Used for the texture of the satellite.
            Type: Sprite
            Visibility: private

        Name: _bullet
            Description: Used for the satellite's bullets.
            Type: Bullet
            Visibility: private

        Name: _timeToShoot
            Description: Used to control how long it takes the satellite shoots.
            Type: float
            Visibility: private

        Name: _shootTimer
            Description: Used to control how long until the satellite shoots.
            Type: Timer
            Visibility: private

        Name: _spinRate
            Description: Used to control how fast the satellite spins.
            Type: float
            Visibility: private

        Name: Satellite
            Description: Constructor for the Satellite.
            Visibility: public

        Name: Satellite
            Description: Constructor for the Satellite.
            Visibility: public
            Parameters: float x, float y, float xVelocity, float yVelocity

        Name: DetectCollision
            Description: Used to test for collision.
            Type: override bool
            Visibility: public
            Parameters: AABB other

        Name: Spin
            Description: Used to spin the satellite.
            Type: void
            Visibility: public
            Parameters: float deltaTime

        Name: DetectCollision
            Description: Used to test for collision.
            Type: void
            Visibility: public
            Parameters: float deltaTime

        Name: Shoot
            Description: Used to test for collision.
            Type: void
            Visibility: public
            Parameters: float deltaTime

    **File**: Ship.cs

    Description: Used for the ship

    **Attributes**:

        Name: Score
            Description: Used to keep track of the players score.
            Type: int
            Visibility: public static

        Name: _texture
            Description: Used for the texture of the ship.
            Type: Sprite
            Visibility: private

        Name: _hitbox
            Description: Used for the hitbox of the ship.
            Type: AABB
            Visibility: private

        Name: _turret
            Description: Used for the gun of the ship.
            Type: Sprite
            Visibility: private

        Name: _scorePosition
            Description: Used for the position of the ship.
            Type: Vector3
            Visibility: private

        Name: Health
            Description: Used for the health ship.
            Type: int
            Visibility: private

        Name: _gameOver
            Description: Used for checking if game over.
            Type: bool
            Visibility: private

        Name: _timeToStart
            Description: Used to tell the player how long until the game starts.
            Type: float
            Visibility: private

        Name: _timerToStart
            Description: Used to tell the player how long until the game starts.
            Type: Timer
            Visibility: private

        Name: Ship
            Description: Constructor for the Ship class.
            Visibility: public
            Parameters: int x, int y

        Name: MoveForeward
            Description: Used to move the ship forward.
            Type: void
            Visibility: public
            Parameters: float deltaTime

        Name: MoveBackwards
            Description: Used to move the ship forward.
            Type: void
            Visibility: public
            Parameters: float deltaTime

        Name: SetAccelerationZero
            Description: Used to set ship acceleration to zero.
            Type: void
            Visibility: public

        Name: TurnLeft
            Description: Turns the ship to the left.
            Type: void
            Visibility: public
            Parameters: float deltaTime

        Name: TurnRight
            Description: Turns the ship to the right.
            Type: void
            Visibility: public
            Parameters: float deltaTime

        Name: DetectCollision
            Description: Checks collision.
            Type: bool
            Visibility: public
            Parameters: AABB other, int damage

        Name: HealthCheck
            Description: Checks the ships health to make sure it dies.
            Type: void
            Visibility: public
            Parameters: float deltaTime

        Name: DrawTimeToBegin
            Description: Draws the time to begin on the screen.
            Type: void
            Visibility: public

        Name: DrawHealth
            Description: Draws the player health on the screen.
            Type: void
            Visibility: public

        Name: DrawScore
            Description: Draws the player's score on the screen.
            Type: void
            Visibility: public

    **File**: Sprite.cs

    Description: Used for handling textures.

    **Attributes**:

        Name: _texture
            Description: Used for handling the texture.
            Type: Texture2D
            Visibility: private

        Name: _image
            Description: Used for handling the texture.
            Type: Image
            Visibility: private

        Name: Width
            Description: Used for gettig the width of the texture.
            Type: float
            Visibility: public

        Name: Height
            Description: Used for gettig the height of the texture.
            Type: float
            Visibility: public

        Name: Sprite
            Description: Constructor for the Sprite class.
            Visibility: public
            Parameters: string path

        Name: Draw
            Description: Used for drawing the texture.
            Type: void
            Visibility: public override

    **File**: Timer.cs

    Description: Used for timing.

    **Attributes**:

        Name: _stopWatch
            Description: Used for keeping track of the time.
            Type: Stopwatch
            Visibility: private

        Name: _currentTime
            Description: Used to calculate the time difference.
            Type: long
            Visibility: private

        Name: _previousTime
            Description: Used to calculate the time difference.
            Type: long
            Visibility: private

        Name: _deltaTime
            Description: Used to calculate the time difference.
            Type: float
            Visibility: private

        Name: Timer
            Description: Constructor for the Timer class.
            Visibility: public

        Name: Restart
            Description: Used to restart the timer.
            Type: void
            Visibility: public

        Name: Seconds
            Description: Used to get the seconds passed.
            Type: float
            Visibility: public

        Name: GetDeltaTime
            Description: Used to get the deltaTime.
            Type: float
            Visibility: public

    **File**: Vector3.cs

    Description: Used for vector math.

    **Attributes**:

        Name: x
            Description: Used for the x postion of the vector.
            Type: float
            Visibility: public

        Name: y
            Description: Used for the y postion of the vector.
            Type: float
            Visibility: public

        Name: z
            Description: Used for the z postion of the vector.
            Type: float
            Visibility: public

        Name: Vector3
            Description: Constructor for the Vector3 class.
            Visibility: public

        Name: Vector3
            Description: Constructor for the Vector3 class.
            Visibility: public
            Parameters: float x, float y, float z

        Name: Vector3
            Description: Constructor for the Vector3 class.
            Visibility: public

        Name: Vector3 operator
            Description: Used for vector subtraction.
            Visibility: public
            Parameters: Vecto3 vec1, Vector3 vec2

        Name: Vector3 operator
            Description: Used for vector addition.
            Visibility: public
            Parameters: Vecto3 vec1, Vector3 vec2

        Name: Vector3 operator
            Description: Used for vector multiplication.
            Visibility: public
            Parameters: Vecto3 vec1, float scaler

        Name: Vector3 operator
            Description: Used for vector multiplication.
            Visibility: public
            Parameters: float scaler, Vector3 vec1

        Name: Vector3 operator
            Description: Used for vector divisiontion.
            Visibility: public
            Parameters: Vecto3 vec1, float scaler

        Name: Vector3 operator
            Description: Used for vector division.
            Visibility: public
            Parameters: float scaler, Vector3 vec2

        Name: MagnitudeSqr
            Description: Gets Magnitude.
            Type: float
            Visibility: public

        Name: Magnitude
            Description: Gets Magnitude.
            Type: float
            Visibility: public

        Name: Distance
            Description: Gets distnace.
            Type: float
            Visibility: public
            Parameters: Vector3 other

        Name: Normalised
            Description: Gets normalised.
            Type: void
            Visibility: public

        Name: GetNormalised
            Description: Gets normalised.
            Type: Vector3
            Visibility: public

        Name: GetDotProduct
            Description: Gets dot product.
            Type: float
            Visibility: public
            Parameters: Vector3

        Name: CrossProduct
            Description: Gets cross product.
            Type: Vector3
            Visibility: public
            Parameters: Vector3

        Name: Angle
            Description: Gets the angle.
            Type: float
            Visibility: public
            Parameters: Vector3 other
