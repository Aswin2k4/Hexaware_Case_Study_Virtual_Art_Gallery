using System;

namespace VirtualArtGallery.Model
{
    internal class Artist
    {
        private int _artistID;
        private string _name;
        private string _biography;
        private DateTime _birthDate;
        private string _nationality;
        private string _website;
        private string _contactInfo;
        private int _totalArtWork;

        public int ArtistID
        {
            get { return _artistID; }
            set { _artistID = value; }
        }

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public string Biography
        {
            get { return _biography; }
            set { _biography = value; }
        }

        public DateTime BirthDate
        {
            get { return _birthDate; }
            set { _birthDate = value; }
        }

        public string Nationality
        {
            get { return _nationality; }
            set { _nationality = value; }
        }

        public string Website
        {
            get { return _website; }
            set { _website = value; }
        }

        public string ContactInfo
        {
            get { return _contactInfo; }
            set { _contactInfo = value; }
        }

        public int TotalArtworks
        {
            get { return _totalArtWork; }
            set { _totalArtWork = value; }
        }

        public int CalculateAge()
        {
            int age = DateTime.Now.Year - BirthDate.Year;
            Console.WriteLine($"The age of this artist is {age} years.");
            return age;
        }

        public override string ToString()
        {
            return $"Artist ID : {ArtistID}\t" +
                   $"Name : {Name}\t" +
                   $"Nationality : {Nationality}\t" +
                   $"Website : {Website}\t" +
                   $"Mail ID : {ContactInfo}\t" +
                   $"Age: {CalculateAge()}\n";
        }
    }
}
