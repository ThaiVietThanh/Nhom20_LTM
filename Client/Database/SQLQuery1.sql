
CREATE TABLE [dbo].[users] (
    [TenDN]   NCHAR (20) NOT NULL,
    [MatKhau] NCHAR (20) NULL,
    CONSTRAINT [PK_users] PRIMARY KEY CLUSTERED ([TenDN] ASC)
);

GO

CREATE PROCEDURE DangNhap
@TenDN as varchar(20),
@MatKhau as varchar(20)
AS
BEGIN
SELECT TenDN, MatKhau FROM users WHERE TenDN=@TenDN AND MatKhau=@MatKhau
END