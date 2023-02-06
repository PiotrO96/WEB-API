CREATE TABLE [dbo].[Produkties] (
    [Produkt_Id]       INT             IDENTITY (1, 1) NOT NULL,
    [Produkt_Nazwa]     NVARCHAR (MAX)  NULL,
    [Produkt_Cena] INT NOT NULL,
    [Produkt_Opis]    NVARCHAR (MAX)  NULL,
    CONSTRAINT [PK_Produkties] PRIMARY KEY CLUSTERED ([Produkt_Id] ASC)
);