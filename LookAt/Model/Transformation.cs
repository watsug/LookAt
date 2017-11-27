using System.Linq;
using System.Collections.Generic;
using LookAtApi.Interfaces;

namespace LookAt.Model
{
    public class Transformation
    {
        private readonly IVisibleObject _vo;

        public Transformation(IVisibleObject vo)
        {
            _vo = vo;
            Children = new TransformationCollection();
        }

        public Transformation(IEnumerable<IVisibleObject> results, IVisibleObject root) : this(root)
        {
            BuildTree(results, root);
        }

        public string Name => _vo.Transformation == null ? "Root" : _vo.Transformation.Name;
        public object Value => _vo.Value;
        public TransformationCollection Children { get; }

        #region public API
        public void AddChild(Transformation node)
        {
            Children.Add(node);
        }

        public bool IsParent(IVisibleObject obj)
        {
            return _vo.Parent == obj;
        }

        public bool IsChild(IVisibleObject obj)
        {
            return _vo == obj.Parent;
        }
        #endregion

        #region private
        private void BuildTree(IEnumerable<IVisibleObject> results, IVisibleObject root)
        {
            IEnumerable<IVisibleObject> roots = results.Where(v => v.Parent == root);
            foreach (var r in roots)
            {
                Transformation node = new Transformation(r);
                Children.Add(node);

                BuildSubTree(results, node);
            }
        }

        private void BuildSubTree(IEnumerable<IVisibleObject> results, Transformation node)
        {
            IEnumerable<IVisibleObject> children = results.Where(node.IsChild);
            foreach (var c in children)
            {
                Transformation child = new Transformation(c);
                node.AddChild(child);

                BuildSubTree(results, child);
            }
        }
        #endregion
    }
}