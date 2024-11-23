using System;

namespace VirtualArtGallery.Model
{
    internal class Artwork
    {
        private int _artworkID;
        private string _title;
        private string _description;
        private DateTime _creationDate;
        private string _medium;
        private string _imageURL;
        private int _artistID;

        public int ArtworkID
        {
            get { return _artworkID; }
            set { _artworkID = value; }
        }

        public string Title
        {
            get { return _title; }
            set { _title = value; }
        }

        public string Description
        {
            get { return _description; }
            set { _description = value; }
        }

        public DateTime CreationDate
        {
            get { return _creationDate; }
            set { _creationDate = value; }
        }

        public string Medium
        {
            get { return _medium; }
            set { _medium = value; }
        }

        public string ImageURL
        {
            get { return _imageURL; }
            set { _imageURL = value; }
        }

        public int ArtistID
        {
            get { return _artistID; }
            set { _artistID = value; }
        }

        public override string ToString()
        {
            return $"Artwork ID: {ArtworkID}\t" +
                   $"Title: {Title}\t" +
                   $"Artist ID: {ArtistID}\t" +
                   $"Medium: {Medium}\t" +
                   $"Image URL: {ImageURL}\t" +
                   $"Creation Date: {CreationDate.ToShortDateString()}\n";
        }
    }
}
