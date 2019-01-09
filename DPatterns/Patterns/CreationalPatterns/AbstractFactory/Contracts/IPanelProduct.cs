using DPatterns.Patterns.CreationalPatterns.AbstractFactory.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace DPatterns.Patterns.CreationalPatterns.AbstractFactory
{
    public interface IPanelProduct: IProduct
    {
        string Name { get; set; }
    }
}
