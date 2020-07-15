using System;
using UnityEditor;
using UnityEngine;

namespace Game.Config.Editor
{
    [CustomEditor(typeof(LevelConfig))]
    public class LevelEditorWindow : UnityEditor.Editor
    {
	    private GUIStyle _buttonStyle;
	    
        public override void OnInspectorGUI()
        {
	        _buttonStyle = new GUIStyle(GUI.skin.button) { alignment = TextAnchor.MiddleRight };
	        
            LevelConfig level = (LevelConfig) target;
            
            SerializedProperty interactionListProperty = serializedObject.FindProperty("LevelIndex");
            interactionListProperty.intValue = EditorGUILayout.IntField("Level: ", interactionListProperty.intValue);
            
            const float firstColumnWidth = 90f;
            float columnWidth = EditorGUIUtility.singleLineHeight;
            float columnSpacing = EditorGUIUtility.standardVerticalSpacing;

            const float firstRowHeight = 90f;
            float rowHeight = EditorGUIUtility.singleLineHeight;
            float rowSpacing = EditorGUIUtility.standardVerticalSpacing;
            
            DrawMatrix(firstColumnWidth, columnWidth, columnSpacing, firstRowHeight, rowHeight, rowSpacing);
            
            serializedObject.ApplyModifiedProperties();
        }

        private void DrawLevelMatrix(float firstColumnWidth, float columnWidth, float columnSpacing,
	        float firstRowHeight, float rowHeight, float rowSpacing)
        {
	        const int abilityTypeCount = 5;
	        const int max = 5;

	        var matrixSpaceRect = new Rect(5f,
		        18f,
		        firstColumnWidth + abilityTypeCount * (columnWidth + columnSpacing),
		        firstRowHeight + abilityTypeCount * (rowHeight + rowSpacing));
	        Rect theMatrixRect = GUILayoutUtility.GetRect(matrixSpaceRect.width, matrixSpaceRect.width,
		        matrixSpaceRect.height, matrixSpaceRect.height);

	        GUI.BeginClip(theMatrixRect);
	        {
		        var firstColumnRect = new Rect(0f, firstRowHeight, firstColumnWidth, matrixSpaceRect.height);
		        GUI.BeginClip(firstColumnRect);
		        {
			        var helperRect = new Rect(0f, 0f, firstColumnWidth, rowHeight);
			        
			        for (int row = 0; row < abilityTypeCount; row++)
			        {
				        var firstPivot = new Vector2(firstColumnWidth * .5f, -firstColumnWidth * .5f);
				        var secondPivot = new Vector2(firstColumnWidth + (row + .5f) * (columnWidth + columnSpacing),
					        0f);

				        GUIUtility.RotateAroundPivot(-90f, firstPivot);
				        GUIUtility.RotateAroundPivot(15f, secondPivot);
				        GUI.matrix = Matrix4x4.identity;

				        helperRect.y += rowHeight + rowSpacing;

				        
			        }
		        }
		        GUI.EndClip();

		        SerializedProperty interactionListProperty = serializedObject.FindProperty("_tiles");

		        var restOfMatrixRect = new Rect(firstColumnRect.x + firstColumnRect.width, firstColumnRect.y,
			        matrixSpaceRect.width - firstColumnRect.width, matrixSpaceRect.height);
		        GUI.BeginClip(restOfMatrixRect);
		        {
			        for (int row = 0; row < abilityTypeCount; row++)
			        {
				        var helperRect = new Rect(0f, row * (rowHeight + rowSpacing), columnWidth, rowHeight);

				        SerializedProperty interactions = interactionListProperty.GetArrayElementAtIndex(row)
					        .FindPropertyRelative("Tiles");

				        Color guiColor = GUI.color;
				        for (int column = 0; column < abilityTypeCount; column++)
				        {
					        SerializedProperty interactionElement = interactions.GetArrayElementAtIndex(column);

					        var interaction = (TileType) interactionElement.enumValueIndex;

					        GetLabelAndColor(interaction, out string label, out Color color);

					        GUI.color = color;
					        if (GUI.Button(helperRect, new GUIContent(label), _buttonStyle))
					        {
						        interactionElement.enumValueIndex =
							        (interactionElement.enumValueIndex + 1) % (int) TileType.Count;
					        }

					        helperRect.x += columnWidth + columnSpacing;
				        }

				        GUI.color = guiColor;
			        }
		        }
		        GUI.EndClip();
	        }
	        GUI.EndClip();
        }
        
        private static void GetLabelAndColor(TileType tileType, out string label, out Color color)
        {
	        switch(tileType)
	        {
		        case TileType.Close:
			        label = "b";
			        color = Color.black;
			        break;

		        case TileType.Open:
			        label = "o";
			        color = Color.green;
			        break;
		        
		        case TileType.Empty:
			        label = "e";
			        color = Color.grey;
			        color.a = 0.3f;
			        break;
		        
		        default:
			        label = "!";
			        color = Color.yellow;
			        break;
	        }
        }
        
        private void DrawMatrix(float firstColumnWidth, float columnWidth, float columnSpacing,
	        float firstRowHeight, float rowHeight, float rowSpacing)
        {
	        SerializedProperty rowsProperty = serializedObject.FindProperty("rows");
	        SerializedProperty columnsProperty = serializedObject.FindProperty("columns");
	        int rows = rowsProperty.intValue;
	        int columns = columnsProperty.intValue;
	        
		    
	        var matrixSpaceRect = new Rect(5f, 18f,
		        firstColumnWidth + columns * (columnWidth + columnSpacing),
		        firstRowHeight + rows * (rowHeight + rowSpacing));
	        
	        Rect theMatrixRect = GUILayoutUtility.GetRect(matrixSpaceRect.width, matrixSpaceRect.width,
		        matrixSpaceRect.height, matrixSpaceRect.height);

	        GUI.BeginClip(theMatrixRect);
	        {
		        var firstColumnRect = new Rect(0f, firstRowHeight, firstColumnWidth, matrixSpaceRect.height);
		        GUI.BeginClip(firstColumnRect);
		        {
			        var helperRect = new Rect(0f, 0f, firstColumnWidth, rowHeight);
			        
			        for (int row = 0; row < rows; row++)
			        {
				        var firstPivot = new Vector2(firstColumnWidth * .5f, -firstColumnWidth * .5f);
				        var secondPivot = new Vector2(firstColumnWidth + (row + .5f) * (columnWidth + columnSpacing),
					        0f);

				        GUIUtility.RotateAroundPivot(-90f, firstPivot);
				        GUIUtility.RotateAroundPivot(15f, secondPivot);
				        GUI.matrix = Matrix4x4.identity;

				        helperRect.y += rowHeight + rowSpacing;

				        
			        }
		        }
		        GUI.EndClip();

		        SerializedProperty interactionListProperty = serializedObject.FindProperty("_configs");
		        
		        SerializedProperty sp = interactionListProperty.Copy();
		        sp.Next(true);
		        sp.Next(true);
		        int length = sp.intValue;
		        
		        var restOfMatrixRect = new Rect(firstColumnRect.x + firstColumnRect.width, firstColumnRect.y,
			        matrixSpaceRect.width - firstColumnRect.width, matrixSpaceRect.height);
		        
		        GUI.BeginClip(restOfMatrixRect);
		        {

			        for (int i = 0; i < length; i++)
			        {
				        SerializedProperty interactionElement = interactionListProperty.GetArrayElementAtIndex(i);
				        
				        SerializedProperty tileTypeElement = interactionElement.FindPropertyRelative("TileType");
				        TileType tileType = (TileType) tileTypeElement.enumValueIndex;
				        
				        SerializedProperty xElement = interactionElement.FindPropertyRelative("X");
				        int dX = xElement.intValue;
				        
				        SerializedProperty yElement = interactionElement.FindPropertyRelative("Y");
				        int dY = yElement.intValue;
				        
				        var helperRect = new Rect(dX * (columnWidth + columnSpacing), dY * (rowHeight + rowSpacing), columnWidth, rowHeight);
				        
				        GetLabelAndColor(tileType, out string label, out Color color);

				        GUI.color = color;
				        if (GUI.Button(helperRect, new GUIContent(label), _buttonStyle))
				        {
					        tileTypeElement.enumValueIndex =
						        (tileTypeElement.enumValueIndex + 1) % (int) TileType.Count;
				        }
			        }
		        }
		        GUI.EndClip();
	        }
	        GUI.EndClip();
        }
    }
}