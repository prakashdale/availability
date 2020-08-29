namespace availability.infrastructure.mongo.documents
{
    internal sealed class ReservationDocument
    {
        public int TimeStamp { get; set; }
        public int Priority { get; set; }
    }
}