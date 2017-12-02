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

