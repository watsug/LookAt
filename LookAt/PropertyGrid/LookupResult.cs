using System.Linq;
using System.ComponentModel;
using System.Collections.Generic;
using Xceed.Wpf.Toolkit.PropertyGrid.Attributes;
using LookAtApi.Interfaces;

namespace LookAt.PropertyGrid
{
    [ExpandableObject]
    public class LookupResult
    {
        private readonly string _str;
        private readonly TransformationNodeCollection _results;

        public LookupResult(string str, IEnumerable<IVisibleObject> results, IVisibleObject root)
        {
            _str = str;
            _results = new TransformationNodeCollection();
            BuildTree(results, root);
        }

        [DisplayName("Input")]
        [Description("The string value given as an input to transformation engine")]
        public string Input => _str;

        [ExpandableObject]
        [DisplayName("Transformation Results")]
        [Description("The outcome from transformation engine")]
        public TransformationNodeCollection Results => _results;


        private void BuildTree(IEnumerable<IVisibleObject> results, IVisibleObject root)
        {
            IEnumerable<IVisibleObject> roots = results.Where(v => v.Parent == root);
            foreach (var r in roots)
            {
                TransformationNode node = new TransformationNode(r);
                _results.Add(node);

                BuildSubTree(results, node);
            }
        }

        private void BuildSubTree(IEnumerable<IVisibleObject> results, TransformationNode node)
        {
            IEnumerable<IVisibleObject> children = results.Where(node.IsChild);
            foreach (var c in children)
            {
                TransformationNode child = new TransformationNode(c);
                node.AddChild(child);

                BuildSubTree(results, child);
            }
        }
    }
}