namespace Scene2d.Exceptions
{
    using System;
    using System.Diagnostics.CodeAnalysis;

    public class BadRectanglePointException : Exception
    {
        [SuppressMessage("StyleCop.CSharp.NamingRules", "SA1305:FieldNamesMustNotUseHungarianNotation", Justification = "Reviewed. Suppression is OK here.")]
        public BadRectanglePointException(string aMessage)
                     : base(aMessage)
        {
        }
    }
}