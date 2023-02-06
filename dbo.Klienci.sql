CREATE TABLE [dbo].[Klienci] (
    [ID]            INT             IDENTITY (1, 1) NOT NULL,
    [Imie]          NVARCHAR (MAX)  NOT NULL,
    [Nazwisko]      NVARCHAR (MAX)  NOT NULL,
    [Email]         NVARCHAR (MAX)  NOT NULL,
    [Doswiadczenie] DECIMAL (18, 2) NOT NULL,
    CONSTRAINT [PK_Developers] PRIMARY KEY CLUSTERED ([ID] ASC)
);

