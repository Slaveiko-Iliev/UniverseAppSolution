[AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
public class IncludeAttribute : Attribute
{
	public string NavigationProperty { get; }

	public IncludeAttribute(string navigationProperty)
	{
		NavigationProperty = navigationProperty;
	}
}
