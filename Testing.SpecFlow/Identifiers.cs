using System;
using System.Collections.Generic;
using System.Linq;

namespace Affecto.Testing.SpecFlow
{
    public class Identifiers
    {
        private readonly IDictionary<Guid, string> identifiedTexts;

        public Identifiers()
        {
            identifiedTexts = new Dictionary<Guid, string>();
        }

        public void Generate(string textWithId)
        {
            if (string.IsNullOrWhiteSpace(textWithId))
            {
                throw new ArgumentException("Empty text cannot be added.", nameof(textWithId));
            }
            if (IsTextAdded(textWithId))
            {
                throw new ArgumentException(string.Format("Text '{0}' already added.", textWithId), nameof(textWithId));
            }
            identifiedTexts.Add(Guid.NewGuid(), textWithId);
        }

        public Guid Get(string textWithId)
        {
            if (!IsTextAdded(textWithId))
            {
                throw new ArgumentException(string.Format("Text '{0}' not added.", textWithId), nameof(textWithId));
            }
            return identifiedTexts.Single(text => text.Value.Equals(textWithId)).Key;
        }

        private bool IsTextAdded(string textWithId)
        {
            return identifiedTexts.Any(text => text.Value.Equals(textWithId));
        }
    }
}
