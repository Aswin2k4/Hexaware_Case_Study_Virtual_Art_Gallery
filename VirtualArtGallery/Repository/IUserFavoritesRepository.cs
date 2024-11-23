namespace VirtualArtGallery.Repository
{
    internal interface IUserFavoritesRepository
    {
        bool AddFavoriteArtwork(int userID, int artworkID);
        bool RemoveFavoriteArtwork(int userID, int artworkID);
        List<int> GetUserFavoriteArtworks(int userID);
    }
}
