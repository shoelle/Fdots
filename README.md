# Fdots

This is an F# port of https://github.com/UnityTechnologies/DOTS_Pong

(Attempted port atm, not quite working completely.)

# Setup Notes
* Install Unity 2019.3.0f3
* Open the Unity project
* Open the code solution in VS -> Unity automatically regenerates the *sln on project open.
* You will need to re-add the "Flib" project to the solution to edit it in VS.
* Also, if you're changing the F#/C# API, make sure to build Flib first, or make the C# lib depend on it.
* (TODO - Is there a way to remove these pain points?)
* Build the project (making sure both Flib and Assembly-Csharp are built)
* Tab back to Unity and wait for the import (TODO - another pain point)


# Known Problems
Errors on running -

* Each system execution spams this:
```
Exception: This method should have been replaced by codegen
LambdaForEachDescriptionConstructionMethods.ThrowCodeGenException[TDescription] () (at Library/PackageCache/com.unity.entities@0.3.0-preview.4/Unity.Entities/CodeGeneratedJobForEach/LambdaJobDescription.cs:179)
LambdaForEachDescriptionConstructionMethods.ForEach[TDescription,T0] (TDescription description, Unity.Entities.UniversalDelegates.V`1[T0] codeToRun) (at Library/PackageCache/com.unity.entities@0.3.0-preview.4/Unity.Entities/CodeGeneratedJobForEach/UniversalDelegates.gen.cs:177)
Flib.PaddleMovementSystem+PaddleMovementSystem.OnUpdate (Unity.Jobs.JobHandle inputDeps) (at Flib/Systems/PaddleMovementSystem.fs:20)
Unity.Entities.JobComponentSystem.InternalUpdate () (at Library/PackageCache/com.unity.entities@0.3.0-preview.4/Unity.Entities/JobComponentSystem.cs:125)
Unity.Entities.ComponentSystemBase.Update () (at Library/PackageCache/com.unity.entities@0.3.0-preview.4/Unity.Entities/ComponentSystemBase.cs:301)
Unity.Entities.ComponentSystemGroup.OnUpdate () (at Library/PackageCache/com.unity.entities@0.3.0-preview.4/Unity.Entities/ComponentSystemGroup.cs:109)
UnityEngine.Debug:LogException(Exception)
Unity.Debug:LogException(Exception) (at Library/PackageCache/com.unity.entities@0.3.0-preview.4/Unity.Entities/Stubs/Unity/Debug.cs:19)
Unity.Entities.ComponentSystemGroup:OnUpdate() (at Library/PackageCache/com.unity.entities@0.3.0-preview.4/Unity.Entities/ComponentSystemGroup.cs:113)
Unity.Entities.ComponentSystem:InternalUpdate() (at Library/PackageCache/com.unity.entities@0.3.0-preview.4/Unity.Entities/ComponentSystem.cs:102)
Unity.Entities.ComponentSystemBase:Update() (at Library/PackageCache/com.unity.entities@0.3.0-preview.4/Unity.Entities/ComponentSystemBase.cs:301)
Unity.Entities.DummyDelegateWrapper:TriggerUpdate() (at Library/PackageCache/com.unity.entities@0.3.0-preview.4/Unity.Entities/ScriptBehaviourUpdateOrder.cs:152)
```
* `A Native Collection has not been disposed, resulting in a memory leak. Enable Full StackTraces to get more details.`

