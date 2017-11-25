using System;
using System.Collections.Generic;
using System.ComponentModel;
using LookAtApi.Interfaces;
using Xceed.Wpf.Toolkit.PropertyGrid.Attributes;

namespace LookAt.PropertyGrid
{
    [ExpandableObject]
    public class LookupResult
    {
        private string _str;
        private TransformationNodeCollection _results;

        public LookupResult(string str, IEnumerable<IVisibleObject> results)
        {
            _str = str;
            _results = new TransformationNodeCollection();
            foreach (var r in results)
            {
                _results.Add(new TransformationNode(r));
            }
        }

        [DisplayName("Input")]
        [Description("The string value given as an input to transformation engine")]
        public string Input => _str;

        [ExpandableObject]
        [DisplayName("Transformation Results")]
        [Description("The outcome from transformation engine")]
        public TransformationNodeCollection Results => _results;
    }
}