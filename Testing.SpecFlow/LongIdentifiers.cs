namespace Affecto.Testing.SpecFlow
{
    public class LongIdentifiers : Identifiers<long>
    {
        private long counter = 1;

        protected override long GenerateIdentifierForKey()
        {
            return counter++;
        }
    }
}