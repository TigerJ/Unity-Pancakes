using UnityEngine;
using System.Collections;
using UnityEditor;

[CustomEditor(typeof(SpriteStacker))]
public class SpriteStackerEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();
        
        SpriteStacker spriteStacker = (SpriteStacker)target;
        if(GUILayout.Button("GenerateStack"))
        {
            spriteStacker.StackGen();
        }
    }
}