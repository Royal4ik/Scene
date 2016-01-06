﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Scene2d.Commands
{
    public class AddFigureCommand : ICommand
    {
        private readonly string name;

        private readonly IFigure figure;

        public AddFigureCommand(string name, IFigure figure)
        {
            this.name = name;
            this.figure = figure;
        }

        public void Apply(Scene scene)
        {
            scene.AddFigure(this.name, this.figure);
        }
    }
}