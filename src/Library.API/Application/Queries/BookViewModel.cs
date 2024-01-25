using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace Library.API.Application.Queries
{
    [DataContract]
    public class BookDTO
    {
        [DataMember]
        [Required]
        public int Id { get; set; }

#pragma warning disable CS8618
        [DataMember]
        [Required]
        public string ISBN { get; set; }

        [DataMember]
        [Required]
        public string Name { get; set; }

        [DataMember]
        [Required]
        public string Genre { get; set; }

        [DataMember]
        [Required]
        public string Description { get; set; }

        [DataMember]
        [Required]
        public string Author { get; set; }

        [DataMember]
        [Required]
        public DateTime BorrowingTime { get; set; }

        [DataMember]
        [Required]
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
