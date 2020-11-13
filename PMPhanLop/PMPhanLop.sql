use master
drop database PMPhanLop

create database PMPhanLop
use PMPhanLop


--|||||||||    DROP TABLE   ||||||||||
drop table gia
drop table tour
drop table diadiem
drop table tour_diadiem


--||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||

----------------------------------CREATE TABLE------------------------------

create table loaidulich(
	idloaidl int primary key identity(1,1),
	tenloaidl nvarchar(256)
)

create table tour(
	idtour int primary key identity(1,1),
	idloaidl int foreign key references loaidulich(idloaidl),
	tentour nvarchar(256),
	thoigiantour int
)

create table gia(
	idgia int primary key identity,
	idtour int foreign key references tour(idtour),
	giatour int,
	ngaybatdau date,
	ngayketthuc date
)

create table diadiem(
	iddiadiem int primary key identity(1,1),
	tendiadiem nvarchar(256)
)

create table tour_diadiem(
	idtour_diadiem int primary key identity,
	idtour int foreign key references tour(idtour),
	iddiadiem int foreign key references diadiem(iddiadiem),
)

create table khach(
	idkhach int primary key identity(1,1),
	cmnd varchar(20) unique,
	hoten nvarchar(50),
	gioitinh bit,
	sodt varchar(11),
	diachi nvarchar(256)
)

create table doan(
	iddoan int primary key identity(1,1),
	idtour int foreign key references tour(idtour),
	tendoan nvarchar(256),
	ngaykhoihanh datetime,
	ngayketthuc datetime,
	tongchiphi int
)

create table chitietdoan(
	idchitietdoan int primary key identity,
	idkhach int foreign key references khach(idkhach),
	iddoan int foreign key references doan(iddoan)
)

create table loaichiphi(
	idloaicp int primary key identity(1,1),
	tenloaicp nvarchar(100)
)

create table chiphi(
	idchiphi int primary key identity(1,1),
	idloaicp int foreign key references loaichiphi(idloaicp), 
	iddoan int foreign key references doan(iddoan), 
	tongtien int,
	ghichu nvarchar(256) null
)

create table nhanvien(
	idnhanvien int primary key identity(1,1),
	hotennv nvarchar(50),
)

create table phancong(
	idphancong int primary key identity,
	iddoan int foreign key references doan(iddoan),
	idnhanvien int foreign key references nhanvien(idnhanvien),
	chucvu nvarchar(100),
	ghichu nvarchar(256) null
)


--||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||

--------------------------------------INSERT DATA-----------------------------------------

insert into loaidulich(tenloaidl) values
					(N'Du lịch trong nước'),
					(N'Du lịch nước ngoài')

insert into tour (idloaidl, tentour, thoigiantour) values
					(1, N'Đà Lạt - TPHCM', 2),
					(1, N'Hà Nội - TPHCM', 3),
					(1, N'NhaTrang - Vũng Tàu - TPHCM', 3),
					(1, N'Huế - Phong Nha', 2),
					(2, N'Venice', 7)

insert into gia (idtour, giatour, ngaybatdau, ngayketthuc) values
				(3, 1200000, '2020/02/01', '2020/05/31'),
				(3, 1000000, '2020/06/01', '2020/11/14'),
				(4, 1500000, '2020/02/01', '2020/12/31'),
				(5, 50000000, '2020/11/20', '2021/02/15'),
				(1, 1200000, '2020/09/01', '2020/11/30'),
				(2, 1200000, '2020/02/01', '2020/05/31')
				
insert into diadiem (tendiadiem) values
				(N'Chùa abc'),
				(N'Đền XYZ'),
				(N'Động Phong Nha'),
				(N'Hội An'),
				(N'Quốc Tự Giám')

insert into tour_diadiem(idtour, iddiadiem) values
				(1,2),
				(1,1),
				(2,1),
				(2,2),
				(2,5),
				(3,1),
				(4,2),
				(4,3),
				(4,1),
				(5,2)

insert into khach (cmnd, hoten, gioitinh, sodt, diachi) values
				('0000000000', N'Nguyễn Văn A', 1, '0901111111', N'001 đường a'),
				('0000000001', N'Nguyễn Văn B', 0, '0902111111', N'002 đường a'),
				('0000000002', N'Nguyễn Văn C', 1, '0903111111', N'003 đường a'),
				('0000000003', N'Nguyễn Văn D', 0, '0904111111', N'004 đường a'),
				('0000000004', N'Nguyễn Văn E', 1, '0905111111', N'005 đường a'),
				('0000000005', N'Nguyễn Văn F', 0, '0906111111', N'006 đường a'),
				('0000000006', N'Nguyễn Văn G', 1, '0907111111', N'007 đường a')

insert into doan (idtour, tendoan, ngaykhoihanh, ngayketthuc, tongchiphi) values
				(1, N'Đoàn A', '2020/11/21', '2020/11/23', 100000000),
				(2, N'Đoàn B', '2020/11/20', '2020/11/23', 100000000),
				(4, N'Đoàn C', '2020/12/21', '2020/12/23', 100000000),
				(1, N'Đoàn D', '2020/10/21', '2020/10/23', 100000000),
				(5, N'Đoàn E', '2020/11/1', '2020/11/8', 400000000),
				(3, N'Đoàn F', '2020/11/21', '2020/11/24', 100000000)

insert into chitietdoan(iddoan, idkhach) values
				(1,1),
				(1,5),
				(2,6),
				(2,3),
				(3,1),
				(3,4),
				(4,2),
				(4,5),
				(5,1),
				(6,2),
				(6,4)

insert into loaichiphi (tenloaicp) values
					(N'Ăn uống'),
					(N'Khách sạn'),
					(N'Phí vào cổng'),
					(N'Phí di chuyển')

insert into chiphi (idloaicp, iddoan, tongtien, ghichu) values
					(1, 1, 30000000, null),
					(2, 1, 65000000, null),
					(4, 1, 5000000, null),
					(1, 2, 20000000, null),
					(2, 2, 60000000, null),
					(3, 2, 10000000, null),
					(4, 2, 10000000, null),
					(1, 3, 10000000, null),
					(2, 3, 50000000, null),
					(3, 3, 40000000, null),
					(1, 4, 30000000, null),
					(2, 4, 70000000, null),
					(1, 5, 50000000, null),
					(2, 5, 150000000, null),
					(4, 5, 200000000, null),
					(1, 6, 150000000, null),
					(2, 6, 550000000, null),
					(4, 6, 300000000, null)

insert into nhanvien(hotennv) values
					(N'Nhân viên A'),
					(N'Nhân viên B'),
					(N'Nhân viên C'),
					(N'Nhân viên D'),
					(N'Nhân viên E')

insert into phancong(iddoan, idnhanvien, chucvu, ghichu) values
					(1, 2, N'Hướng dẫn viên', null),
					(1, 4, N'Hướng dẫn viên', null),
					(2, 5, N'Hướng dẫn viên', N'Trả lại thằng này 500k tiền gì đó'),
					(3, 4, N'Hướng dẫn viên', null),
					(4, 2, N'Hướng dẫn viên', N'Bị hành khách phản ánh'),
					(5, 3, N'Hướng dẫn viên', null),
					(6, 1, N'Hướng dẫn viên', null)



drop table chitietdoan
drop table khach