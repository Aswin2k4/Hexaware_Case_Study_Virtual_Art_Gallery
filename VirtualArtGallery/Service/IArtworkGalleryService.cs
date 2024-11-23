namespace VirtualArtGallery.Service
{
    internal interface IArtworkGalleryService
    {
        bool AddArtworkToGallery(int artworkID, int galleryID);
        bool RemoveArtworkFromGallery(int artworkID, int galleryID);
        void GetArtworksByGalleryID(int galleryID);
        void GetGalleriesByArtworkID(int artworkID);
    }
}
