using System;
using UnityEditor;
using UnityEngine;

public class Build_Player : MonoBehaviour
{
	public static void buildFile ()
		{
		BuildPlayerOptions buildPlayerOptions = new BuildPlayerOptions();
        buildPlayerOptions.scenes = new[] {"Assets/Challenge.unity"};
        buildPlayerOptions.locationPathName = "Datavisualize";
		buildPlayerOptions.target = BuildTarget.StandaloneOSX;
        buildPlayerOptions.options = BuildOptions.None;
        BuildPipeline.BuildPlayer(buildPlayerOptions);
    }
}