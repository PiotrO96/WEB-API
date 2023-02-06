CREATE TABLE [dbo].[Zamówienias] (
    [Zamowienia_Id]       INT             IDENTITY (1, 1) NOT NULL,
    [Zamowienie_Nr]     INT NOT NULL,
    [Zamowienie_Sklad] NVARCHAR (MAX)  NULL,
    [Zamowienie_Nalezy]    NVARCHAR (MAX)  NULL,
    CONSTRAINT [PK_Zamówienias] PRIMARY KEY CLUSTERED ([Zamowienia_Id] ASC)
);