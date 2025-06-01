CREATE DATABASE QUANLYXEMAY;
GO

-- Sử dụng Database
USE QUANLYXEMAY;
GO

-- Tạo bảng tblcongviec
CREATE TABLE tblcongviec (
    macv CHAR(10) PRIMARY KEY,
    tencv NVARCHAR(100),
    luongthang FLOAT
);

-- Tạo bảng tblnhanvien
CREATE TABLE tblnhanvien (
    manv CHAR(10) PRIMARY KEY,
    tennv NVARCHAR(100),
    gioitinh NVARCHAR(10),
    ngaysinh DATE,
    sdt VARCHAR(15),
    diachi NVARCHAR(200),
    macv CHAR(10) FOREIGN KEY REFERENCES tblcongviec(macv)
);

-- Tạo bảng tblkhachhang
CREATE TABLE tblkhachhang (
    makhach CHAR(10) PRIMARY KEY,
    tenkhach NVARCHAR(100),
    diachi NVARCHAR(200),
    sdt VARCHAR(15)
);

-- Tạo bảng tblnhacungcap
CREATE TABLE tblnhacungcap (
    mancc CHAR(10) PRIMARY KEY,
    tenncc NVARCHAR(100),
    diachi NVARCHAR(200),
    sdt VARCHAR(15)
);

-- Tạo bảng tblmausac
CREATE TABLE tblmausac (
    mamau CHAR(10) PRIMARY KEY,
    tenmau NVARCHAR(50)
);

-- Tạo bảng tblhangsx
CREATE TABLE tblhangsx (
    mahangsx CHAR(10) PRIMARY KEY,
    tenhangsx NVARCHAR(100)
);

-- Tạo bảng tbldongco
CREATE TABLE tbldongco (
    madongco CHAR(10) PRIMARY KEY,
    tendongco NVARCHAR(100)
);

-- Tạo bảng tblnuocsx
CREATE TABLE tblnuocsx (
    manuocsx CHAR(10) PRIMARY KEY,
    tennuocsx NVARCHAR(100)
);

-- Tạo bảng tbltheloai
CREATE TABLE tbltheloai (
    maloai CHAR(10) PRIMARY KEY,
    tenloai NVARCHAR(100)
);

-- Tạo bảng tbltinhtrang
CREATE TABLE tbltinhtrang (
    maTT CHAR(10) PRIMARY KEY,
    tenTT NVARCHAR(100)
);

-- Tạo bảng tblphanhxe
CREATE TABLE tblphanhxe (
    maphanh CHAR(10) PRIMARY KEY,
    tenphanh NVARCHAR(100)
);

-- Tạo bảng tbldmhang (Danh mục hàng hóa)
CREATE TABLE tbldmhang (
    mahang CHAR(10) PRIMARY KEY,
    tenhang NVARCHAR(100),
    namsx INT,
    maloai CHAR(10) FOREIGN KEY REFERENCES tbltheloai(maloai),
    mahangsx CHAR(10) FOREIGN KEY REFERENCES tblhangsx(mahangsx),
    mamau CHAR(10) FOREIGN KEY REFERENCES tblmausac(mamau),
    maphanh CHAR(10) FOREIGN KEY REFERENCES tblphanhxe(maphanh),
    madongco CHAR(10) FOREIGN KEY REFERENCES tbldongco(madongco),
    manuocsx CHAR(10) FOREIGN KEY REFERENCES tblnuocsx(manuocsx),
    maTT CHAR(10) FOREIGN KEY REFERENCES tbltinhtrang(maTT),
    dungtichbinhxang smallint,
    anh NVARCHAR(255),
    soluong INT,
    dongianhap FLOAT,
    dongiaban FLOAT,
    thoigianbaohanh smallint
);

-- Tạo bảng tblhoadonnhap
CREATE TABLE tblhoadonnhap (
    sohdn NVARCHAR(50) PRIMARY KEY,
    ngaynhap DATE,
    tongtien FLOAT,
    manv CHAR(10) FOREIGN KEY REFERENCES tblnhanvien(manv),
    mancc CHAR(10) FOREIGN KEY REFERENCES tblnhacungcap(mancc)
);

-- Tạo bảng tblchitiethdn
CREATE TABLE tblchitiethdn (
    sohdn NVARCHAR(50),
    mahang CHAR(10),
    soluong INT,
	dongia FLOAT,
    giamgia FLOAT,
    thanhtien FLOAT,
    PRIMARY KEY (sohdn, mahang),
    FOREIGN KEY (sohdn) REFERENCES tblhoadonnhap(sohdn),
    FOREIGN KEY (mahang) REFERENCES tbldmhang(mahang)
);

-- Tạo bảng tbldondathang
CREATE TABLE tbldondathang (
    soddh NVARCHAR(50) PRIMARY KEY,
    ngaymua DATE,
    datcoc FLOAT,
    thue FLOAT,
    tongtien FLOAT,
    manv CHAR(10) FOREIGN KEY REFERENCES tblnhanvien(manv),
    makhach CHAR(10) FOREIGN KEY REFERENCES tblkhachhang(makhach)
);

-- Tạo bảng tblchitietddh
CREATE TABLE tblchitietddh (
    soddh NVARCHAR(50),
    mahang CHAR(10),
    soluong INT,
    giamgia FLOAT,
    thanhtien FLOAT,
    PRIMARY KEY (soddh, mahang),
    FOREIGN KEY (soddh) REFERENCES tbldondathang(soddh),
    FOREIGN KEY (mahang) REFERENCES tbldmhang(mahang)
);
SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'tblchitietddh';


-- THÊM DỮ LIỆU

-- Thêm dữ liệu vào tblcongviec
INSERT INTO tblcongviec (macv, tencv, luongthang) VALUES
('CV001', N'Quản lý bán hàng', 20000000),
('CV002', N'Nhân viên kinh doanh', 12000000),
('CV003', N'Nhân viên kho', 10000000),
('CV004', N'Thợ sửa xe', 15000000),
('CV005', N'Kế toán', 14000000),
('CV006', N'Trưởng phòng kinh doanh', 22000000),
('CV007', N'Nhân viên chăm sóc khách hàng', 11000000),
('CV008', N'Nhân viên bảo trì', 12000000),
('CV009', N'Giám đốc kỹ thuật', 30000000),
('CV010', N'Quản lý kho', 18000000),
('CV011', N'Nhân viên kế hoạch', 13000000),
('CV012', N'Nhân viên marketing', 14000000),
('CV013', N'Nhân viên kỹ thuật', 15000000),
('CV014', N'Nhân viên bảo hiểm', 12000000),
('CV015', N'Nhân viên giao nhận', 10000000),
('CV016', N'Chuyên viên IT', 20000000),
('CV017', N'Kỹ thuật viên điện tử', 16000000),
('CV018', N'Nhân viên kiểm tra chất lượng', 14000000),
('CV019', N'Nhân viên tư vấn sản phẩm', 12500000),
('CV020', N'Thủ kho', 11000000),
('CV021', N'Trưởng phòng bảo hành', 21000000),
('CV022', N'Nhân viên lái xe', 10000000),
('CV023', N'Nhân viên chăm sóc xe', 11000000),
('CV024', N'Nhân viên vệ sinh', 9000000),
('CV025', N'Bảo vệ', 8000000);


-- Thêm dữ liệu vào tblnhanvien
INSERT INTO tblnhanvien (manv, tennv, gioitinh, ngaysinh, sdt, diachi, macv) VALUES
('NV001', N'Nguyễn Văn An', N'Nam', '1990-05-10', '0909123456', N'12 Lý Thường Kiệt, Hà Nội', 'CV001'),
('NV002', N'Lê Thị Bình', N'Nữ', '1995-08-15', '0911222333', N'25 Trần Phú, Hà Nội', 'CV002'),
('NV003', N'Phạm Văn Cường', N'Nam', '1992-02-20', '0933444555', N'3 Nguyễn Huệ, Hà Nội', 'CV003'),
('NV004', N'Trần Thị Dung', N'Nữ', '1998-12-05', '0944555666', N'8 Hai Bà Trưng, Hà Nội', 'CV004'),
('NV005', N'Hoàng Văn Đạt', N'Nam', '1988-03-25', '0955666777', N'15 Láng Hạ, Hà Nội', 'CV005'),
('NV006', N'Phạm Thị Lan', N'Nữ', '1994-07-12', '0901234567', N'10 Phố Huế, Hà Nội', 'CV006'),
('NV007', N'Đỗ Văn Long', N'Nam', '1985-11-25', '0912345678', N'5 Láng Hạ, Hà Nội', 'CV007'),
('NV008', N'Nguyễn Thị Mai', N'Nữ', '1990-03-15', '0923456789', N'8 Xã Đàn, Hà Nội', 'CV008'),
('NV009', N'Lê Quang Dũng', N'Nam', '1988-06-30', '0934567890', N'17 Nguyễn Chí Thanh, Hà Nội', 'CV009'),
('NV010', N'Hoàng Thu Hương', N'Nữ', '1996-01-05', '0945678901', N'35 Cầu Giấy, Hà Nội', 'CV010'),
('NV011', N'Trần Đình Nam', N'Nam', '1993-09-09', '0956789012', N'56 Đê La Thành, Hà Nội', 'CV011'),
('NV012', N'Ngô Văn Hải', N'Nam', '1991-12-20', '0967890123', N'12 Tây Sơn, Hà Nội', 'CV012'),
('NV013', N'Lê Mỹ Linh', N'Nữ', '1997-05-02', '0978901234', N'7 Phan Bội Châu, Hà Nội', 'CV013'),
('NV014', N'Bùi Minh Tuấn', N'Nam', '1992-07-19', '0989012345', N'30 Đống Đa, Hà Nội', 'CV014'),
('NV015', N'Nguyễn Thanh Hương', N'Nữ', '1995-10-10', '0990123456', N'9 Kim Mã, Hà Nội', 'CV015'),
('NV016', N'Phạm Duy Anh', N'Nam', '1989-04-15', '0911988888', N'88 Trần Quốc Toản, Hà Nội', 'CV016'),
('NV017', N'Trịnh Thanh Tùng', N'Nam', '1990-06-12', '0912765432', N'45 Hoàng Hoa Thám, Hà Nội', 'CV017'),
('NV018', N'Nguyễn Thu Trang', N'Nữ', '1994-09-09', '0923321122', N'22 Phạm Ngọc Thạch, Hà Nội', 'CV018'),
('NV019', N'Ngô Minh Đức', N'Nam', '1993-02-14', '0934211223', N'17 Bạch Mai, Hà Nội', 'CV019'),
('NV020', N'Đào Hồng Nhung', N'Nữ', '1996-12-21', '0945121345', N'33 Hàng Bài, Hà Nội', 'CV020'),
('NV021', N'Trương Quốc Bảo', N'Nam', '1992-03-09', '0956121543', N'99 Lý Nam Đế, Hà Nội', 'CV021'),
('NV022', N'Hoàng Minh Châu', N'Nữ', '1987-11-29', '0967121743', N'66 Phạm Văn Đồng, Hà Nội', 'CV022'),
('NV023', N'Vũ Thanh Sơn', N'Nam', '1990-07-07', '0978121943', N'11 Đào Tấn, Hà Nội', 'CV023'),
('NV024', N'Lê Ngọc Ánh', N'Nữ', '1998-08-18', '0989121543', N'21 Hàng Cót, Hà Nội', 'CV024'),
('NV025', N'Nguyễn Khánh Toàn', N'Nam', '1995-05-05', '0990121143', N'72 Ngọc Khánh, Hà Nội', 'CV025');

-- Thêm dữ liệu vào tblkhachhang
INSERT INTO tblkhachhang (makhach, tenkhach, diachi, sdt) VALUES
('KH001', N'Đỗ Minh Tuấn', N'101 Giải Phóng, Hà Nội', '0967888999'),
('KH002', N'Nguyễn Thị Hạnh', N'202 Kim Ngưu, Hà Nội', '0977999000'),
('KH003', N'Trần Văn Thành', N'303 Trương Định, Hà Nội', '0988111222'),
('KH004', N'Lê Thị Hương', N'404 Bạch Mai, Hà Nội', '0999222333'),
('KH005', N'Phạm Văn Sơn', N'505 Lê Duẩn, Hà Nội', '0911222333'),
('KH006', N'Ngô Minh Khoa', N'606 Nguyễn Trãi, Hà Nội', '0901234567'),
('KH007', N'Lê Hoàng Nam', N'707 Láng, Hà Nội', '0912345678'),
('KH008', N'Phạm Quỳnh Anh', N'808 Kim Mã, Hà Nội', '0923456789'),
('KH009', N'Nguyễn Thị Nga', N'909 Đê La Thành, Hà Nội', '0934567890'),
('KH010', N'Hồ Văn Hậu', N'1010 Phạm Văn Đồng, Hà Nội', '0945678901'),
('KH011', N'Đặng Văn Đức', N'1111 Hoàng Quốc Việt, Hà Nội', '0956789012'),
('KH012', N'Trần Hải Yến', N'1212 Nguyễn Xiển, Hà Nội', '0967890123'),
('KH013', N'Bùi Văn Sơn', N'1313 Trần Duy Hưng, Hà Nội', '0978901234'),
('KH014', N'Nguyễn Thanh Huyền', N'1414 Xã Đàn, Hà Nội', '0989012345'),
('KH015', N'Lê Minh Tuấn', N'1515 Tây Sơn, Hà Nội', '0990123456'),
('KH016', N'Phan Văn Toàn', N'1616 Chùa Bộc, Hà Nội', '0902233445'),
('KH017', N'Vũ Thị Mai', N'1717 Phố Huế, Hà Nội', '0913344556'),
('KH018', N'Trần Minh Phương', N'1818 Đại La, Hà Nội', '0924455667'),
('KH019', N'Đỗ Hoàng Anh', N'1919 Minh Khai, Hà Nội', '0935566778'),
('KH020', N'Nguyễn Thị Hoa', N'2020 Lạc Trung, Hà Nội', '0946677889'),
('KH021', N'Hoàng Minh Thắng', N'2121 Bạch Đằng, Hà Nội', '0957788990'),
('KH022', N'Phạm Quốc Bảo', N'2222 Trần Khát Chân, Hà Nội', '0968899001'),
('KH023', N'Trần Thị Thảo', N'2323 Bùi Xương Trạch, Hà Nội', '0979900112'),
('KH024', N'Nguyễn Hoàng Dương', N'2424 Định Công, Hà Nội', '0980011223'),
('KH025', N'Phạm Văn Bình', N'2525 Tân Mai, Hà Nội', '0991122334');

-- Thêm dữ liệu vào tblnhacungcap
INSERT INTO tblnhacungcap (mancc, tenncc, diachi, sdt) VALUES
('NCC001', N'Công ty Honda Việt Nam', N'Phúc Yên, Vĩnh Phúc', '02113888888'),
('NCC002', N'Công ty Yamaha Việt Nam', N'KCN Nội Bài, Hà Nội', '02437889999'),
('NCC003', N'Công ty Piaggio Việt Nam', N'Vĩnh Phúc', '02113887777'),
('NCC004', N'Công ty SYM Việt Nam', N'Bình Dương', '02743881111'),
('NCC005', N'Công ty Suzuki Việt Nam', N'Bình Dương', '02743884444'),
('NCC006', N'Công ty Kymco Việt Nam', N'Bình Dương', '02743991111'),
('NCC007', N'Công ty SYM Bắc Ninh', N'Bắc Ninh', '02223886666'),
('NCC008', N'Công ty Vinfast', N'Hải Phòng', '02252221111'),
('NCC009', N'Công ty PEGA Việt Nam', N'Hà Nội', '02436667777'),
('NCC010', N'Công ty Dibao Việt Nam', N'Hà Nội', '02435559999'),
('NCC011', N'Công ty Yamaha Bắc Ninh', N'Bắc Ninh', '02222223333'),
('NCC012', N'Công ty Honda Bắc Giang', N'Bắc Giang', '02043993333'),
('NCC013', N'Công ty SYM Hải Phòng', N'Hải Phòng', '02252225555'),
('NCC014', N'Công ty Honda Quảng Ninh', N'Quảng Ninh', '02033668888'),
('NCC015', N'Công ty Suzuki Hải Dương', N'Hải Dương', '02203883333'),
('NCC016', N'Công ty Honda Thái Nguyên', N'Thái Nguyên', '02083991111'),
('NCC017', N'Công ty Yamaha Thanh Hóa', N'Thanh Hóa', '02373886666'),
('NCC018', N'Công ty Suzuki Nghệ An', N'Nghệ An', '02383884444'),
('NCC019', N'Công ty Honda Hà Tĩnh', N'Hà Tĩnh', '02393992222'),
('NCC020', N'Công ty SYM Đà Nẵng', N'Đà Nẵng', '02363668888'),
('NCC021', N'Công ty Vinfast Sài Gòn', N'Hồ Chí Minh', '02837775555'),
('NCC022', N'Công ty Suzuki Bình Dương', N'Bình Dương', '02743992222'),
('NCC023', N'Công ty Yamaha Cần Thơ', N'Cần Thơ', '02923889999'),
('NCC024', N'Công ty Honda Đồng Nai', N'Đồng Nai', '02513883333'),
('NCC025', N'Công ty SYM Vũng Tàu', N'Vũng Tàu', '02543884444');

-- Thêm dữ liệu vào tblmausac
INSERT INTO tblmausac (mamau, tenmau) VALUES
('MS001', N'Đen'),
('MS002', N'Trắng'),
('MS003', N'Đỏ'),
('MS004', N'Xanh dương'),
('MS005', N'Xám'),
('MS006', N'Xanh lá'),
('MS007', N'Vàng'),
('MS008', N'Hồng'),
('MS009', N'Tím'),
('MS010', N'Cam'),
('MS011', N'Nâu'),
('MS012', N'Bạc'),
('MS013', N'Xanh ngọc'),
('MS014', N'Xanh rêu'),
('MS015', N'Be'),
('MS016', N'Ghi'),
('MS017', N'Đỏ đô'),
('MS018', N'Xanh dương đậm'),
('MS019', N'Vàng cát'),
('MS020', N'Xanh pastel'),
('MS021', N'Cam đất'),
('MS022', N'Trắng ngà'),
('MS023', N'Hồng pastel'),
('MS024', N'Tím pastel'),
('MS025', N'Xanh navy');

-- Thêm dữ liệu vào tblhangsx
INSERT INTO tblhangsx (mahangsx, tenhangsx) VALUES
('HSX001', N'Honda'),
('HSX002', N'Yamaha'),
('HSX003', N'SYM'),
('HSX004', N'Piaggio'),
('HSX005', N'Suzuki'),
('HSX006', N'Kawasaki'),
('HSX007', N'Ducati'),
('HSX008', N'Harley-Davidson'),
('HSX009', N'BMW Motorrad'),
('HSX010', N'KTM'),
('HSX011', N'Aprilia'),
('HSX012', N'MV Agusta'),
('HSX013', N'Triumph'),
('HSX014', N'Benelli'),
('HSX015', N'Bajaj'),
('HSX016', N'Royal Enfield'),
('HSX017', N'Lambretta'),
('HSX018', N'Hero MotoCorp'),
('HSX019', N'Vespa'),
('HSX020', N'CFMoto'),
('HSX021', N'Zontes'),
('HSX022', N'Husqvarna'),
('HSX023', N'Loncin'),
('HSX024', N'Voge'),
('HSX025', N'BRP Can-Am');

-- Thêm dữ liệu vào tbldongco
INSERT INTO tbldongco (madongco, tendongco) VALUES
('DC001', N'125cc 4 kỳ'),
('DC002', N'150cc 4 kỳ'),
('DC003', N'110cc 4 kỳ'),
('DC004', N'250cc 4 kỳ'),
('DC005', N'50cc 2 kỳ'),
('DC006', N'300cc 4 kỳ'),
('DC007', N'400cc 4 kỳ'),
('DC008', N'500cc 4 kỳ'),
('DC009', N'600cc 4 kỳ'),
('DC010', N'750cc 4 kỳ'),
('DC011', N'800cc 4 kỳ'),
('DC012', N'1000cc 4 kỳ'),
('DC013', N'125cc 2 kỳ'),
('DC014', N'150cc 2 kỳ'),
('DC015', N'175cc 4 kỳ'),
('DC016', N'200cc 4 kỳ'),
('DC017', N'350cc 2 kỳ'),
('DC018', N'500cc 2 kỳ'),
('DC019', N'650cc 4 kỳ'),
('DC020', N'850cc 4 kỳ'),
('DC021', N'100cc 4 kỳ'),
('DC022', N'90cc 4 kỳ'),
('DC023', N'80cc 2 kỳ'),
('DC024', N'1250cc 4 kỳ'),
('DC025', N'1800cc 4 kỳ');

-- Thêm dữ liệu vào tblnuocsx
INSERT INTO tblnuocsx (manuocsx, tennuocsx) VALUES
('NSX001', N'Việt Nam'),
('NSX002', N'Nhật Bản'),
('NSX003', N'Ý'),
('NSX004', N'Hàn Quốc'),
('NSX005', N'Ấn Độ'),
('NSX006', N'Mỹ'),
('NSX007', N'Đức'),
('NSX008', N'Anh'),
('NSX009', N'Pháp'),
('NSX010', N'Canada'),
('NSX011', N'Trung Quốc'),
('NSX012', N'Thái Lan'),
('NSX013', N'Indonesia'),
('NSX014', N'Malaysia'),
('NSX015', N'Tây Ban Nha'),
('NSX016', N'Hà Lan'),
('NSX017', N'Úc'),
('NSX018', N'Brazil'),
('NSX019', N'Nga'),
('NSX020', N'Bỉ'),
('NSX021', N'Trung Đông'),
('NSX022', N'Mexico'),
('NSX023', N'Ba Lan'),
('NSX024', N'Trung Phi'),
('NSX025', N'New Zealand');

-- Thêm dữ liệu vào tbltheloai
INSERT INTO tbltheloai (maloai, tenloai) VALUES
('TL001', N'Tay ga'),
('TL002', N'Xe số'),
('TL003', N'Xe côn tay'),
('TL004', N'Xe điện'),
('TL005', N'Xe thể thao'),
('TL006', N'Xe touring'),
('TL007', N'Xe cruiser'),
('TL008', N'Xe naked bike'),
('TL009', N'Xe adventure'),
('TL010', N'Xe địa hình'),
('TL011', N'Xe minibike'),
('TL012', N'Xe mô tô cổ điển'),
('TL013', N'Xe cafe racer'),
('TL014', N'Xe pocket bike'),
('TL015', N'Xe mô tô điện'),
('TL016', N'Xe địa hình ATV'),
('TL017', N'Xe hybrid'),
('TL018', N'Xe scooter điện'),
('TL019', N'Xe phân khối lớn'),
('TL020', N'Xe chopper'),
('TL021', N'Xe tay ga thể thao'),
('TL022', N'Xe cào cào'),
('TL023', N'Xe đua mô tô GP'),
('TL024', N'Xe maxi-scooter'),
('TL025', N'Xe đa dụng (dual sport)');

-- Thêm dữ liệu vào tbltinhtrang
INSERT INTO tbltinhtrang (maTT, tenTT) VALUES
('TT001', N'Mới 100%'),
('TT002', N'Đã qua sử dụng'),
('TT003', N'Chưa đăng ký'),
('TT004', N'Hàng trưng bày'),
('TT005', N'Trầy xước nhẹ'),
('TT006', N'Hàng thanh lý'),
('TT007', N'Hàng nhập khẩu nguyên chiếc'),
('TT008', N'Hàng nội địa'),
('TT009', N'Xe lướt 99%'),
('TT010', N'Xe đổi trả'),
('TT011', N'Hàng lỗi nhẹ'),
('TT012', N'Sơn mới'),
('TT013', N'Động cơ nguyên bản'),
('TT014', N'Đã thay thế phụ tùng'),
('TT015', N'Xe độ máy'),
('TT016', N'Xe độ kiểng'),
('TT017', N'Chưa từng va chạm'),
('TT018', N'Đã đăng kiểm'),
('TT019', N'Chưa đăng kiểm'),
('TT020', N'Sử dụng dưới 5000km'),
('TT021', N'Sử dụng trên 5000km'),
('TT022', N'Bảo hành chính hãng'),
('TT023', N'Không bảo hành'),
('TT024', N'Xe mới nhập kho'),
('TT025', N'Xe đã đặt cọc');

-- Thêm dữ liệu vào tblphanhxe
INSERT INTO tblphanhxe (maphanh, tenphanh) VALUES
('PX001', N'Phanh đĩa'),
('PX002', N'Phanh tang trống'),
('PX003', N'Phanh ABS'),
('PX004', N'Phanh CBS'),
('PX005', N'Phanh cơ'),
('PX006', N'Phanh đĩa trước'),
('PX007', N'Phanh đĩa sau'),
('PX008', N'Phanh tang trống trước'),
('PX009', N'Phanh tang trống sau'),
('PX010', N'Phanh CBS (Combi Brake System)'),
('PX011', N'Phanh ABS 1 kênh'),
('PX012', N'Phanh ABS 2 kênh'),
('PX013', N'Phanh cơ trước'),
('PX014', N'Phanh cơ sau'),
('PX015', N'Phanh dầu đĩa đơn'),
('PX016', N'Phanh dầu đĩa đôi'),
('PX017', N'Phanh đùm cơ'),
('PX018', N'Phanh tay cơ'),
('PX019', N'Phanh điện tử ABS dành cho xe ga'),
('PX020', N'Phanh thủy lực 1 piston'),
('PX021', N'Phanh thủy lực 2 piston'),
('PX022', N'Phanh đĩa Nissin'),
('PX023', N'Phanh đĩa Brembo'),
('PX024', N'Phanh đĩa Tokico'),
('PX025', N'Phanh đĩa OEM hãng');

-- Thêm dữ liệu vào tbldmhang (Danh mục hàng hóa)
INSERT INTO tbldmhang (mahang, tenhang, namsx, maloai, mahangsx, mamau, maphanh, madongco, manuocsx, maTT, dungtichbinhxang, anh, soluong, dongianhap, dongiaban, thoigianbaohanh) VALUES
('MH001', N'Honda Vision 2023', 2023, 'TL001', 'HSX001', 'MS001', 'PX003', 'DC001', 'NSX001', 'TT001', 5, N'vision2023.jpg', 10, 30000000, 35000000, 36),
('MH002', N'Yamaha Exciter 155', 2023, 'TL003', 'HSX002', 'MS003', 'PX003', 'DC002', 'NSX002', 'TT001', 5, N'exciter155.jpg', 5, 40000000, 47000000, 36),
('MH003', N'Honda Wave Alpha', 2022, 'TL002', 'HSX001', 'MS002', 'PX002', 'DC003', 'NSX001', 'TT001', 4, N'wavealpha.jpg', 15, 17000000, 19500000, 24),
('MH004', N'Piaggio Liberty', 2022, 'TL001', 'HSX004', 'MS004', 'PX001', 'DC001', 'NSX003', 'TT001', 6, N'liberty.jpg', 3, 55000000, 60000000, 24),
('MH005', N'Suzuki Raider 150', 2021, 'TL003', 'HSX005', 'MS005', 'PX003', 'DC002', 'NSX002', 'TT002', 4, N'raider150.jpg', 2, 44000000, 50000000, 18),
('MH006', N'Honda SH Mode 2023', 2023, 'TL001', 'HSX001', 'MS006', 'PX001', 'DC001', 'NSX001', 'TT001', 5, N'shmode2023.jpg', 8, 56000000, 62000000, 36),
('MH007', N'Yamaha NVX 155', 2023, 'TL001', 'HSX002', 'MS007', 'PX003', 'DC002', 'NSX002', 'TT001', 5, N'nvx155.jpg', 6, 53000000, 58000000, 36),
('MH008', N'Suzuki Satria F150', 2022, 'TL003', 'HSX005', 'MS005', 'PX003', 'DC002', 'NSX002', 'TT002', 4, N'satriaf150.jpg', 5, 44000000, 49000000, 24),
('MH009', N'Honda Air Blade 160', 2023, 'TL001', 'HSX001', 'MS008', 'PX001', 'DC001', 'NSX001', 'TT001', 5, N'airblade160.jpg', 9, 52000000, 57000000, 36),
('MH010', N'Yamaha Janus 125', 2022, 'TL001', 'HSX002', 'MS009', 'PX002', 'DC002', 'NSX002', 'TT001', 4, N'janus125.jpg', 7, 28000000, 32000000, 24),
('MH011', N'Piaggio Medley 150', 2023, 'TL001', 'HSX004', 'MS010', 'PX001', 'DC001', 'NSX003', 'TT001', 6, N'medley150.jpg', 4, 78000000, 83000000, 36),
('MH012', N'Honda Winner X 150', 2023, 'TL003', 'HSX001', 'MS011', 'PX003', 'DC003', 'NSX001', 'TT001', 5, N'winnerx150.jpg', 10, 46000000, 52000000, 36),
('MH013', N'Suzuki GD110', 2022, 'TL002', 'HSX005', 'MS012', 'PX002', 'DC003', 'NSX002', 'TT002', 4, N'gd110.jpg', 3, 28000000, 31000000, 24),
('MH014', N'Yamaha Sirius Fi', 2023, 'TL002', 'HSX002', 'MS002', 'PX002', 'DC003', 'NSX002', 'TT001', 4, N'siriusfi.jpg', 12, 21000000, 24000000, 36),
('MH015', N'Honda Lead 125', 2023, 'TL001', 'HSX001', 'MS013', 'PX001', 'DC001', 'NSX001', 'TT001', 6, N'lead125.jpg', 11, 42000000, 47000000, 36),
('MH016', N'Vespa Sprint 150', 2022, 'TL001', 'HSX004', 'MS014', 'PX001', 'DC001', 'NSX003', 'TT001', 7, N'vespasprint150.jpg', 2, 90000000, 97000000, 24),
('MH017', N'Honda CBR150R', 2022, 'TL004', 'HSX001', 'MS015', 'PX004', 'DC004', 'NSX001', 'TT002', 4, N'cbr150r.jpg', 4, 72000000, 78000000, 24),
('MH018', N'Yamaha R15 V4', 2023, 'TL004', 'HSX002', 'MS016', 'PX004', 'DC004', 'NSX002', 'TT002', 4, N'r15v4.jpg', 5, 79000000, 86000000, 36),
('MH019', N'Honda Super Cub C125', 2022, 'TL002', 'HSX001', 'MS017', 'PX002', 'DC003', 'NSX001', 'TT001', 3, N'supercubc125.jpg', 2, 86000000, 95000000, 24),
('MH020', N'Suzuki Burgman Street 125', 2023, 'TL001', 'HSX005', 'MS018', 'PX001', 'DC002', 'NSX002', 'TT001', 5, N'burgmanstreet125.jpg', 6, 48000000, 53000000, 36),
('MH021', N'Yamaha FreeGo 125', 2022, 'TL001', 'HSX002', 'MS019', 'PX001', 'DC002', 'NSX002', 'TT001', 4, N'freego125.jpg', 5, 33000000, 37000000, 24),
('MH022', N'Honda PCX 160', 2023, 'TL001', 'HSX001', 'MS020', 'PX001', 'DC001', 'NSX001', 'TT001', 8, N'pcx160.jpg', 5, 78000000, 84000000, 36),
('MH023', N'Vespa Primavera 125', 2023, 'TL001', 'HSX004', 'MS021', 'PX001', 'DC001', 'NSX003', 'TT001', 6, N'vesprima125.jpg', 3, 77000000, 84000000, 36),
('MH024', N'Honda Monkey 125', 2022, 'TL004', 'HSX001', 'MS022', 'PX004', 'DC003', 'NSX001', 'TT002', 5, N'monkey125.jpg', 2, 85000000, 92000000, 24),
('MH025', N'Yamaha MT-15', 2023, 'TL004', 'HSX002', 'MS023', 'PX004', 'DC004', 'NSX002', 'TT002', 5, N'mt15.jpg', 4, 85000000, 91000000, 36);

-- Thêm dữ liệu vào tblhoadonnhap
INSERT INTO tblhoadonnhap (sohdn, ngaynhap, tongtien, manv, mancc) VALUES
('HDN001', '2024-01-10', 300000000, 'NV001', 'NCC001'),
('HDN002', '2024-02-15', 200000000, 'NV002', 'NCC002'),
('HDN003', '2024-03-05', 250000000, 'NV003', 'NCC003'),
('HDN004', '2024-03-18', 180000000, 'NV001', 'NCC002'),
('HDN005', '2024-04-02', 320000000, 'NV004', 'NCC001'),
('HDN006', '2024-04-15', 150000000, 'NV002', 'NCC020'),
('HDN007', '2024-05-01', 400000000, 'NV005', 'NCC018'),
('HDN008', '2024-05-20', 210000000, 'NV003', 'NCC016'),
('HDN009', '2024-06-03', 270000000, 'NV001', 'NCC015'),
('HDN010', '2024-06-15', 310000000, 'NV004', 'NCC011'),
('HDN011', '2024-07-01', 220000000, 'NV002', 'NCC024'),
('HDN012', '2024-07-17', 360000000, 'NV005', 'NCC023'),
('HDN013', '2024-08-04', 190000000, 'NV003', 'NCC005'),
('HDN014', '2024-08-22', 250000000, 'NV001', 'NCC002'),
('HDN015', '2024-09-09', 200000000, 'NV004', 'NCC001'),
('HDN016', '2024-09-27', 170000000, 'NV002', 'NCC014'),
('HDN017', '2024-10-10', 390000000, 'NV005', 'NCC013'),
('HDN018', '2024-10-25', 280000000, 'NV003', 'NCC025'),
('HDN019', '2024-11-05', 330000000, 'NV001', 'NCC001'),
('HDN020', '2024-11-18', 210000000, 'NV004', 'NCC012'),
('HDN021', '2024-12-02', 340000000, 'NV002', 'NCC015'),
('HDN022', '2024-12-20', 400000000, 'NV005', 'NCC010');

-- Thêm dữ liệu vào tblchitiethdn
INSERT INTO tblchitiethdn (sohdn, mahang, soluong, dongia, giamgia, thanhtien) VALUES
('HDN001', 'MH001', 2, 35000000, 0, 70000000),
('HDN001', 'MH002', 1, 47000000, 0, 47000000),
('HDN001', 'MH003', 2, 19500000, 0, 39000000), 
('HDN002', 'MH004', 2, 60000000, 0, 120000000),
('HDN002', 'MH005', 1, 50000000, 0, 50000000),
('HDN003', 'MH006', 3, 62000000, 0, 186000000),
('HDN003', 'MH007', 2, 58000000, 0, 116000000),
('HDN004', 'MH008', 1, 49000000, 0, 49000000),
('HDN004', 'MH009', 2, 57000000, 0, 114000000),
('HDN005', 'MH010', 3, 32000000, 0, 96000000),
('HDN005', 'MH011', 1, 83000000, 0, 83000000),
('HDN006', 'MH012', 2, 52000000, 0, 104000000),
('HDN006', 'MH013', 2, 31000000, 0, 62000000), 
('HDN007', 'MH014', 4, 24000000, 0, 96000000),
('HDN007', 'MH015', 3, 47000000, 0, 141000000),
('HDN008', 'MH016', 2, 97000000, 0, 194000000),
('HDN008', 'MH017', 1, 78000000, 0, 78000000),
('HDN009', 'MH018', 3, 86000000, 0, 258000000),
('HDN009', 'MH019', 1, 95000000, 0, 95000000),
('HDN010', 'MH020', 2, 53000000, 0, 106000000),
('HDN010', 'MH021', 1, 37000000, 0, 37000000),
('HDN011', 'MH022', 3, 84000000, 0, 252000000),
('HDN011', 'MH023', 2, 84000000, 0, 168000000),
('HDN012', 'MH024', 1, 92000000, 0, 92000000),
('HDN012', 'MH025', 4, 91000000, 0, 364000000);

-- Thêm dữ liệu vào tbldondathang
INSERT INTO tbldondathang (soddh, ngaymua, datcoc, thue, tongtien, manv, makhach) VALUES
('DDH001', '2024-01-15', 5000000, 8000000, 90000000, 'NV001', 'KH001'),
('DDH002', '2024-02-10', 4000000, 10000000, 120000000, 'NV002', 'KH002'),
('DDH003', '2024-03-05', 6000000, 18000000, 200000000, 'NV003', 'KH003'),
('DDH004', '2024-03-20', 3500000, 10000000, 116000000, 'NV001', 'KH004'),
('DDH005', '2024-04-01', 7000000, 11000000, 126000000, 'NV004', 'KH005'),
('DDH006', '2024-04-15', 2000000, 8000000, 91000000, 'NV002', 'KH006'),
('DDH007', '2024-05-10', 8000000, 9000000, 104000000, 'NV005', 'KH007'),
('DDH008', '2024-05-25', 3000000, 17000000, 192000000, 'NV003', 'KH008'),
('DDH009', '2024-06-05', 5000000, 18000000, 199000000, 'NV001', 'KH009'),
('DDH010', '2024-06-20', 4000000, 9000000, 99000000, 'NV004', 'KH010'),
('DDH011', '2024-07-10', 6000000, 25000000, 252000000, 'NV002', 'KH011'),
('DDH012', '2024-07-25', 4500000, 18000000, 201000000, 'NV005', 'KH012'),
('DDH013', '2024-08-05', 3500000, 3000000, 38000000, 'NV003', 'KH013'),
('DDH014', '2024-08-20', 4000000, 5900000, 118000000, 'NV001', 'KH014'),
('DDH015', '2024-09-10', 5500000, 8800000, 176000000, 'NV004', 'KH015'),
('DDH016', '2024-09-25', 3000000, 5200000, 104000000, 'NV002', 'KH016'),
('DDH017', '2024-10-05', 7000000, 8600000, 172000000, 'NV005', 'KH017'),
('DDH018', '2024-10-20', 4500000, 6800000, 136000000, 'NV003', 'KH018'),
('DDH019', '2024-11-05', 5500000, 8300000, 166000000, 'NV001', 'KH019'),
('DDH020', '2024-11-20', 3000000, 6000000, 120000000, 'NV004', 'KH020'),
('DDH021', '2024-12-05', 6000000, 7600000, 152000000, 'NV002', 'KH021'),
('DDH022', '2024-12-20', 3500000, 7100000, 146000000, 'NV005', 'KH022'),
('DDH023', '2025-01-10', 5000000, 5100000, 102000000, 'NV003', 'KH023'),
('DDH024', '2025-01-25', 7000000, 7200000, 144000000, 'NV001', 'KH024'),
('DDH025', '2025-02-05', 4000000, 5700000, 114000000, 'NV004', 'KH025');
SELECT * FROM dbo.tbldondathang;
-- Thêm dữ liệu vào tblchitietddh
INSERT INTO tblchitietddh (soddh, mahang, soluong, giamgia, thanhtien) VALUES
('DDH001', 'MH001', 1, 0, 35000000),
('DDH001', 'MH002', 1, 0, 47000000),
('DDH002', 'MH004', 1, 0, 60000000),
('DDH002', 'MH005', 1, 0, 50000000),
('DDH003', 'MH006', 2, 0, 124000000),
('DDH003', 'MH007', 1, 0, 58000000),
('DDH004', 'MH008', 1, 0, 49000000),
('DDH004', 'MH009', 1, 0, 57000000),
('DDH005', 'MH010', 1, 0, 32000000),
('DDH005', 'MH011', 1, 0, 83000000),
('DDH006', 'MH012', 1, 0, 52000000),
('DDH006', 'MH013', 1, 0, 31000000),
('DDH007', 'MH014', 2, 0, 48000000),
('DDH007', 'MH015', 1, 0, 47000000),
('DDH008', 'MH016', 1, 0, 97000000),
('DDH008', 'MH017', 1, 0, 78000000),
('DDH009', 'MH018', 1, 0, 86000000),
('DDH009', 'MH019', 1, 0, 95000000),
('DDH010', 'MH020', 1, 0, 53000000),
('DDH010', 'MH021', 1, 0, 37000000),
('DDH011', 'MH022', 2, 0, 168000000),
('DDH011', 'MH023', 1, 0, 84000000),
('DDH012', 'MH024', 1, 0, 92000000),
('DDH012', 'MH025', 1, 0, 91000000),
('DDH013', 'MH001', 1, 0, 35000000);

SELECT * FROM tblchitiethdn;


