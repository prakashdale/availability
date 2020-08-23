using System;
using System.Diagnostics.CodeAnalysis;

namespace availability.core.valueObjects{
    public struct Reservation: IEquatable<Reservation> {
        public DateTime From {get;}
        public DateTime To {get;}
        public int Priority {get;}
        public Reservation(DateTime from, DateTime to, int priority) 
        => (From, To, Priority) = ( from, to, priority);

        public bool Equals([AllowNull] Reservation other)
        {
            return this.From.Equals(other.From) && this.To.Equals(other.To) && this.Priority == other.Priority;
        }

        public override bool Equals([AllowNull]object obj) 
        => obj is Reservation reservation && Equals(reservation);

        public override int GetHashCode()
        => HashCode.Combine(From, To, Priority);
    }
}