using MicroPack.Types;

namespace University.Students.Core.ValueObjects
{
    public class PersonName: ValueObject
    {
        public string First { get; }
        public string Last { get; }
        public string Full { get; }
        public string Reversed { get; }

        public PersonName(string first, string last)
        {
            First = first;
            Last = last;
            Full = First + " " + Last;
            Reversed = Last + " " + First;
        }

        public static PersonName CreateNew(string first, string last) 
        {
            if (string.IsNullOrEmpty(first) && string.IsNullOrEmpty(last))
            {
                // validate
            }
            return new PersonName(first, last);
        }
    }
}