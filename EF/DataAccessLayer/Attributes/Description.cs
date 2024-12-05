using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF.DataAccessLayer.Attributes
{
    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Class | AttributeTargets.Property, AllowMultiple = false)]
    internal class DescriptionAttribute : Attribute
    {
        private string? _description;
        public DescriptionAttribute(string description)
        {
            Description = description;
        }

        public string Description { get => _description!; set => _description = value; }
    }
}
