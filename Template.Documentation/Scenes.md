# Scenes

## Set
- [Bootstrap](/Template.Unity/Assets/_Project/Scenes/Bootstrap/) - game entry point and context(configs, reporting)
- [Meta](/Template.Unity/Assets/_Project/Scenes/Meta) - main menu
- [Game](/Template.Unity/Assets/_Project/Scenes/Game) - core gameplay
- [Empty](/Template.Unity/Assets/_Project/Scenes/Empty) - crutch scene for 100% unloading of all resources of the previous scene.

## Code 
### Initilization
- *Scene name* + Scope - for scene [RRR phase](https://blog.ploeh.dk/2010/09/29/TheRegisterResolveReleasepattern/), with using [VContainer](/Template.Documentation/Core/Plugins.md)
- *Scene name* - for scene initilization phase
- [Example](/Template.Unity/Assets/_Project/Develop/Template/Runtime/Core/Bootstrap)
### Classes
- [IScene](/Template.Unity/Assets/_Project/Develop/Template/Engine/Unity/Scenes/IScene.cs) - decorator for Unity scene asset
    - [UnityScene](/Template.Unity/Assets/_Project/Develop/Template/Engine/Unity/Scenes/UnityScene.cs) - Scene SO
    - [UnitySceneWithMemoryAllocate](/Template.Unity/Assets/_Project/Develop/Template/Engine/Unity/Scenes/UnitySceneWithMemoryAllocate.cs) - for 100% unloading of all resources of the previous scene. 


