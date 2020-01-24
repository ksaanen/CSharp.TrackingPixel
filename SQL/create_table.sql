CREATE TABLE [dbo].[Table]
(
	[Id] INT NOT NULL PRIMARY KEY,
  [TimeStamp] VARCHAR(25) NOT NULL,
  [RemoteIpAddress] VARCHAR(45) NOT NULL,
  [BaseURI] CHAR(100) NOT NULL,
  [Path] CHAR NOT NULL,
  [QueryParams] CHAR NOT NULL
)
