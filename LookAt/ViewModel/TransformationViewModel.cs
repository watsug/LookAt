using System;
using System.Linq;
using System.ComponentModel;
using System.Collections.ObjectModel;
using LookAt.Model;
using Xceed.Wpf.Toolkit.PropertyGrid.Attributes;

namespace LookAt.ViewModel
{
    public class TransformationViewModel : INotifyPropertyChanged
    {
        #region Data

        readonly ReadOnlyCollection<TransformationViewModel> _children;
        readonly TransformationViewModel _parent;
        readonly Transformation _transformation;

        bool _isExpanded;
        bool _isSelected;

        #endregion // Data

        #region Constructors
        public TransformationViewModel(Transformation person)
            : this(person, null)
        {
        }

        private TransformationViewModel(Transformation person, TransformationViewModel parent)
        {
            _transformation = person;
            _parent = parent;

            _children = new ReadOnlyCollection<TransformationViewModel>(
                (from child in _transformation.Children
                    select new TransformationViewModel(child, this))
                .ToList<TransformationViewModel>());
        }
        #endregion

        #region Transformation Properties

        public ReadOnlyCollection<TransformationViewModel> Children => _children;
        public string Name => _transformation.Name;
        public string Path => _transformation.Path;

        [ExpandableObject]
        public object Value => _transformation.Value;
        #endregion // Transformation Properties

        #region Presentation Members
        #region IsExpanded

        /// <summary>
        /// Gets/sets whether the TreeViewItem 
        /// associated with this object is expanded.
        /// </summary>
        public bool IsExpanded
        {
            get => _isExpanded;
            set
            {
                if (value != _isExpanded)
                {
                    _isExpanded = value;
                    this.OnPropertyChanged("IsExpanded");
                }

                // Expand all the way up to the root.
                if (_isExpanded && _parent != null)
                    _parent.IsExpanded = true;
            }
        }

        #endregion // IsExpanded

        #region IsSelected
        /// <summary>
        /// Gets/sets whether the TreeViewItem 
        /// associated with this object is selected.
        /// </summary>
        public bool IsSelected
        {
            get => _isSelected;
            set
            {
                if (value == _isSelected) return;
                _isSelected = value;
                this.OnPropertyChanged("IsSelected");
            }
        }
        #endregion // IsSelected

        #region NameContainsText
        public bool NameContainsText(string text)
        {
            if (String.IsNullOrEmpty(text) || String.IsNullOrEmpty(this.Name))
                return false;

            return this.Name.IndexOf(text, StringComparison.InvariantCultureIgnoreCase) > -1;
        }
        #endregion // NameContainsText

        #region Parent
        public TransformationViewModel Parent
        {
            get { return _parent; }
        }

        #endregion // Parent
        #endregion // Presentation Members        

        #region INotifyPropertyChanged Members
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion // INotifyPropertyChanged Members
    }
}