using System;

namespace VirtualArtGallery.Model
{
    internal class Gallery
    {
        private int _galleryID;
        private string _name;
        private string _description;
        private string _location;
        private int _curatorID;  // ArtistID as curator
        private string _openingHours;
        private int _visitorCount;
        private string _galleryType;

        public int GalleryID
        {
            get { return _galleryID; }
            set { _galleryID = value; }
        }

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public string Description
        {
            get { return _description; }
            set { _description = value; }
        }

        public string Location
        {
            get { return _location; }
            set { _location = value; }
        }

        public int CuratorID
        {
            get { return _curatorID; }
            set { _curatorID = value; }
        }

        public string OpeningHours
        {
            get { return _openingHours; }
            set { _openingHours = value; }
        }

        public int VisitorCount
        {
            get { return _visitorCount; }
            set { _visitorCount = value; }
        }

        public string GalleryType
        {
            get { return _galleryType; }
            set { _galleryType  = value; }
        }

        public override string ToString()
        {
            return $"Gallery ID: {GalleryID}\t" +
                   $"Name: {Name}\t" +
                   $"Location: {Location}\t" +
                   $"Curator ID: {CuratorID}\t" +
                   $"Opening Hours: {OpeningHours} +" +
                   $"Visitor Count: {VisitorCount}\n";
        }
    }
}
