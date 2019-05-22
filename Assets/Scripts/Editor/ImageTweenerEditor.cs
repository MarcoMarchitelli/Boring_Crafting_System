using UnityEditor;

//[CustomEditor(typeof(ImageTweener))]
//[CanEditMultipleObjects]
public class ImageTweenerEditor : Editor
{
    bool color = false;
    bool rotation = false;
    bool rotationShake = false;

    SerializedProperty tweenOnAwake, tweenColor, gradient, colorSpeed, shakeRotation, shakeAngles, shakeSpeed,
                       shakeVibration, shakeElasticity, tweenScale, image, text;

    private void OnEnable()
    {
        tweenOnAwake = serializedObject.FindProperty("tweenOnAwake");
        tweenColor = serializedObject.FindProperty("tweenColor");
        gradient = serializedObject.FindProperty("gradient");
        colorSpeed = serializedObject.FindProperty("colorSpeed");
        shakeRotation = serializedObject.FindProperty("shakeRotation");
        shakeAngles = serializedObject.FindProperty("shakeAngles");
        shakeSpeed = serializedObject.FindProperty("shakeSpeed");
        shakeVibration = serializedObject.FindProperty("shakeVibration");
        shakeElasticity = serializedObject.FindProperty("shakeElasticity");
        tweenScale = serializedObject.FindProperty("tweenScale");
        image = serializedObject.FindProperty("image");
        text = serializedObject.FindProperty("text");
    }

    public override void OnInspectorGUI()
    {
        serializedObject.Update();

        EditorGUILayout.PropertyField(tweenOnAwake);
        EditorGUILayout.Space();

        tweenColor.boolValue = EditorGUILayout.ToggleLeft("Color", tweenColor.boolValue, EditorStyles.boldLabel);
        if (tweenColor.boolValue)
        {
            EditorGUI.indentLevel++;
            EditorGUILayout.PropertyField(gradient);
            EditorGUILayout.PropertyField(colorSpeed);
            EditorGUI.indentLevel--;
        }

        rotation = EditorGUILayout.ToggleLeft("Rotation", rotation, EditorStyles.boldLabel);
        if (rotation)
        {
            EditorGUI.indentLevel++;
            rotationShake = EditorGUILayout.ToggleLeft("Shake", rotationShake, EditorStyles.boldLabel);
            if (rotationShake)
            {
                EditorGUI.indentLevel++;
                EditorGUILayout.PropertyField(shakeAngles);
                EditorGUILayout.PropertyField(shakeSpeed);
                EditorGUILayout.PropertyField(shakeVibration);
                EditorGUILayout.PropertyField(shakeElasticity);
                EditorGUI.indentLevel--;
            }
            EditorGUI.indentLevel--;
        }

        EditorGUILayout.Space();
        EditorGUILayout.LabelField("Tween Targets", EditorStyles.boldLabel);
        EditorGUI.indentLevel++;
        EditorGUILayout.PropertyField(image);
        EditorGUILayout.PropertyField(text);
        EditorGUI.indentLevel--;

        serializedObject.ApplyModifiedProperties();
    }
}