using System.ComponentModel;
using System.Linq.Expressions;
using System.Collections.Generic;
using System;

namespace Snake.Helper.ViewModel
{
    public class BaseViewModel
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected bool SetProperty<T>(ref T fieldReference, T newValue, Expression<Func<T>> property)
        {
            bool valueIsDifferent = false;
            if (!object.Equals(fieldReference, newValue))
            {
                valueIsDifferent = true;
                fieldReference = newValue;

                var memberExpression = property.Body as MemberExpression;
                RaisePropertyChanged(memberExpression.Member.Name);
            }

            return valueIsDifferent;
        }

        protected void RaisePropertyChanged(string propertyName)
        {
            var handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}