///////////////////////////////////////////////////////////
//  ARMValidationAdaptor.cs
//  Implementation of the Class ARMValidationAdaptor
//  Generated by Enterprise Architect
//  Created on:      29-Mar-2014 4:59:43 PM
///////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Reflection;
using ARM.Core.EventArguments;
using ARM.Core.Extensions;
using ARM.Core.Interfaces;
using Microsoft.Practices.ObjectBuilder2;
using NSubstitute.Core;

namespace ARM.Core.Validation
{
    public class ARMValidationAdaptor : IARMValidationAdaptor
    {
        private object _dataObject;
        private readonly Dictionary<string, PropertyInfo> _propertyInfos = new Dictionary<string, PropertyInfo>(); 
        private readonly Dictionary<string,string> _results = new Dictionary<string, string>(); 
        private readonly Dictionary<string,IARMValidationRule> _rules = new Dictionary<string, IARMValidationRule>();


        public void SetValidationObject(object obj, IList<IARMModelPropertyInfo> listPi)
        {
            _dataObject = obj;
            InitRules(listPi);
        }

        private void InitRules(IList<IARMModelPropertyInfo> list )
        {
            foreach (var armModelPropertyInfo in list)
            {
                IARMValidationRule rule =
                    ARMValidationRulesFactory.Instance.GetRule(armModelPropertyInfo.ValidationAttribute);
                _propertyInfos[armModelPropertyInfo.Property.Name] = armModelPropertyInfo.Property;
                _rules[armModelPropertyInfo.Property.Name] = rule;
            }
        }

        ///
        /// <param name="rule"></param>
        public void AddRule<T>(Expression<Func<T>> expression, IARMValidationRule rule)
        {
            string name = ARMReflectionExtensions.GetPropertyName(expression);
            if (!string.IsNullOrEmpty(name) && !_rules.ContainsKey(name))
            {
                _rules[name] = rule;
            }
        }

        ///
        /// <param name="propName"></param>
        public void Validate<T>(Expression<Func<T>> propName)
        {
            string name = ARMReflectionExtensions.GetPropertyName(propName);
            Validate(name);
        }

        public void Validate(string name)
        {
            var rule = _rules[name];
            var pi = _propertyInfos[name];
            if (_dataObject != null && rule != null && pi != null)
            {
                var val = pi.GetPropertyValue<object>(_dataObject);
                var result = rule.Evalute(val);
                if (!result.IsValid)
                {
                    _results[name] = string.Join(" -> ", result.GetErrors());
                    RaiseValidationCompleted(name,result);
                }
                else
                {
                    _results[name] = string.Empty;
                }
            }
            else
            {
                _results[name] = string.Empty;
            }
        }

        public void ValidateAll()
        {
        }

        public event EventHandler<ValidationEventArgs> ValidationCompleted;

        ///
        /// <param name="propName"></param>
        public string GetResult<T>(Expression<Func<T>> propName)
        {
            string name = ARMReflectionExtensions.GetPropertyName(propName);
            return GetResult(name);
        }

        public string GetResult(string name)
        {
            return _results[name];
        }

        public string GetResultForAll()
        {
            return string.Join(Environment.NewLine, _results.Values);
        }

        public string this[string columnName]
        {
            get { return GetResult(columnName); }
        }

        public string Error { get {return GetResultForAll();} }


        private void RaiseValidationCompleted(string name,IARMValidationResult result)
        {
            EventHandler<ValidationEventArgs> temp = ValidationCompleted;
            if (temp != null)
            {
                temp(this,new ValidationEventArgs(){Result = result,PropertyName = name});
            }
        }

    }//end ARMValidationAdaptor
}//end namespace Validation