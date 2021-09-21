using UnityEngine;
public class TestComponent : MonoBehaviour
{
	public enum ComponentType { First = 1, Second = 2 };
	public ComponentType component;
	public string componentName;
	public int variableComponentFirst;
	public int variableComponentSecond;
}