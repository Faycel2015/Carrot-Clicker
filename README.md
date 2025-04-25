# Carrot-Clicker

## Overview

Carrot-Clicker is a Unity-based game where players interact with a carrot object to fill it up and trigger frenzy modes. The game includes basic touch and mouse input controls, as well as smooth animations using LeanTween.

## Features

- **Interactive Carrot Object**: Click or touch the carrot to trigger an animation and start filling it up.
- **Frenzy Mode**: Once the carrot is fully filled, enter a frenzy mode with decreasing fill amount.
- **Animations**: The carrot has animated scale effects using LeanTween.
- **Touch Input Support**: Supports multi-touch functionality for mobile platforms.

## Requirements

- Unity 6 or later
- A supported platform (e.g., Windows, macOS, Android, iOS)

## Installation

1. Download or clone the repository.
2. Open Unity 6 and load the project.
3. Ensure all necessary assets (carrot images, audio, etc.) are placed in the correct folders.

## Setting Up the Game

### 1. Tagging the Carrot

Ensure the "Carrot" tag is properly defined in Unity:

1. Select any carrot GameObject in the **Hierarchy**.
2. In the **Inspector**, go to the **Tag** dropdown.
3. Click on **Add Tag** and create a new tag named `Carrot`.
4. Assign this tag to all carrot GameObjects.

### 2. Assign References

In the **Carrot** script:

- **Carrot Renderer**: Assign the `carrotRendererTransform` field to the GameObject that represents the carrot's visual representation.
- **Fill Image**: Assign the `fillImage` field to the UI Image component that represents the carrot’s fill.

### 3. Input Manager

The **InputManager** script listens for touch events or mouse input. Ensure that your project includes the necessary `Physics2D` colliders on GameObjects to detect the clicks.

## Game Mechanics

- When the player clicks/taps on the carrot, it animates and starts filling up.
- Once the carrot is filled, it enters **Frenzy Mode**, where the fill decreases over time.
- The game supports multiple touches on mobile devices.

## Controls

- **Mouse Input**: Left-click to interact with the carrot.
- **Touch Input**: Tap on the carrot in mobile versions.

## Development Setup

### Installing Dependencies

To use LeanTween for animations, you need to import the LeanTween package from the Unity Asset Store:

1. Go to **Window > Asset Store** in Unity.
2. Search for "LeanTween" and import the package into your project.

### Scripting

The core scripts for the game are:

- **Carrot.cs**: Manages the carrot animations and fill logic.
- **InputManager.cs**: Handles touch input or mouse clicks to trigger events.

### Editor Settings

Make sure to:

- Set up your **Camera** with the correct orthographic projection if you're using 2D elements.
- Add proper colliders to all interactive GameObjects to ensure raycast detection.

## Assets

- **Carrot** images for the carrot visual.
- **Fill image** for the UI representation of the fill amount.

## Troubleshooting

1. **Tag: Carrot is not defined**:
   - Ensure you have created and assigned the **Carrot** tag to all relevant GameObjects in the Unity Inspector.

2. **NullReferenceException**:
   - Verify that all references (like `fillImage`, `carrotRendererTransform`) are assigned correctly in the Unity Inspector.

## Contributing

If you want to contribute to this project, feel free to fork it and create a pull request. Bug reports and feature requests are welcome!

## License

This project is open-source. You can freely use it for personal or educational purposes.
