namespace Blockchain.Domain.Model
{
    public enum PayloadType
    {
        Document,
        Amount
    }
    public class Payload
    {
        public PayloadType Type { get; set; }
    }
}
