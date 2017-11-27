using System;
using System.Windows.Input;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using LookAt.Model;
using LookAtApi.Interfaces;
using LookAtApi.VisibleObjects;
using LookAtCore;

namespace LookAt.ViewModel
{
    public class LookUpViewModel : INotifyPropertyChanged
    {
        #region Data
        private ReadOnlyCollection<TransformationViewModel> _firstGeneration;
        private TransformationViewModel _root;
        private string _selected;
        readonly ICommand _searchCommand;
        private IEnumerable<IPlugin> _plugins;

        IEnumerator<TransformationViewModel> _matchingTransformationEnumerator;
        string _searchText = String.Empty;
        #endregion // Data

        #region Constructor
        public LookUpViewModel(Transformation rootTransformation)
        {
            try
            {
                _plugins = LookAtUtil.LoadPlugins();
            }
            catch (Exception)
            {
                // TODO: add warning here
            }
            _root = new TransformationViewModel(rootTransformation);
            _firstGeneration = new ReadOnlyCollection<TransformationViewModel>(
                new TransformationViewModel[]
                {
                    _root
                });

            _searchCommand = new SearchTransformationTreeCommand(this);
        }
        #endregion // Constructor

        #region Rebuild ViewModel
        public void Rebuild(Transformation rootPerson)
        {
        }
        #endregion

        #region Properties

        #region FirstGeneration
        /// <summary>
        /// Returns a read-only collection containing the first transformation 
        /// in the tree, to which the TreeView can bind.
        /// </summary>
        public ReadOnlyCollection<TransformationViewModel> FirstGeneration => _firstGeneration;
        #endregion // FirstGeneration

        #region SelectedText

        /// <summary>
        /// Returns a read-only collection containing the first transformation 
        /// in the tree, to which the TreeView can bind.
        /// </summary>
        public string SelectedText
        {
            get => _selected;
            set
            {
                _selected = value;
                if (!string.IsNullOrEmpty(_selected))
                {
                    IVisibleObject root = new StringVisibleObject(_selected);
                    IEnumerable<IVisibleObject> results = LookAtUtil.DoSearch(_plugins, root, 5);
                    _root = new TransformationViewModel(new Transformation(results, root));
                    _firstGeneration = new ReadOnlyCollection<TransformationViewModel>(
                        new TransformationViewModel[]
                        {
                            _root
                        });
                    this.OnPropertyChanged("FirstGeneration");
                }
            }
        }
        #endregion // FirstGeneration

        #region SearchCommand
        /// <summary>
        /// Returns the command used to execute a search in the family tree.
        /// </summary>
        public ICommand SearchCommand => _searchCommand;

        private class SearchTransformationTreeCommand : ICommand
        {
            readonly LookUpViewModel _lookupTree;

            public SearchTransformationTreeCommand(LookUpViewModel lookupTree)
            {
                _lookupTree = lookupTree;
            }

            public bool CanExecute(object parameter)
            {
                return true;
            }

            event EventHandler ICommand.CanExecuteChanged
            {
                // I intentionally left these empty because
                // this command never raises the event, and
                // not using the WeakEvent pattern here can
                // cause memory leaks.  WeakEvent pattern is
                // not simple to implement, so why bother.
                add { }
                remove { }
            }

            public void Execute(object parameter)
            {
                _lookupTree.PerformSearch();
            }
        }

        #endregion // SearchCommand

        #region SearchText
        /// <summary>
        /// Gets/sets a fragment of the name to search for.
        /// </summary>
        public string SearchText
        {
            get { return _searchText; }
            set
            {
                if (value == _searchText)
                    return;

                _searchText = value;
                _matchingTransformationEnumerator = null;
            }
        }
        #endregion // SearchText

        #endregion // Properties

        #region Search Logic
        void PerformSearch()
        {
            if (_matchingTransformationEnumerator == null || !_matchingTransformationEnumerator.MoveNext())
                this.VerifyMatchingPeopleEnumerator();

            var person = _matchingTransformationEnumerator.Current;

            if (person == null)
                return;

            // Ensure that this person is in view.
            if (person.Parent != null)
                person.Parent.IsExpanded = true;

            person.IsSelected = true;
        }

        void VerifyMatchingPeopleEnumerator()
        {
            var matches = this.FindMatches(_searchText, _root);
            _matchingTransformationEnumerator = matches.GetEnumerator();

            if (!_matchingTransformationEnumerator.MoveNext())
            {
                //MessageBox.Show(
                //    "No matching names were found.",
                //    "Try Again",
                //    MessageBoxButton.OK,
                //    MessageBoxImage.Information
                //    );
            }
        }

        IEnumerable<TransformationViewModel> FindMatches(string searchText, TransformationViewModel person)
        {
            if (person.NameContainsText(searchText))
                yield return person;

            foreach (TransformationViewModel child in person.Children)
                foreach (TransformationViewModel match in this.FindMatches(searchText, child))
                    yield return match;
        }
        #endregion // Search Logic

        #region INotifyPropertyChanged Members
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion // INotifyPropertyChanged Members
    }
}