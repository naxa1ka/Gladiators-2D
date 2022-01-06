using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(Wave))]
public class WaveEditor : Editor
{
    public override void OnInspectorGUI()
    {
        serializedObject.Update();
        
        DrawAllWaves();

        if(EditorGUI.EndChangeCheck())
            serializedObject.ApplyModifiedProperties();

        EditorGUILayout.Space();
        DrawHelpBox();
    }

    private void DrawAllWaves()
    {
        GUILayout.BeginVertical("box");
        
        var subWaves = serializedObject.FindProperty("_subWaves");
        for (var index = 0; index < WaveSettings.WavesAmount; index++)
        {
            var subWave = subWaves.GetArrayElementAtIndex(index);
            DrawSubWave(subWave, index);
        }

        EditorGUILayout.EndHorizontal();
    }

    private static void DrawSubWave(SerializedProperty subWave, int waveIndex)
    {
        var enemiesInSubWave = subWave.FindPropertyRelative("_enemies");
        
        EditorGUILayout.PrefixLabel($"Wave {(waveIndex + 1)}");
        for (int j = 0; j < WaveSettings.WaveSize; j++)
        {
            GUILayout.BeginHorizontal();
            var subWaveElement = enemiesInSubWave.GetArrayElementAtIndex(j);
            
            SerializedProperty enemy = subWaveElement.FindPropertyRelative("Enemy");
            enemy.objectReferenceValue = EditorGUILayout.ObjectField("Enemy", enemy.objectReferenceValue, typeof(Enemy), false);
            EditorGUILayout.EndHorizontal();

            GUILayout.BeginHorizontal();
            SerializedProperty health = subWaveElement.FindPropertyRelative("Health");
            health.floatValue = EditorGUILayout.FloatField("Health", health.floatValue);

            SerializedProperty damage = subWaveElement.FindPropertyRelative("Damage");
            damage.floatValue = EditorGUILayout.FloatField("Damage", damage.floatValue);
            
            EditorGUILayout.EndHorizontal();
            
            EditorGUILayout.Space();
            EditorGUILayout.Space();
            EditorGUILayout.Space();
        }

        EditorGUILayout.Space();
    }

    private static void DrawHelpBox()
    {
        GUILayout.BeginHorizontal();
        
        EditorGUILayout.LabelField("Wave size", WaveSettings.WaveSize.ToString());
        EditorGUILayout.LabelField("Waves amount", WaveSettings.WavesAmount.ToString());
        
        EditorGUILayout.EndHorizontal();
        
        EditorGUILayout.HelpBox("Parameters you can change in class WaveSettings", MessageType.Info);
    }
}