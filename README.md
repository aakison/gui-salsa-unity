# gui-salsa-unity
User interface controls and components for Unity

## Installation
This repo is designed to be used as a submodule of an existing Unity3D repo.  E.g.

```
    git submodule add https://github.com/aakison/gui-salsa-unity.git Assets/Modules/GuiSalsa
```

There are no demo scenes or resources in this repo, just the required files so that your solution is not polluted with unnecessary files.

## Feature: High DPI Scale Factor

Add this component to the root canvas (that has the Canvas Scalar component), it will detect the screen resolution and size and switch scale factor between 1x, 2x, and 3x.

## Feature: Dialog Control

Add this component to a UI object that is designed to hold a dialog box.  To use:
* Add the `DialogControl` to the root of the dialog (typically within Canvas)
* Set the transform (position, rotation and scale) to the shown position.
* Click on the context menu of the `DialogControl` in the inspector, then "Set Show Transform"
* Move the transform to the hidden location, typically offscreen.
* Click on the context menu of the `DialogControl` in the inspector, then "Set Hide Transform"
* In the button event of UI controls, call `Show()`, `Hide()` or `Toggle()` to trigger animation between states.
* Settings allow configuration animation and initial position.
