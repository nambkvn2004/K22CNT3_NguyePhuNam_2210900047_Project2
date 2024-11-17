
create database K22CNT3_NguyenPhuNam_2210900047_Project2_Db
go 
use K22CNT3_NguyenPhuNam_2210900047_Project2_Db
go
create table QUAN_TRI (
Tai_khoan varchar(50) primary key,
Mat_khau varchar(32),
Trang_thai tinyint)
create table KHACH_HANG
(MaKH int IDENTITY (1,1) primary key,
Ho_ten nvarchar(100),
Tai_khoan varchar(50),
Mat_khau varchar(32),
Dia_chi nvarchar(200),
Dien_thoai varchar(30),
Email varchar(50),
Ngay_sinh DateTime,
Ngay_cap_nhat DateTime,
Gioi_tinh tinyint)
create table LOAI_SAN_PHAM(
MaLSP int primary key IDENTITY (1,1) not null,
Ten_loai nvarchar(50) not null,
Trang_thai tinyint)
create table SAN_PHAM(
MaSP int primary key IDENTITY (1,1) not null,
Ten_sp nvarchar(200) not null,
Mo_ta nvarchar(250),
Thong_tin nvarchar(250),
Gia_goc float default 0 not null, 
Gia_giam_gia float default 0,
Luot_xem int default 0 not null,
Ngay_cap_nhat datetime,
Trang_thai tinyint,
MaLSP int,
constraint fk_LOAI_SAN_PHAM foreign key(MaLSP) references LOAI_SAN_PHAM(MaLSP))
create table PT_VAN_CHUYEN(
MaPTVC int primary key identity(1,1) not null,
Ten_PTVC nvarchar(50),
Do_dai int,
Don_gia float default 0 not null,
Trang_thai tinyint)
create table PT_THANH_TOAN(
MaPTTT int primary key identity(1,1) not null,
Ten_PTTT nvarchar(50) not null,
Trang_thai tinyint)
create table HOA_DON(
MaHD int primary key identity(1,1) not null,
Ngay_HD datetime not null,
Hoten_nguoinhan nvarchar(100),
Diachi_nguoinhan nvarchar(200),
Dienthoai_nguoinhan varchar(30),
Diachi_email varchar(50),
Ngay_giao_hang datetime,
Trang_thai tinyint,
MaKH int,
MaPTVC int,
MaPTTT int,
constraint fk_KHACH_HANG_HOA_DON foreign key(MaKH) references KHACH_HANG(MaKH),
constraint fk_PT_VAN_CHUYEN_HOA_DON foreign key(MaPTVC) references PT_VAN_CHUYEN(MaPTVC),
constraint fk_PT_THANH_TOAN_HOA_DON foreign key(MaPTTT) references PT_THANH_TOAN(MaPTTT))
create table HINH_ANH(
MaHA int primary key identity(1,1) not null,
Ten_file_anh varchar(50) not null,
Trang_thai tinyint,
MaSP int,
constraint fk_SAN_PHAM_HINH_ANH FOREIGN KEY(MaSP) REFERENCES SAN_PHAM(MaSP))
create table SAN_PHAM_CT(
MaSPCT int primary key identity(1,1) not null,
So_luong int not null default 0,
MaSP int,
constraint fk_SAN_PHAM_SAN_PHAM_CT FOREIGN KEY(MaSP) REFERENCES SAN_PHAM(MaSP))
create table CT_HOA_DON(
MaHD int not null,
MaSPCT int not null,
So_luong_ban int not null default 0,
Gia_ban float not null default 0,
Tra_lai int default 0,
constraint pk_CT_HOA_DON primary key(MaHD, MaSPCT),
constraint fk_HOA_DON_CT_HOA_DON foreign key(MaHD) references HOA_DON(MaHD),
constraint fk_SAN_PHAM_CT_CT_HOA_DON foreign key(MaSPCT) references SAN_PHAM_CT(MaSPCT))
create table BINH_LUAN(
MaBL int not null primary key,
MaKH int,
MaSP int,
Tieu_de nvarchar(100),
Noi_dung nvarchar(200),
Ngay_BL datetime not null,
Trang_thai tinyint,
constraint fk_KHACH_HANG_BINH_LUAN foreign key(MaKH) references KHACH_HANG(MaKH),
constraint fk_SAN_PHAM_BINH_LUAN foreign key(MaSP) references SAN_PHAM(MaSP))
create table LIEN_HE(
MaLH int not null primary key identity(1,1),
Tieu_de nvarchar(200) not null,
Dia_chi nvarchar(250) not null,
Dien_thoai varchar(250) not null,
Email varchar(100) not null,
Facebook varchar(100),
Logo varchar(50),
Trang_thai tinyint)
create table PHAN_HOI(
MaPH int not null primary key identity(1,1),
Tieu_de nvarchar(200) not null,
Noi_dung nvarchar(200) not null,
Ngay_gui datetime not null,
Email varchar(100),
Facebook varchar(100),
Tra_loi nvarchar(200),
Trang_thai tinyint,
Da_xem tinyint)
select *  from BINH_LUAN
-- Bang QUAN_TRI
insert into QUAN_TRI values ('admin', '2210900047', 1)

-- Bang KHACH_HANG
insert into KHACH_HANG (Ho_ten, Tai_khoan, Mat_khau, Dia_chi, Dien_thoai, Email, Ngay_sinh, Ngay_cap_nhat, Gioi_tinh)
values (N'Nguyen Phu Nam', 'nguyenphunam', 'npn2004', N'209 Trieu Khuc', '0902069171', 'nambkvn2004@gmail.com', '2004-07-26', GETDATE(), 1)
insert into KHACH_HANG (Ho_ten, Tai_khoan, Mat_khau, Dia_chi, Dien_thoai, Email, Ngay_sinh, Ngay_cap_nhat, Gioi_tinh)
values (N'Hoang Quoc Minh', 'hoangquocminh', 'hqm2004', N'322 Nguyen Trai', '0762446125', 'hoangquocminh@gmail.com', '2004-05-16', GETDATE(), 0)

-- Bang LOAI_SAN_PHAM
insert into LOAI_SAN_PHAM (Ten_loai, Trang_thai)
values (N'Trai cay', 1)
insert into LOAI_SAN_PHAM (Ten_loai, Trang_thai)
values (N'Banh ngot', 1)

-- Bang SAN_PHAM
insert into SAN_PHAM (Ten_sp, Mo_ta, Thong_tin, Gia_goc, Gia_giam_gia, Luot_xem, Ngay_cap_nhat, Trang_thai, MaLSP)
values (N'Tao', N'Tao do tuoi', N'Tao do huu co tu trang trai', 2.00, 1.80, 150, '2024-11-14', 1, 1)
insert into SAN_PHAM (Ten_sp, Mo_ta, Thong_tin, Gia_goc, Gia_giam_gia, Luot_xem, Ngay_cap_nhat, Trang_thai, MaLSP)
values (N'Banh chocolate', N'Banh chocolate ngon', N'Banh chocolate am voi lop ganache', 15.00, 12.00, 80, '2024-11-14', 1, 2)

-- Bang PT_VAN_CHUYEN
insert into PT_VAN_CHUYEN (Ten_PTVC, Do_dai, Don_gia, Trang_thai)
values (N'Giao hang tieu chuan', 10, 5.00, 1)
insert into PT_VAN_CHUYEN (Ten_PTVC, Do_dai, Don_gia, Trang_thai)
values (N'Giao hang nhanh', 5, 10.00, 1)

-- Bang PT_THANH_TOAN
insert into PT_THANH_TOAN (Ten_PTTT, Trang_thai)
values (N'The tin dung', 1)
insert into PT_THANH_TOAN (Ten_PTTT, Trang_thai)
values (N'Thanh toan khi nhan hang', 1)

-- Bang HOA_DON
insert into HOA_DON (Ngay_HD, Hoten_nguoinhan, Diachi_nguoinhan, Dienthoai_nguoinhan, Diachi_email, Ngay_giao_hang, Trang_thai, MaKH, MaPTVC, MaPTTT)
values (GETDATE(), 'Ha Quoc Thanh', '123 Duong Yen Xa', '0123456789', 'hqt@gmail.com', '2024-12-01', 1, 1, 1, 1)
insert into HOA_DON (Ngay_HD, Hoten_nguoinhan, Diachi_nguoinhan, Dienthoai_nguoinhan, Diachi_email, Ngay_giao_hang, Trang_thai, MaKH, MaPTVC, MaPTTT)
values (GETDATE(), 'Dao Doan Xuan Duy', '456 Duong To Huu', '0987654321', 'ddxd@gmail.com', '2024-12-05', 1, 2, 2, 2)

-- Bang HINH_ANH
insert into HINH_ANH (Ten_file_anh, Trang_thai, MaSP)
values (N'hinh_1.jpg', 1, 1)
insert into HINH_ANH (Ten_file_anh, Trang_thai, MaSP)
values (N'hinh_2.jpg', 1, 2)

-- Bang SAN_PHAM_CT
insert into SAN_PHAM_CT (So_luong, MaSP)
values (50, 1)
insert into SAN_PHAM_CT (So_luong, MaSP)
values (30, 2)

-- Bang CT_HOA_DON
insert into CT_HOA_DON (MaHD, MaSPCT, So_luong_ban, Gia_ban)
values (1, 1, 5, 10.00)
insert into CT_HOA_DON (MaHD, MaSPCT, So_luong_ban, Gia_ban)
values (1, 2, 3, 12.00)

-- Bang BINH_LUAN
insert into BINH_LUAN (MaBL, MaKH, MaSP, Tieu_de, Noi_dung, Ngay_BL, Trang_thai)
values (1, 1, 1, N'Binh luan ve tao', N'Tao rat ngon', GETDATE(), 1)
insert into BINH_LUAN (MaBL, MaKH, MaSP, Tieu_de, Noi_dung, Ngay_BL, Trang_thai)
values (2, 2, 2, N'Binh luan ve banh', N'Banh rat hap dan', GETDATE(), 1)

-- Bang LIEN_HE
insert into LIEN_HE (Tieu_de, Dia_chi, Dien_thoai, Email, Facebook, Logo, Trang_thai)
values (N'Lien he', N'So 10, Duong 2', '0987654321', 'lienhe@gmail.com', 'fb.com/lienhe', 'logo.jpg', 1)

-- Bang PHAN_HOI
insert into PHAN_HOI (Tieu_de, Noi_dung, Ngay_gui, Email, Facebook, Tra_loi, Trang_thai, Da_xem)
values (N'Phan hoi ve dich vu', N'Dich vu rat tot', GETDATE(), 'phd@gmail.com', 'fb.com/phd', N'Cam on phan hoi', 1, 0)
ALTER TABLE BINH_LUAN ALTER COLUMN Ngay_BL DATETIME NULL;
