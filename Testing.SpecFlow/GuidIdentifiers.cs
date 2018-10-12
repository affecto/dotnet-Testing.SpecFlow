using System;

namespace Affecto.Testing.SpecFlow
{
    public class GuidIdentifiers : Identifiers<Guid>
    {
        protected override Guid GenerateIdentifierForKey()
        {
            return Guid.NewGuid();
        }
    }
}