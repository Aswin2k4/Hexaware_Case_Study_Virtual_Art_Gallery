namespace VirtualArtGallery.Model
{
    internal class UserFavoriteArtwork
    {
        private int _userID;
        private int _artworkID;
        private DateTime _dateAdded;
        private string _notes;

        public int UserID
        {
            get { return _userID; }
            set { _userID = value; }
        }

        public int ArtworkID
        {
            get { return _artworkID; }
            set { _artworkID = value; }
        }

        public DateTime DateAdded
        {
            get { return _dateAdded; }
            set { _dateAdded = value; }
        }


        public string Notes
        {
            get { return _notes; }
            set { _notes = value; }
        }

        public override string ToString()
        {
            return $"User ID: {UserID}\t" +
                   $"Artwork ID: {ArtworkID}\t" +
                   $"Date Added: {DateAdded}\t" +
                   $"Notes: {_notes}\n";
        }
    }
}
