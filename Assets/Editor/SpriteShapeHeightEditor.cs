using UnityEngine;
using UnityEditor;
using UnityEngine.UIElements;
using UnityEditor.UIElements;

public class SpriteShapeHeightEditor : EditorWindow
{
    FloatField floatField;

    [MenuItem("Custom/Edit Sprite Shape Height")]
    public static void ShowWindow()
    {
        SpriteShapeHeightEditor window = GetWindow<SpriteShapeHeightEditor>();
        window.titleContent = new GUIContent("Edit Sprite Shape Height");
    }

    public void CreateGUI()
    {
        rootVisualElement.Add(new Button(EditHeights) { text = "Change Height" });
        floatField = new FloatField("Height");
        floatField.value = 1f;
        rootVisualElement.Add(floatField);
        floatField.RegisterCallback<ChangeEvent<float>>(evt => { floatField.value = Mathf.Clamp(evt.newValue, 0.1f, 4f); });
    }

    void EditHeights()
    {
        if (!Selection.activeGameObject.TryGetComponent<UnityEngine.U2D.SpriteShapeController>(out UnityEngine.U2D.SpriteShapeController spriteShape)) return;
        Tools.current = Tool.View; // fudge, if in edit spline mode the changes dont seem to apply
        Undo.RecordObject(spriteShape, $"Set Sprite Shape Height to {floatField.value}");
        for (int i = 0; i < spriteShape.spline.GetPointCount(); i++) spriteShape.spline.SetHeight(i, floatField.value);
        EditorUtility.SetDirty(spriteShape);
    }
}