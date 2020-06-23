CREATE PROCEDURE DangNhap
@TenDN as varchar(20),
@MatKhau as varchar(20)
AS
BEGIN
SELECT TenDN, MatKhau FROM users WHERE TenDN=@TenDN AND MatKhau=@MatKhau
END