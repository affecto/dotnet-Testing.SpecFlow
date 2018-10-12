using System;
using System.Collections.Generic;

namespace Affecto.Testing.SpecFlow
{
    public abstract class Identifiers<TIdentifier>
    {
        private readonly Dictionary<string, TIdentifier> identifiers = new Dictionary<string, TIdentifier>();

        public TIdentifier GenerateIdentifier(string key)
        {
            if (string.IsNullOrWhiteSpace(key))
            {
                throw new ArgumentException("Cannot create identifier with an empty key.", nameof(key));
            }

            if (HasIdentifier(key))
            {
                throw new ArgumentException($"Existing identifier found for key '{key}'.");
            }

            TIdentifier id = GenerateIdentifierForKey();
            identifiers[key] = id;
            return id;
        }

        public TIdentifier GetIdentifier(string key)
        {
            if (HasIdentifier(key))
            {
                return identifiers[key];
            }

            throw new ArgumentException($"No identifier found for key '{key}'.");
        }

        public bool HasIdentifier(string key)
        {
            return identifiers.ContainsKey(key);
        }

        protected abstract TIdentifier GenerateIdentifierForKey();
    }
}