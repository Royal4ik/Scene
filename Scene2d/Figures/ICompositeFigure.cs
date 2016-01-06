namespace Scene2d.Figures
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Security.Cryptography.X509Certificates;
    using System.Text;

    public interface ICompositeFigure : IFigure
    {
        IList<IFigure> ChildFigures { get; }
    }
}
