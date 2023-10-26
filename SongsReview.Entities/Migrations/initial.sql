

-------------------------------- CREATION --------------------------------

CREATE TABLE Artist (
	ArtistId INT IDENTITY(1,1) PRIMARY KEY,
	Name VARCHAR(255) NOT NULL,
	PhotoUrl VARCHAR(255) NOT NULL
)

CREATE TABLE Album (
	AlbumId INT IDENTITY(1,1) PRIMARY KEY,
	Name VARCHAR(255) NOT NULL,
	ArtistId INT FOREIGN KEY REFERENCES Artist(ArtistId),
	ReleaseYear INT NOT NULL,
	CoverArtUrl VARCHAR(255) NOT NULL
)

CREATE TABLE Song (
	SongId INT IDENTITY(1,1) PRIMARY KEY,
	Title VARCHAR(255) NOT NULL,
	AlbumId INT FOREIGN KEY REFERENCES Album(AlbumId)
)

CREATE TABLE [User] (
	Username VARCHAR(16) PRIMARY KEY,
	PhotoUrl VARCHAR(255) NOT NULL
)

CREATE TABLE Review (
	ReviewId INT IDENTITY(1,1) PRIMARY KEY,
	Review TEXT NOT NULL,
	CreatedAt DATETIMEOFFSET NOT NULL,
	UpdatedAt DATETIMEOFFSET NOT NULL,
	Username VARCHAR(16) FOREIGN KEY REFERENCES [User](Username),
	SongId INT FOREIGN KEY REFERENCES Song(SongId)
)


-------------------------------- INSERTION --------------------------------

INSERT INTO Artist (Name, PhotoUrl) VALUES 
('Mitski', 'https://i.scdn.co/image/ab67706c0000da843cca321a8be35ba1576455f1'),
('Efek Rumah Kaca', 'https://i.scdn.co/image/ab6761610000e5ebb345ac625dd036d8a8d085cd')

INSERT INTO Album (Name, CoverArtUrl, ReleaseYear, ArtistId) VALUES
('Be the Cowboy', 'https://i.scdn.co/image/ab67616d0000b273c428f67b4a9b7e1114dfc117', 2018, 1),
('Bury Me At Makeout Creek', 'https://i.scdn.co/image/ab67616d0000b27350f8ace2690355fa20e58227', 2014, 1),
('Kamar Gelap', 'https://i.scdn.co/image/ab67616d00001e020c0f7067fc2bb2ad9f288d7a', 2008, 2)

INSERT INTO Song (Title, AlbumId) VALUES
('A Pearl', 1),
('Me And My Husband', 1),
('Lonesome Love', 1),
('Texas Reznikoff', 2),
('Jobless Monday', 2),
('Kau dan Aku Menuju Ruang Hampa', 3),
('Balerina', 3)

INSERT INTO [User] (Username, PhotoUrl) VALUES
('nurel', 'https://ds393qgzrxwzn.cloudfront.net/cat1/img/images/0/Ci6OJHosgP.jpg'),
('someoneelse', 'https://images.boardriders.com/globalGrey/quiksilver-products/all/default/large/egl22bte31_quiksilver,l_kvj0_frt1.jpg')

INSERT INTO Review (Review, SongId, Username, CreatedAt, UpdatedAt) VALUES
('This song really captures the relationship between someone and her city where she grows up', 4, 'nurel', SYSDATETIMEOFFSET(), SYSDATETIMEOFFSET())

-----------------------------------------------------------



select s.Title, al.Name, ar.Name, al.ReleaseYear 
from Song s
join Album al on s.AlbumId = al.AlbumId
join Artist ar on al.ArtistId = ar.ArtistId


select r.Review, s.Title, u.Username, r.CreatedAt, r.UpdatedAt
from Review r
join [user] u on r.Username = u.username
join song s on r.SongId = s.SongId


-- dotnet ef dbcontext scaffold "Server=(localdb)\MSSQLLocalDB;Database=SongsReview;Trusted_Connection=True;" Microsoft.EntityFrameworkCore.SqlServer -o Entities

