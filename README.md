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
