-- ==================================================================================================
-- Database Creation
-- ==================================================================================================

CREATE DATABASE VirtualArtGallery;

USE VirtualArtGallery;


-- 1. Create Artist Table
CREATE TABLE Artist (
    ArtistID INT PRIMARY KEY IDENTITY,
    Name VARCHAR(255) NOT NULL,
    Biography TEXT,
    BirthDate DATE,
    Nationality VARCHAR(100),
    Website VARCHAR(255),
    ContactInfo VARCHAR(255)
);

-- 2. Create Artwork Table
CREATE TABLE Artwork (
    ArtworkID INT PRIMARY KEY IDENTITY,
    Title VARCHAR(255) NOT NULL,
    Description TEXT,
    CreationDate DATE,
    Medium VARCHAR(100),
    ImageURL VARCHAR(255),
    ArtistID INT,
    CONSTRAINT FK_Artwork_Artist FOREIGN KEY (ArtistID) REFERENCES Artist(ArtistID)
);

-- 3. Create User Table
CREATE TABLE User (
    UserID INT PRIMARY KEY IDENTITY,
    Username VARCHAR(255) NOT NULL UNIQUE,
    Password VARCHAR(255) NOT NULL,
    Email VARCHAR(255) NOT NULL UNIQUE,
    FirstName VARCHAR(100),
    LastName VARCHAR(100),
    DateOfBirth DATE,
    ProfilePicture VARCHAR(255)
);

-- 4. Create Gallery Table
CREATE TABLE Gallery (
    GalleryID INT PRIMARY KEY IDENTITY,
    Name VARCHAR(255) NOT NULL,
    Description TEXT,
    Location VARCHAR(255),
    CuratorID INT,
    OpeningHours VARCHAR(100),
    CONSTRAINT FK_Gallery_Curator FOREIGN KEY (CuratorID) REFERENCES Artist(ArtistID)
);

-- 5. Create User_Favorite_Artwork Table (Junction table for User and Artwork)
CREATE TABLE User_Favorite_Artwork (
    UserID INT,
    ArtworkID INT,
    CONSTRAINT PK_User_Favorite_Artwork PRIMARY KEY (UserID, ArtworkID),
    CONSTRAINT FK_User_Favorite_Artwork_User FOREIGN KEY (UserID) REFERENCES [User](UserID),
    CONSTRAINT FK_User_Favorite_Artwork_Artwork FOREIGN KEY (ArtworkID) REFERENCES Artwork(ArtworkID)
);

-- 6. Create Artwork_Gallery Table (Junction table for Artwork and Gallery)
CREATE TABLE Artwork_Gallery (
    ArtworkID INT,
    GalleryID INT,
    CONSTRAINT PK_Artwork_Gallery PRIMARY KEY (ArtworkID, GalleryID),
    CONSTRAINT FK_Artwork_Gallery_Artwork FOREIGN KEY (ArtworkID) REFERENCES Artwork(ArtworkID),
    CONSTRAINT FK_Artwork_Gallery_Gallery FOREIGN KEY (GalleryID) REFERENCES Gallery(GalleryID)
);



SELECT * FROM Artist;
SELECT * FROM Artwork;
SELECT * FROM Artwork_Gallery;
SELECT * FROM Gallery;
SELECT * FROM [User];
SELECT * FROM User_Favorite_Artwork;


-- ==================================================================================================
-- ALTER TABLE QUERIES FOR EXISTING TABLES
-- ==================================================================================================

-- 1. Alter Artist Table
ALTER TABLE Artist
ADD TotalArtworks INT DEFAULT 0;

-- 2. Alter Gallery Table
ALTER TABLE Gallery
ADD VisitorCount INT DEFAULT 0,
    GalleryType NVARCHAR(50) NULL;

-- 3. Alter User Table
ALTER TABLE [User]
ADD Role NVARCHAR(50) DEFAULT 'User',
    LastLoginDate DATETIME NULL;

-- 4. Alter User_Favorite_Artwork Table
ALTER TABLE User_Favorite_Artwork
ADD DateAdded DATETIME DEFAULT GETDATE(),
    Notes NVARCHAR(255) NULL;

-- 5. Alter Artwork_Gallery Table
ALTER TABLE Artwork_Gallery
ADD DisplayStartDate DATETIME DEFAULT GETDATE(),
    DisplayEndDate DATETIME NULL,
    Position NVARCHAR(50) NULL;

-- ==================================================================================================
-- CREATE TABLE QUERIES FOR NEW TABLES
-- ==================================================================================================

-- 6. Create Reviews Table
CREATE TABLE Reviews (
    ReviewID INT IDENTITY(1,1) PRIMARY KEY,
    UserID INT NOT NULL FOREIGN KEY REFERENCES [User](UserID),
    ArtworkID INT NOT NULL FOREIGN KEY REFERENCES Artwork(ArtworkID),
    Rating INT CHECK (Rating BETWEEN 1 AND 5),
    Comments NVARCHAR(1000),
    ReviewDate DATETIME DEFAULT GETDATE()
);

-- 7. Create Visits Table
CREATE TABLE Visits (
    VisitID INT IDENTITY(1,1) PRIMARY KEY,
    UserID INT NOT NULL FOREIGN KEY REFERENCES [User](UserID),
    GalleryID INT NOT NULL FOREIGN KEY REFERENCES Gallery(GalleryID),
    VisitDate DATETIME DEFAULT GETDATE()
);

-- ==================================================================================================
-- INSERT DATA INTO EXISTING TABLES
-- ==================================================================================================

-- 8. Insert Data into Artist Table

INSERT INTO Artist (Name, Biography, BirthDate, Nationality, ContactInfo)
VALUES
('Walt Disney', 'Founder of Disney and creator of Mickey Mouse.', '1901-12-05', 'American', 'walt.disney@example.com'),
('Stephen Hillenburg', 'Creator of SpongeBob SquarePants.', '1961-08-21', 'American', 'stephen.hillenburg@example.com'),
('William Hanna', 'Co-creator of Tom and Jerry.', '1910-07-14', 'American', 'william.hanna@example.com'),
('Joseph Barbera', 'Co-creator of Tom and Jerry.', '1911-03-24', 'American', 'joseph.barbera@example.com'),
('Tex Avery', 'Key animator for Looney Tunes.', '1908-02-26', 'American', 'tex.avery@example.com'),
('John Lasseter', 'Director of Toy Story and creative lead at Pixar.', '1957-01-12', 'American', 'john.lasseter@example.com'),
('Hayao Miyazaki', 'Co-founder of Studio Ghibli and director of Spirited Away.', '1941-01-05', 'Japanese', 'hayao.miyazaki@example.com'),
('Charles Schulz', 'Creator of Peanuts.', '1922-11-26', 'American', 'charles.schulz@example.com'),
('Osamu Tezuka', 'Known as the Father of Manga.', '1928-11-03', 'Japanese', 'osamu.tezuka@example.com'),
('Matt Groening', 'Creator of The Simpsons.', '1954-02-15', 'American', 'matt.groening@example.com');


-- 9. Insert Data into Artwork Table
INSERT INTO Artwork (Title, Description, CreationDate, Medium, ImageURL, ArtistID)
VALUES 
('Mickey Mouse', 'Iconic Disney character.', '1928-11-18', 'Animation', 'http://example.com/mickey.jpg', 1),
('Donald Duck', 'Disney character known for his temper.', '1934-06-09', 'Animation', 'http://example.com/donald.jpg', 1),
('SpongeBob SquarePants', 'Underwater sponge and fry cook.', '1999-05-01', 'Animation', 'http://example.com/spongebob.jpg', 2),
('Tom', 'Part of the Tom & Jerry duo.', '1940-02-10', 'Animation', 'http://example.com/tom.jpg', 3),
('Jerry', 'Part of the Tom & Jerry duo.', '1940-02-10', 'Animation', 'http://example.com/jerry.jpg', 3),
('Bugs Bunny', 'Famous Looney Tunes character.', '1940-07-27', 'Animation', 'http://example.com/bugs.jpg', 4),
('Pikachu', 'Electric Pokémon mascot.', '1996-02-27', 'Digital', 'http://example.com/pikachu.jpg', 5),
('Scooby-Doo', 'Mystery-solving dog.', '1969-09-13', 'Animation', 'http://example.com/scooby.jpg', 6),
('Daffy Duck', 'Looney Tunes character.', '1937-04-17', 'Animation', 'http://example.com/daffy.jpg', 4),
('Shrek', 'Lovable green ogre.', '2001-04-22', '3D Animation', 'http://example.com/shrek.jpg', 7);


-- 10. Insert Data into User Table
INSERT INTO [User] (Username, Password, Email, FirstName, LastName, DateOfBirth, ProfilePicture)
VALUES 
('john_doe', 'password123', 'john.doe@example.com', 'John', 'Doe', '1990-01-15', 'http://example.com/john.jpg'),
('jane_doe', 'password123', 'jane.doe@example.com', 'Jane', 'Doe', '1992-03-12', 'http://example.com/jane.jpg'),
('cartoon_lover', 'ilovecartoons', 'lover@example.com', 'Cartoon', 'Lover', '2000-07-20', 'http://example.com/cartoon.jpg'),
('pika_fan', 'pika4life', 'pika@example.com', 'Ash', 'Ketchum', '1997-11-10', 'http://example.com/ash.jpg'),
('mystery_solver', 'zoinks123', 'scoobyfan@example.com', 'Fred', 'Jones', '1985-06-05', 'http://example.com/fred.jpg'),
('looney_fan', 'bugs4ever', 'bugsfan@example.com', 'Lola', 'Bunny', '1991-08-23', 'http://example.com/lola.jpg'),
('ogre_lover', 'swamplife', 'shrekfan@example.com', 'Fiona', 'Green', '1989-02-02', 'http://example.com/fiona.jpg'),
('disney_kid', 'mouse4life', 'disney@example.com', 'Minnie', 'Mouse', '1995-12-25', 'http://example.com/minnie.jpg'),
('duck_dynasty', 'quackquack', 'duckfan@example.com', 'Donald', 'Mallard', '1988-04-10', 'http://example.com/donald.jpg'),
('scooby_doo', 'scoobysnack', 'shaggy@example.com', 'Norville', 'Rogers', '1982-09-13', 'http://example.com/shaggy.jpg');


-- 11. Insert Data into Gallery Table

INSERT INTO Gallery (Name, Description, Location, CuratorID, OpeningHours)
VALUES
('Disney Classics', 'A gallery of timeless Disney artworks.', 'Orlando', 1, '9:00 AM - 5:00 PM'),
('Looney Tunes Forever', 'Celebrating the zaniest characters.', 'Hollywood', 5, '10:00 AM - 6:00 PM'),
('Pokémon Center', 'All about Pokémon!', 'Tokyo', 9, '8:00 AM - 4:00 PM'),
('Mystery Inc.', 'A tribute to Scooby-Doo and friends.', 'San Francisco', 3, '11:00 AM - 7:00 PM'),
('DreamWorks Legends', 'Highlighting DreamWorks favorites.', 'New York', 2, '9:30 AM - 5:30 PM'),
('Cartoon Network Classics', 'Focusing on the best of CN.', 'Atlanta', 4, '10:00 AM - 6:30 PM'),
('Anime Universe', 'Exploring the world of anime.', 'Kyoto', 7, '9:00 AM - 5:00 PM'),
('Pixar Paradise', 'Pixar’s finest works.', 'Emeryville', 6, '9:00 AM - 6:00 PM'),
('Retro Cartoons', 'Blast from the past!', 'Chicago', 8, '10:30 AM - 5:30 PM'),
('Animal Characters', 'Cartoon animals we love.', 'Dallas', 10, '8:00 AM - 3:00 PM');


-- 12. Insert Data into User_Favorite_Artwork Table
INSERT INTO User_Favorite_Artwork (UserID, ArtworkID, DateAdded, Notes)
VALUES 
(1, 1, '2024-11-01', 'Childhood favorite'),
(2, 3, '2024-11-02', 'Love the humor'),
(3, 7, '2024-11-03', 'Pikachu is iconic'),
(4, 8, '2024-11-04', 'Nostalgic character.');

-- 13. Insert Data into Artwork_Gallery Table
INSERT INTO Artwork_Gallery (ArtworkID, GalleryID, DisplayStartDate, DisplayEndDate, Position)
VALUES 
(1, 1, '2024-11-01', '2024-12-01', 'Wall A'),
(7, 3, '2024-11-05', '2024-11-30', 'Center Stage'),
(8, 4, '2024-11-10', '2024-12-10', 'Corner Display');

-- ==================================================================================================
-- INSERT DATA INTO NEW TABLES
-- ==================================================================================================

-- 14. Insert Data into Reviews Table
INSERT INTO Reviews (UserID, ArtworkID, Rating, Comments)
VALUES 
(1, 1, 5, 'Absolutely love Mickey Mouse!'),
(2, 3, 4, 'SpongeBob is so quirky!'),
(3, 7, 5, 'Pikachu is the best Pokémon.'),
(4, 8, 3, 'Scooby-Doo is nostalgic.');

-- 15. Insert Data into Visits Table
INSERT INTO Visits (UserID, GalleryID, VisitDate)
VALUES 
(1, 1, '2024-11-05'),
(2, 3, '2024-11-06'),
(3, 4, '2024-11-07'),
(4, 1, '2024-11-08');


-- ==================================================================================================


-- FORGORT TO ADD WEBSITE SO NOW UPDATING IT
UPDATE Artist
SET Website = CASE
    WHEN Name = 'Walt Disney' THEN 'https://www.disney.com'
    WHEN Name = 'Stephen Hillenburg' THEN 'https://www.nick.com/shows/spongebob-squarepants'
    WHEN Name = 'William Hanna' THEN 'https://www.tomandjerry.com'
    WHEN Name = 'Joseph Barbera' THEN 'https://www.tomandjerry.com'
    WHEN Name = 'Tex Avery' THEN 'https://www.looneytunes.com'
    WHEN Name = 'John Lasseter' THEN 'https://www.pixar.com'
    WHEN Name = 'Hayao Miyazaki' THEN 'https://www.studioghibli.com'
    WHEN Name = 'Charles Schulz' THEN 'https://www.peanuts.com'
    WHEN Name = 'Osamu Tezuka' THEN 'https://www.tezukaosamu.net'
    WHEN Name = 'Matt Groening' THEN 'https://www.simpsons.com'
    ELSE NULL
END;


INSERT INTO Artwork (Title, Description, CreationDate, Medium, ImageURL, ArtistID)
VALUES
-- Walt Disney (2 artworks)
('Mickey Mouse', 'Iconic Disney character.', '1928-11-18', 'Animation', 'http://example.com/mickey.jpg', 1),
('Donald Duck', 'Disney character known for his temper.', '1934-06-09', 'Animation', 'http://example.com/donald.jpg', 1),

-- Stephen Hillenburg (2 artworks)
('SpongeBob SquarePants', 'Underwater sponge and fry cook.', '1999-05-01', 'Animation', 'http://example.com/spongebob.jpg', 2),
('Patrick Star', 'SpongeBob’s best friend.', '1999-05-01', 'Animation', 'http://example.com/patrick.jpg', 2),

-- William Hanna and Joseph Barbera (shared artworks, 4 in total)
('Tom', 'Part of the Tom & Jerry duo.', '1940-02-10', 'Animation', 'http://example.com/tom.jpg', 3),
('Jerry', 'Part of the Tom & Jerry duo.', '1940-02-10', 'Animation', 'http://example.com/jerry.jpg', 3),
('Scooby-Doo', 'Mystery-solving dog.', '1969-09-13', 'Animation', 'http://example.com/scooby.jpg', 4),
('Fred Jones', 'Leader of the Mystery Inc. gang.', '1969-09-13', 'Animation', 'http://example.com/fred.jpg', 4),

-- Tex Avery (2 artworks)
('Bugs Bunny', 'Famous Looney Tunes character.', '1940-07-27', 'Animation', 'http://example.com/bugs.jpg', 5),
('Daffy Duck', 'Looney Tunes character.', '1937-04-17', 'Animation', 'http://example.com/daffy.jpg', 5);



-- FORGORT TO ADD TotalArtworks SO NOW UPDATING IT

UPDATE Artist
SET TotalArtworks = (
    SELECT COUNT(*)
    FROM Artwork
    WHERE Artwork.ArtistID = Artist.ArtistID
);


select * from Artist;

select ArtistID, count(ArtistID)
from Artwork
group by ArtistID;



-- Replace FK_Artwork_Artist with the actual foreign key name if different
ALTER TABLE Artwork
DROP CONSTRAINT FK_Artwork_Artist;


ALTER TABLE Artwork
ADD CONSTRAINT FK_Artwork_Artist
FOREIGN KEY (ArtistID) REFERENCES Artist(ArtistID)
ON DELETE CASCADE;


-- FORGORT TO ADD GALLERYTYPE AND VISITORCOUNT SO NOW UPDATING IT

-- Update GalleryType to reflect the focus of the gallery
UPDATE Gallery
SET GalleryType = CASE
    WHEN Name = 'Disney Classics' THEN 'Animation'
    WHEN Name = 'Looney Tunes Forever' THEN 'Animation'
    WHEN Name = 'Pokémon Center' THEN 'Digital Art'
    WHEN Name = 'Mystery Inc.' THEN 'Animation'
    WHEN Name = 'DreamWorks Legends' THEN 'Animation'
    WHEN Name = 'Cartoon Network Classics' THEN 'Animation'
    WHEN Name = 'Anime Universe' THEN 'Digital Art'
    WHEN Name = 'Pixar Paradise' THEN 'Animation'
    WHEN Name = 'Retro Cartoons' THEN 'Animation'
    WHEN Name = 'Animal Characters' THEN 'Mixed Media'
    ELSE 'General'
END;


-- Update LastLoginDate for all users
UPDATE [User]
SET LastLoginDate = CASE
    WHEN UserID = 1 THEN '2024-11-01 10:15:00'
    WHEN UserID = 2 THEN '2024-11-02 14:30:00'
    WHEN UserID = 3 THEN '2024-11-03 08:45:00'
    WHEN UserID = 4 THEN '2024-11-04 12:20:00'
    WHEN UserID = 5 THEN '2024-11-05 09:50:00'
    WHEN UserID = 6 THEN '2024-11-06 16:00:00'
    WHEN UserID = 7 THEN '2024-11-07 11:30:00'
    WHEN UserID = 8 THEN '2024-11-08 14:00:00'
    ELSE NULL
END;





SELECT * FROM Artist;
SELECT * FROM Artwork;
SELECT * FROM Artwork_Gallery;
SELECT * FROM Gallery;
SELECT * FROM [User];
SELECT * FROM User_Favorite_Artwork;
SELECT * FROM Visits;
SELECT * FROM Reviews;



select VisitorCount, GalleryType
from Gallery;
