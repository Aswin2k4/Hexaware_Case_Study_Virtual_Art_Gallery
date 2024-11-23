namespace VirtualArtGallery.Repository
{
    internal interface IArtworkGalleryRepository
    {
        bool AddArtworkToGallery(int artworkID, int galleryID);
        bool RemoveArtworkFromGallery(int artworkID, int galleryID);
        void GetArtworksByGalleryID(int galleryID);
        void GetGalleriesByArtworkID(int artworkID);
    }
}
