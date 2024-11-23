using VirtualArtGallery.Model;
using System.Collections.Generic;

namespace VirtualArtGallery.Repository
{
    internal interface IArtworkRepository
    {
        bool AddArtwork(Artwork artwork);
        bool UpdateArtwork(Artwork artwork);
        bool RemoveArtwork(int artworkID);
        Artwork GetArtworkById(int artworkID);
        List<Artwork> SearchArtworks(string keyword);
    }
}
