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
using ARM.Core.Attributes;
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
                if(!armModelPropertyInfo.IsRequired && armModelPropertyInfo.ValidationAttribute == null)
                    continue;
                IARMValidationRule rule = null;

                if (armModelPropertyInfo.ValidationAttribute != null && !(armModelPropertyInfo.ValidationAttribute is ARMRequiredAttribute))
                {
                    rule = ARMValidationRulesFactory.Instance.GetRule(armModelPropertyInfo.ValidationAttribute);
                }
                else if(armModelPropertyInfo.IsRequired)
                {
                    if (armModelPropertyInfo.Property.PropertyType.IsValueType)
                    {
                        rule = ARMValidationRulesFactory.Instance.GetRuleForValuableType();
                    }
                    else
                    {
                        rule = ARMValidationRulesFactory.Instance.GetRuleForReferenceType();
                    }
                }
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
            if(!_rules.ContainsKey(name))
                return;
            
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
                    RaiseValidationCompleted(name, result);
                }
            }
            else
            {
                _results[name] = string.Empty;
                RaiseValidationCompleted(name, new ARMValidationResult(){IsValid = true});
            }
        }

        public void ValidateAll()
        {
            foreach (var armValidationRule in _rules)
            {
                var name = armValidationRule.Key;
                var rule = armValidationRule.Value;
                var pi = _propertyInfos[name];
                var val = pi.GetPropertyValue<object>(_dataObject);
                var result = rule.Evalute(val);
                if (!result.IsValid)
                {
                    _results[name] = string.Join(" -> ", result.GetErrors());
                }
                else
                {
                    _results[name] = string.Empty;
                }
            }
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
            return _results.ContainsKey(name ) ? _results[name] : string.Empty;
        }

        public Dictionary<string,string> GetResultForAll()
        {
            return _results;
        }

        public string this[string columnName]
        {
            get { return GetResult(columnName); }
        }

        public string Error { get {return string.Join(" - ", GetResultForAll().Values);} }


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