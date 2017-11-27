using System;
using System.Text;
using LookAtApi.Interfaces;
using LookAtApi.VisibleObjects;

namespace CoreTransformations.Filters
{
    public abstract class FilterBase : ITransformation
    {
        protected abstract string Characters { get; }

        #region ITransformation
        public abstract string Name { get; }

        public IVisibleObject DoTransformation(IVisibleObject obj)
        {
            try
            {
                if (obj.Value is string tmp)
                {
                    StringBuilder sb = new StringBuilder();
                    int counter = 0;
                    foreach (var c in tmp)
                    {
                        if (Characters.IndexOf(c) < 0)
                        {
                            counter++;
                            continue;
                        }
                        sb.Append(c);
                    }
                    if (counter > 0)
                    {
                        // only if some some characters were filtered out
                        string result = sb.ToString();
                        if (!string.IsNullOrEmpty(result))
                        {
                            return new StringVisibleObject(sb.ToString(), obj, this);
                        }
                    }
                }
            }
            catch (Exception)
            {
                // INFO: intentionally left blank
            }
            return null;
        }
        #endregion
    }

}