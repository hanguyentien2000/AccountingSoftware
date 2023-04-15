CREATE DATABASE AccountingSoftware
GO
USE AccountingSoftware


----------------------TẠO BẢNG----------------------

--Tạo bảng Phòng Ban--
GO
CREATE TABLE PhongBan
(
    MaPhongBan INT IDENTITY NOT NULL PRIMARY KEY,
	TenPhongBan NVARCHAR(100) NOT NULL,
	SDT NVARCHAR(100) NOT NULL,
)

--Tạo bảng Phòng Ban--
GO
CREATE TABLE ChucVu
(
    MaChucVu INT IDENTITY NOT NULL PRIMARY KEY,
	TenChucVu NVARCHAR(100) NOT NULL,
	HeSoPhuCapCV NVARCHAR(100) NOT NULL,
)

--Tạo bảng HSNV--
GO
CREATE TABLE NhanVien
(
	MaNV INT IDENTITY NOT NULL,
	MaPhongBan INT NOT NULL,
	MaChucVu INT NOT NULL,
	HoTen NVARCHAR(100) NOT NULL,
	NgaySinh DATE NOT NULL,
	GioiTinh BIT NULL,
	QueQuan NVARCHAR(100) NOT NULL,
	DiaChi NVARCHAR(100) NOT NULL,
	HeSoLuong NVARCHAR(100) NOT NULL,
	MaSoThue NVARCHAR(100) NOT NULL,
	SoNguoiPhuThuoc NVARCHAR(100) NOT NULL,
	NgayVaoLam DATE NOT NULL,
	TrinhDo NVARCHAR(100) NOT NULL,
	constraint PK_HSNV primary key (MaNV),
	constraint FK_HSNV1 foreign key (MaPhongBan) REFERENCES PhongBan(MaPhongBan),
	constraint FK_HSNV2 foreign key (MaChucVu) REFERENCES ChucVu(MaChucVu)
)

--Tạo bảng Bảng chấm công--
GO
CREATE TABLE BangChamCong
(
    MaCC INT IDENTITY NOT NULL,
	ThangCC NVARCHAR(100) NOT NULL,
	MaNV INT NOT NULL,
	NgayCongDiLam INT NOT NULL,
	NgayCongNghiPhep INT NOT NULL,
	XepLoai NVARCHAR(100) NOT NULL,
	NgayThuongThem NVARCHAR(100) NOT NULL,
	NgayLeThem NVARCHAR(100) NOT NULL,
	constraint PK_BCC primary key (MaCC),
	constraint FK_BCC1 foreign key (MaNV) REFERENCES NhanVien(MaNV)
)

--Tạo bảng chấm công--
GO
CREATE TABLE ThamSoTinhLuong
(
    MaThamSo INT IDENTITY NOT NULL,
	MaNV INT NOT NULL,
    ThangNam NVARCHAR(100) NOT NULL,
	LuongCB NVARCHAR(100) NOT NULL,
	NgcChuan NVARCHAR(100) NOT NULL,
	SoGioChuan NVARCHAR(100) NOT NULL,
	XepLoai NVARCHAR(100) NOT NULL,
	HsNgayThuong NVARCHAR(100) NOT NULL,
	HsNgayLe NVARCHAR(100) NOT NULL,
	PcAn NVARCHAR(100) NOT NULL,
	TLBHXH NVARCHAR(100) NOT NULL,
	TLBHYT NVARCHAR(100) NOT NULL,
	TLBHTN NVARCHAR(100) NOT NULL,
	TLKPCD NVARCHAR(100) NOT NULL,
	constraint PK_TSTL primary key (MaThamSo),
	constraint FK_TSTL1 foreign key (MaNV) REFERENCES NhanVien(MaNV)
)

--Tạo bảng tăng giảm TL--
GO
CREATE TABLE TangGiamLuong
(
	MaTangGiamLuong INT IDENTITY NOT NULL,
    MaNV INT NOT NULL,
	NgayThang NVARCHAR(100) NOT NULL,
	TaiKhoanNo NVARCHAR(100) NOT NULL,
	TaiKhoanChinh NVARCHAR(100) NOT NULL,
	SoTien NVARCHAR(100) NOT NULL,
	DienGia NVARCHAR(100) NOT NULL,
	constraint PK_TGL primary key (MaTangGiamLuong),
	constraint FK_TGL1 foreign key (MaNV) REFERENCES NhanVien(MaNV)
)

--Tạo bảng tăng giảm TL--
GO
CREATE TABLE ThueTNCN
(
    BacThue INT IDENTITY NOT NULL PRIMARY KEY,
	Tu NVARCHAR(100) NOT NULL,
	Den NVARCHAR(100) NOT NULL,
	ThueSuat NVARCHAR(100) NOT NULL,
)

--Tạo bảng tăng người dùng--
GO
CREATE TABLE NguoiDung
(
  MaNguoiDung INT IDENTITY NOT NULL PRIMARY KEY,
  TenNguoiDung NVARCHAR(100) NOT NULL,
  MatKhau NVARCHAR(100) NOT NULL,
  QuanTri Bit NOT NULL,
)

--Tạo bảng thông tin công ty--
GO
CREATE TABLE TTCongTy
(
    MaCT INT IDENTITY NOT NULL PRIMARY KEY,
	TenCT NVARCHAR(100) NOT NULL,
	TGD NVARCHAR(100) NOT NULL,
	PGD NVARCHAR(100) NOT NULL,
	KTT NVARCHAR(100) NOT NULL,
)

--Thêm dữ liệu vào bảng tài khoản
GO
INSERT INTO NguoiDung VALUES('admin','admin@123', 0)
INSERT INTO NguoiDung VALUES('anhngu','ltheng', 1)