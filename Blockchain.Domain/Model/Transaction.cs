namespace Blockchain.Domain.Model
{
    public class Transaction
    {
        public string? From { get; set; } // Отправитель (должен быть Hash)
        public string? To { get; set; }   // Получатель (должен быть Hash)
        public Payload? Payload { get; set; } // Полезная нагрузка
    }
}
