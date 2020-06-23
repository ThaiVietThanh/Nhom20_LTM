CREATE TABLE [dbo].[users] (
    [TenDN]   NCHAR (20) NOT NULL,
    [MatKhau] NCHAR (20) NULL,
    CONSTRAINT [PK_users] PRIMARY KEY CLUSTERED ([TenDN] ASC)
);