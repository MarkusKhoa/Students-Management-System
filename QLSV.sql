CREATE DATABASE QLSV
USE QLSV

CREATE TABLE SINHVIEN
(
	HoTen varchar(50),
	MSSV nvarchar(10),
	Lop nvarchar(20),
	NgaySinh smalldatetime,
	Email nvarchar(50),
	GioiTinh varchar(15),
	SoDT int,
	MaVung varchar(5)
)
ALTER TABLE SINHVIEN ADD CONSTRAINT SV_GT CHECK (GioiTinh = 'Nam' OR GioiTinh = 'Nữ' OR GioiTinh = 'Chưa xác định')