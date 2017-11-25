using System;
using System.ComponentModel;
using System.Linq;
using Xceed.Wpf.Toolkit.PropertyGrid.Attributes;

namespace LookAt.PropertyGrid
{
    public class TransformationNodeCollectionPropertyDescriptor : PropertyDescriptor
    {
        private readonly TransformationNodeCollection _owner;
        private readonly int _index;

        public TransformationNodeCollectionPropertyDescriptor(TransformationNodeCollection owner, int index)
            : base(owner[index].ToString(), null)
        {
            _owner = owner;
            _index = index;
        }

        public override AttributeCollection Attributes
        {
            get
            {
                var attributes = TypeDescriptor.GetAttributes(GetValue(null), false);
                if (!attributes.OfType<ExpandableObjectAttribute>().Any())
                {
                    // copy all the attributes plus an extra one (the
                    // ExpandableObjectAttribute)
                    // this ensures that even if the type of the object itself doesn't have the
                    // ExpandableObjectAttribute, it will still be expandable. 
                    var newAttributes = new Attribute[attributes.Count + 1];
                    attributes.CopyTo(newAttributes, newAttributes.Length - 1);
                    newAttributes[newAttributes.Length - 1] = new ExpandableObjectAttribute();

                    // overwrite the array
                    attributes = new AttributeCollection(newAttributes);
                }

                return attributes;
            }
        }

        public override bool CanResetValue(object component)
        {
            return false;
        }

        public override object GetValue(object component)
        {
            return Value;
        }

        private TransformationNode Value => _owner[_index];

        public override void ResetValue(object component)
        {
            throw new NotImplementedException();
        }

        public override void SetValue(object component, object value)
        {
            _owner[_index] = (TransformationNode)value;
        }

        public override bool ShouldSerializeValue(object component)
        {
            return false;
        }

        public override Type ComponentType
            => _owner.GetType();

        public override bool IsReadOnly
            => true;

        public override Type PropertyType
            => Value?.GetType();
    }
}