using VirtualArtGallery.Model;
using VirtualArtGallery.Repository;
using VirtualArtGallery.Service;

IArtworkRepository artworkRepository = new ArtworkRepository();
IArtworkService artworkService = new ArtworkService(artworkRepository);

IUserFavoritesRepository userFavoritesRepository = new UserFavoritesRepository();
IUserFavoritesService userFavoritesService = new UserFavoritesService(userFavoritesRepository);

IArtworkGalleryRepository artworkGalleryRepository = new ArtworkGalleryRepository();
IArtworkGalleryService artworkGalleryService = new ArtworkGalleryService(artworkGalleryRepository);

bool continueRunning = true;

while (continueRunning)
{
    Console.WriteLine("\n---- Virtual Art Gallery ----");
    Console.WriteLine("1. Add New Artwork");
    Console.WriteLine("2. Update Artwork");
    Console.WriteLine("3. Remove Artwork");
    Console.WriteLine("4. View Artwork By ID");
    Console.WriteLine("5. Search Artworks");
    Console.WriteLine("6. Add Artwork to Favorites");
    Console.WriteLine("7. Remove Artwork from Favorites");
    Console.WriteLine("8. View User's Favorite Artworks");
    Console.WriteLine("9. Add Artwork to Gallery");
    Console.WriteLine("10. Remove Artwork from Gallery");
    Console.WriteLine("11. View Artworks in a Gallery");
    Console.WriteLine("12. View Galleries for an Artwork");
    Console.WriteLine("13. Exit");
    Console.Write("Choose an option: ");

    string choice = Console.ReadLine();

    switch (choice)
    {
        // Artwork Management
        case "1":
            Console.WriteLine("Enter Artwork Details:");
            Artwork newArtwork = new Artwork();

            Console.Write("Title: ");
            newArtwork.Title = Console.ReadLine();

            Console.Write("Description: ");
            newArtwork.Description = Console.ReadLine();

            Console.Write("Creation Date (YYYY-MM-DD): ");
            newArtwork.CreationDate = DateTime.Parse(Console.ReadLine());

            Console.Write("Medium: ");
            newArtwork.Medium = Console.ReadLine();

            Console.Write("Image URL: ");
            newArtwork.ImageURL = Console.ReadLine();

            Console.Write("Artist ID: ");
            newArtwork.ArtistID = int.Parse(Console.ReadLine());

            if (artworkService.AddArtwork(newArtwork))
                Console.WriteLine("Artwork added successfully.");
            else
                Console.WriteLine("Failed to add artwork.");
            break;

        case "2":
            Console.Write("Enter Artwork ID to update: ");
            int updateArtworkID = int.Parse(Console.ReadLine());

            Artwork existingArtwork = artworkService.GetArtworkById(updateArtworkID);
            if (existingArtwork != null)
            {
                Console.Write("New Title (leave blank to keep current): ");
                string newTitle = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(newTitle)) existingArtwork.Title = newTitle;

                Console.Write("New Description (leave blank to keep current): ");
                string newDescription = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(newDescription)) existingArtwork.Description = newDescription;

                Console.Write("New Medium (leave blank to keep current): ");
                string newMedium = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(newMedium)) existingArtwork.Medium = newMedium;

                if (artworkService.UpdateArtwork(existingArtwork))
                    Console.WriteLine("Artwork updated successfully.");
                else
                    Console.WriteLine("Failed to update artwork.");
            }
            else
                Console.WriteLine("Artwork not found.");
            break;

        case "3":
            Console.Write("Enter Artwork ID to remove: ");
            int removeArtworkID = int.Parse(Console.ReadLine());

            if (artworkService.RemoveArtwork(removeArtworkID))
                Console.WriteLine("Artwork removed successfully.");
            else
                Console.WriteLine("Failed to remove artwork or Artwork not found.");
            break;

        case "4":
            Console.Write("Enter Artwork ID: ");
            int viewArtworkID = int.Parse(Console.ReadLine());

            Artwork artwork = artworkService.GetArtworkById(viewArtworkID);
            if (artwork != null)
            {
                Console.WriteLine($"Title: {artwork.Title}");
                Console.WriteLine($"Description: {artwork.Description}");
                Console.WriteLine($"Medium: {artwork.Medium}");
                Console.WriteLine($"Creation Date: {artwork.CreationDate}");
                Console.WriteLine($"Artist ID: {artwork.ArtistID}");
            }
            else
                Console.WriteLine("Artwork not found.");
            break;

        case "5":
            Console.Write("Enter keyword to search: ");
            string keyword = Console.ReadLine();

            var artworks = artworkService.SearchArtworks(keyword);
            if (artworks.Count > 0)
            {
                Console.WriteLine("Search Results:");
                foreach (var art in artworks)
                {
                    Console.WriteLine($"ID: {art.ArtworkID}, Title: {art.Title}");
                }
            }
            else
                Console.WriteLine("No artworks found.");
            break;

        // User Favorites
        case "6":
            Console.Write("Enter User ID: ");
            int userIDForFavorite = int.Parse(Console.ReadLine());

            Console.Write("Enter Artwork ID to add to favorites: ");
            int artworkIDForFavorite = int.Parse(Console.ReadLine());

            if (userFavoritesService.AddFavoriteArtwork(userIDForFavorite, artworkIDForFavorite))
                Console.WriteLine("Artwork added to favorites.");
            else
                Console.WriteLine("Failed to add artwork to favorites.");
            break;

        case "7":
            Console.Write("Enter User ID: ");
            int userIDForRemoveFavorite = int.Parse(Console.ReadLine());

            Console.Write("Enter Artwork ID to remove from favorites: ");
            int artworkIDForRemoveFavorite = int.Parse(Console.ReadLine());

            if (userFavoritesService.RemoveFavoriteArtwork(userIDForRemoveFavorite, artworkIDForRemoveFavorite))
                Console.WriteLine("Artwork removed from favorites.");
            else
                Console.WriteLine("Failed to remove artwork from favorites.");
            break;

        case "8":
            Console.Write("Enter User ID: ");
            int userIDForViewFavorites = int.Parse(Console.ReadLine());

            userFavoritesService.GetUserFavoriteArtworks(userIDForViewFavorites);
            break;

        // Artwork-Gallery Relationship
        case "9":
            Console.Write("Enter Artwork ID: ");
            int artworkIDToAdd = int.Parse(Console.ReadLine());
            Console.Write("Enter Gallery ID: ");
            int galleryIDToAdd = int.Parse(Console.ReadLine());

            if (artworkGalleryService.AddArtworkToGallery(artworkIDToAdd, galleryIDToAdd))
                Console.WriteLine("Artwork added to gallery.");
            else
                Console.WriteLine("Failed to add artwork to gallery.");
            break;

        case "10":
            Console.Write("Enter Artwork ID: ");
            int artworkIDToRemove = int.Parse(Console.ReadLine());
            Console.Write("Enter Gallery ID: ");
            int galleryIDToRemove = int.Parse(Console.ReadLine());

            if (artworkGalleryService.RemoveArtworkFromGallery(artworkIDToRemove, galleryIDToRemove))
                Console.WriteLine("Artwork removed from gallery.");
            else
                Console.WriteLine("Failed to remove artwork from gallery.");
            break;

        case "11":
            Console.Write("Enter Gallery ID: ");
            int galleryIDToView = int.Parse(Console.ReadLine());
            artworkGalleryService.GetArtworksByGalleryID(galleryIDToView);
            break;

        case "12":
            Console.Write("Enter Artwork ID: ");
            int artworkIDToViewGalleries = int.Parse(Console.ReadLine());
            artworkGalleryService.GetGalleriesByArtworkID(artworkIDToViewGalleries);
            break;

        case "13":
            continueRunning = false;
            Console.WriteLine("Exiting the system.");
            break;

        default:
            Console.WriteLine("Invalid choice. Please try again.");
            break;
    }
}
