namespace MySweetHome.Domain.ValueObjects
{
    public class Address
    {
        private readonly string _providerIdentifier;
        
        public Address(string providerIdentifier)
        {
            _providerIdentifier = providerIdentifier;
        }
        
        public override string ToString() => $"{_providerIdentifier}";

    }
}