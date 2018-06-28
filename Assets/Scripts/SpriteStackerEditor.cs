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
        EditorGUILayout.Separator();
        EditorGUILayout.LabelField("Rotation Settings");
        spriteStacker.RotationSpeed = EditorGUILayout.Slider("Speed", spriteStacker.RotationSpeed, -360, 360);
        spriteStacker.rotationStyle = (SpriteStacker.RotationStyle)EditorGUILayout.EnumPopup("Style", spriteStacker.rotationStyle);
        if (spriteStacker.rotationStyle == SpriteStacker.RotationStyle.Constant)
        {

        }
        if (spriteStacker.rotationStyle == SpriteStacker.RotationStyle.Targeted)
        {
            spriteStacker.RotationTarget = (GameObject)EditorGUILayout.ObjectField("Target", spriteStacker.RotationTarget, typeof(GameObject), true);
        }

        if (GUILayout.Button("GenerateStack"))
        {
            spriteStacker.StackGen();
        }
    }
}