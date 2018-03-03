// touchable_editor component, to prevent treating the component as a text object

using UnityEditor;

[CustomEditor(typeof(Touchable))]
public class Touchable_Editor : Editor
{
	public override void OnInspectorGUI()
	{
		// do nothing
	}

}
