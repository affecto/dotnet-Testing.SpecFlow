using System;
using FluentAssertions;
using TechTalk.SpecFlow;

namespace Affecto.Testing.SpecFlow
{
    public abstract class ThreadSafeStepBase
    {
        private const string SpecFlowTestException = "SpecFlowTestException";

        protected readonly FeatureContext featureContext;
        protected readonly ScenarioContext scenarioContext;

        protected ThreadSafeStepBase(FeatureContext featureContext, ScenarioContext scenarioContext)
        {
            this.featureContext = featureContext ?? throw new ArgumentNullException(nameof(featureContext));
            this.scenarioContext = scenarioContext ?? throw new ArgumentNullException(nameof(scenarioContext));
        }

        protected void Try(Action action)
        {
            try
            {
                action.Invoke();
            }
            catch (Exception e)
            {
                scenarioContext.Add(SpecFlowTestException, e);
            }
        }

        protected void AssertCaughtException<TException>() where TException : Exception
        {
            scenarioContext[SpecFlowTestException].Should().BeOfType<TException>();
            scenarioContext.Remove(SpecFlowTestException);
        }

        protected T GetScenarioDependency<T>(string key)
        {
            if (scenarioContext.ContainsKey(key))
            {
                return (T) scenarioContext[key];
            }

            return default(T);
        }

        protected void SetScenarioDependency<T>(string key, T value)
        {
            scenarioContext[key] = value;
        }

        protected T GetFeatureDependency<T>(string key)
        {
            if (featureContext.ContainsKey(key))
            {
                return (T) featureContext[key];
            }

            return default(T);
        }

        protected void SetFeatureDependency<T>(string key, T value)
        {
            featureContext[key] = value;
        }
    }
}