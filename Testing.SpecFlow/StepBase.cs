using System;
using FluentAssertions;
using TechTalk.SpecFlow;

namespace Affecto.Testing.SpecFlow
{
    public abstract class StepBase
    {
        private const string SpecFlowTestException = "SpecFlowTestException";

        protected static void Try(Action action)
        {
            try
            {
                action.Invoke();
            }
            catch (Exception e)
            {
                ScenarioContext.Current.Add(SpecFlowTestException, e);
            }
        }

        protected static void AssertCaughtException<TException>() where TException : Exception
        {
            ScenarioContext.Current[SpecFlowTestException].Should().BeOfType<TException>();
            ScenarioContext.Current.Remove(SpecFlowTestException);
        }

        protected static T GetScenarioDependency<T>(string key)
        {
            if (ScenarioContext.Current.ContainsKey(key))
            {
                return (T) ScenarioContext.Current[key];
            }

            return default(T);
        }

        protected static void SetScenarioDependency<T>(string key, T value)
        {
            ScenarioContext.Current[key] = value;
        }

        protected static T GetFeatureDependency<T>(string key)
        {
            if (FeatureContext.Current.ContainsKey(key))
            {
                return (T) FeatureContext.Current[key];
            }

            return default(T);
        }

        protected static void SetFeatureDependency<T>(string key, T value)
        {
            FeatureContext.Current[key] = value;
        }
    }
}