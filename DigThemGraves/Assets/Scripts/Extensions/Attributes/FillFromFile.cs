using System;

namespace DigThemGraves
{
    [AttributeUsage(AttributeTargets.Field, Inherited = false, AllowMultiple = true)]
    public sealed class FillFromFileAttribute : Attribute
    {
        private readonly string sourceFieldName;
        public FillFromFileAttribute(string sourceFieldName)
        {
            this.sourceFieldName = sourceFieldName;
        }

        public string SourceFieldName { get => sourceFieldName; }
    }
}