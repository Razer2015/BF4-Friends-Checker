using System;

[AttributeUsage(AttributeTargets.Property, Inherited = false)]
public class NoCalculation : Attribute
{
}

[AttributeUsage(AttributeTargets.Class, Inherited = false)]
public class PluginSettings : Attribute
{
}

[AttributeUsage(AttributeTargets.Class, Inherited = false)]
public class Plugin : Attribute
{
}