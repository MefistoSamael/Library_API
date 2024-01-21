using System.Runtime.Serialization;

namespace Library.API.Application.Queries
{
    [DataContract]
    public class BookDTO
    {
        [DataMember]
        public int Id { get; set; }

#pragma warning disable CS8618
        [DataMember]
        public string ISBN { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public string Genre { get; set; }

        [DataMember]
        public string Description { get; set; }

        [DataMember]
        public string Author { get; set; }

        [DataMember]
        public DateTime BorrowingTime { get; set; }

        [DataMember]
        public DateTime ReturningTime { get; set; }
#pragma warning restore CS8618

        public BookDTO()
        {

        }

        public BookDTO(string iSBN, string name, string genre, string description, string author, DateTime borrowingTime, DateTime returningTime, int id = 0)
        {
            Id = id;
            ISBN = iSBN;
            Name = name;
            Genre = genre;
            Description = description;
            Author = author;
            BorrowingTime = borrowingTime;
            ReturningTime = returningTime;
        }
    }
}
