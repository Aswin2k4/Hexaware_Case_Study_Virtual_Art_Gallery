namespace VirtualArtGallery.Exceptions
{
    // Custom Exception for Artwork Not Found
    public class ArtWorkNotFoundException : Exception
    {
        public ArtWorkNotFoundException(string message) : base(message)
        {
        }
    }

    // Custom Exception for User Not Found
    public class UserNotFoundException : Exception
    {
        public UserNotFoundException(string message) : base(message)
        {
        }
    }
}
