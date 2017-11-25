﻿using System;
using System.ComponentModel;
using LookAtApi.Interfaces;
using Xceed.Wpf.Toolkit.PropertyGrid.Attributes;

namespace LookAt.PropertyGrid
{
    [ExpandableObject]
    public class TransformationNode : ICustomTypeDescriptor
    {
        private IVisibleObject _vo;
        private TransformationNodeCollection _children;

        public TransformationNode(IVisibleObject vo)
        {
            _vo = vo;
        }
        [ExpandableObject]
        public object Value => _vo.Value;

        [ExpandableObject]
        public TransformationNodeCollection Children => _children;


        public override string ToString()
        {
            return _vo.Transformation.Name;
        }

        #region ICustomTypeDescriptor
        public AttributeCollection GetAttributes()
        {
            return TypeDescriptor.GetAttributes(this, true);
        }

        public string GetClassName()
        {
            return TypeDescriptor.GetClassName(this, true);
        }

        public string GetComponentName()
        {
            return TypeDescriptor.GetComponentName(this, true);
        }

        public TypeConverter GetConverter()
        {
            return TypeDescriptor.GetConverter(this, true);
        }

        public EventDescriptor GetDefaultEvent()
        {
            return TypeDescriptor.GetDefaultEvent(this, true);
        }

        public PropertyDescriptor GetDefaultProperty()
        {
            return TypeDescriptor.GetDefaultProperty(this, true);
        }

        public object GetEditor(Type editorBaseType)
        {
            return TypeDescriptor.GetEditor(this, editorBaseType, true);
        }

        public EventDescriptorCollection GetEvents()
        {
            return TypeDescriptor.GetEvents(this, true);
        }

        public EventDescriptorCollection GetEvents(Attribute[] attributes)
        {
            return TypeDescriptor.GetEvents(this, attributes, true);
        }

        public PropertyDescriptorCollection GetProperties()
        {
            return TypeDescriptor.GetProperties(this, true);
        }

        public PropertyDescriptorCollection GetProperties(Attribute[] attributes)
        {
            return TypeDescriptor.GetProperties(this, attributes, true);
        }

        public object GetPropertyOwner(PropertyDescriptor pd)
        {
            return this;
        }
        #endregion
    }
}