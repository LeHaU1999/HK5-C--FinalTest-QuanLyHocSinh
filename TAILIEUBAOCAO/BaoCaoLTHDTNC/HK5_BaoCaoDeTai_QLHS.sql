CREATE DATABASE HK5_BaoCaoDeTai_QLHS
GO
USE  HK5_BaoCaoDeTai_QLHS



CREATE TABLE NienKhoa
(
	MaNK NVARCHAR(10),
	TenNK	NVARCHAR(50),
	
	CONSTRAINT pk_NienKhoa_MaNK PRIMARY KEY(MaNK)
)

------------------------------------------------------------

CREATE TABLE Khoi
(
	MaKhoi NVARCHAR(10),
	TenKhoi NVARCHAR(50),
	
	CONSTRAINT pk_Khoi_MaKhoi PRIMARY KEY(MaKhoi),
)

-----------------------------------------------------------------

CREATE TABLE Lop
(
	MaLop NVARCHAR(10),
	TenLop NVARCHAR(50),
	Makhoi NVARCHAR(10),
	MaNK NVARCHAR(10)
	
	CONSTRAINT pk_Lop_MaLop PRIMARY KEY(MaLop),
	CONSTRAINT fk_Lop_Khoi_MaKhoi FOREIGN KEY(Makhoi) REFERENCES dbo.Khoi(MaKhoi),
	CONSTRAINT fk_Lop_NienKhoa_MaNK FOREIGN KEY(MaNK) REFERENCES dbo.NienKhoa(MaNK)
)

-------------------------------------------------------------------

CREATE TABLE HocSinh
(
	MaHS	NVARCHAR(10),
	TenHS	NVARCHAR(50),
	MaLop	NVARCHAR(10),
	GioiTinh	NVARCHAR(10),
	SDT		NVARCHAR(15),
	NgaySinh SMALLDATETIME,
	NoiSinh NVARCHAR(50),
	DanToc	NVARCHAR(50),
	DiaChi	NVARCHAR(100)

	CONSTRAINT pk_HocSinh_MaHS PRIMARY KEY(MaHS),
	CONSTRAINT fk_HocSinh_Lop_MaLop FOREIGN KEY(MaLop) REFERENCES dbo.Lop(MaLop)
)
--------------------------------------------------------------------

CREATE TABLE MonHoc
(
	MaMon NVARCHAR(10),
	TenMon	NVARCHAR(50)

	CONSTRAINT pk_MonHoc_MaMon PRIMARY KEY(MaMon)
)
--------------------------------------------------------------------

CREATE TABLE BangDiemMon
(
	MaHS NVARCHAR(10),
	MaMon NVARCHAR(10),
	KTMieng FLOAT,
	KT15L1  FLOAT,
	KT15L2	FLOAT,
	KT45L1	FLOAT,
	KT45L2  FLOAT,
	KTHK1	FLOAT,
	KTHK2	FLOAT

	CONSTRAINT fk_BangDiem_MonHoc_MaMon FOREIGN KEY(MaMon) REFERENCES dbo.MonHoc(MaMon),
	CONSTRAINT fk_BangDiem_HocSinh_MaHS FOREIGN KEY(MaHS) REFERENCES dbo.HocSinh(MaHS)
)

---------------------------------------------------------------------
---------------------------------------------------------------------
----------------------------chua dung toi----------------------------
CREATE TABLE BangDiemTB
(
	MaHS NVARCHAR(10),
	MaMon NVARCHAR(10),
	TBHK1 FLOAT,
	TBHK2 FLOAT,
	TBCN FLOAT

	CONSTRAINT fk_BangDiemTB_MonHoc_MaMon FOREIGN KEY(MaMon) REFERENCES dbo.MonHoc(MaMon),
	CONSTRAINT fk_BangDiemTB_HocSinh_MaHS FOREIGN KEY(MaHS) REFERENCES dbo.HocSinh(MaHS)
)
---------------------------------------------------------------------
---------------------------------------------------------------------

CREATE TABLE NguoiDung
(
	TaiKhoan NVARCHAR(50),
	MatKhat	NVARCHAR(50),
	Quyen NVARCHAR(50)

	PRIMARY KEY(TaiKhoan) 
)


--------------------------------------------------------------------
--------------------------------------------------------------------
--------------------------------------------------------------------
----------------------------SELECT----------------------------------

SELECT*FROM dbo.BangDiem
SELECT*FROM dbo.HocSinh
SELECT*FROM dbo.Khoi
SELECT*FROM dbo.Lop
SELECT*FROM dbo.MonHoc
SELECT*FROM dbo.NguoiDung
SELECT*FROM dbo.NienKhoa
SELECT*FROM dbo.PhanQuyen
-----------------------------PROC-----------------------------------

CREATE PROC NienKhoa_SelectAll
AS 
BEGIN 
	SELECT*FROM dbo.NienKhoa
END

--------------------------------------------------

CREATE PROC khoi_SelectAll
AS 
BEGIN 
	SELECT*FROM dbo.Khoi
END

---------------------------------------------------

CREATE PROC Lop_SelectMaNK_MaKhoi
(
	@MaNK nvarchar(10),
	@MaKhoi nvarchar(10)
)
AS 
BEGIN 
	SELECT*FROM dbo.Lop WHERE MaNK=@MaNK AND Makhoi=@MaKhoi 
END 
	
-----------------------------------------------------------

CREATE PROC NienKhoa_InSert
(
	@MaNK nvarchar(10),
	@TenNK nvarchar(50)
)
AS 
BEGIN
       INSERT INTO NienKhoa VALUES(@MaNK, @TenNK)
END
----------------------------------------------------------

CREATE PROC  NienKhoa_Update
(
	@MaNK nvarchar(10),
	@TenNK nvarchar(50)
)
AS 
BEGIN 
	UPDATE dbo.NienKhoa SET TenNK=@TenNK WHERE MaNK=@MaNK
END 
----------------------------------------------------------

CREATE PROC NienKhoa_Delete
(
	@MaNK nvarchar(10)
)
AS 
BEGIN 
	DELETE FROM dbo.NienKhoa WHERE MaNK=@MaNK
END

-----------------------------------------------------------
CREATE PROC Lop_Insert
(
	@MaLop NVARCHAR(10),
	@TenLop NVARCHAR(50),
	@Makhoi NVARCHAR(10),
	@MaNK NVARCHAR(10)
)
AS 
BEGIN
       INSERT INTO Lop VALUES(@MaLop, @TenLop,@MaKhoi, @MaNK)
END

-------------------------------------------------------

CREATE PROC Lop_Update
(
	@MaLop nvarchar(10),
	@TenLop nvarchar(50)
)
AS 
BEGIN 
	UPDATE dbo.Lop SET TenLop=@TenLop WHERE MaLop=@MaLop
END 

----------------------------------------------------------

CREATE PROC Lop_Delete
(
	@MaLop nvarchar(10)
)
AS 
BEGIN 
	DELETE FROM dbo.Lop WHERE MaLop=@MaLop
END

------------------------------------------------------

CREATE PROC HocSinh_SelectMaLop
(
	@MaLop nvarchar(10)
)
AS 
BEGIN 
	SELECT*FROM dbo.HocSinh WHERE MaLop=@MaLop
END 

-------------------------------------------------------

CREATE PROC HocSinh_Insert
(
	@MaHS	NVARCHAR(10),
	@TenHS	NVARCHAR(50),
	@MaLop	NVARCHAR(10),
	@GioiTinh	NVARCHAR(10),
	@SDT		NVARCHAR(15),
	@NgaySinh SMALLDATETIME,
	@NoiSinh NVARCHAR(50),
	@DanToc	NVARCHAR(50),
	@DiaChi	NVARCHAR(100)
)
AS 
BEGIN 
	INSERT INTO HocSinh 
	VALUES(@MaHS,@TenHS, @MaLop, @GioiTinh, @SDT, @NgaySinh, @NoiSinh, @DanToc, @DiaChi)
END 

-------------------------------------------------------------------

CREATE PROC HocSinh_Update
(
	@MaHS	NVARCHAR(10),
	@TenHS	NVARCHAR(50),
	@GioiTinh	NVARCHAR(10),
	@SDT		NVARCHAR(15),
	@NgaySinh SMALLDATETIME,
	@NoiSinh NVARCHAR(50),
	@DanToc	NVARCHAR(50),
	@DiaChi	NVARCHAR(100)
)
AS 
BEGIN
	UPDATE dbo.HocSinh SET TenHS=@TenHS, GioiTinh=@GioiTinh, SDT=@SDT,NgaySinh=@NgaySinh, NoiSinh=@NoiSinh, DanToc=@DanToc, DiaChi=@DiaChi
	where  MaHS=@MaHS
END 

--------------------------------------------------------------------

CREATE PROC HocSinh_Delete
(
	@MaHS nvarchar(10)
)
AS 
BEGIN 
	DELETE FROM dbo.HocSinh WHERE MaHS=@MaHS
END

------------------------------------------------------------------------ 

CREATE PROC HocSinh_SelectMaHS
(
	@MaHS	NVARCHAR(10)
)
AS
BEGIN 
	SELECT*FROM dbo.HocSinh where MaHS=@MaHS
END 
----------------------------------------------------------------------

CREATE PROC HocSinh_SelectAll
AS
BEGIN
	SELECT*FROM dbo.HocSinh
END 

-----------------------------------------------------------------------

-----------------------------------------------------------------------

CREATE PROC BangDiemMon_SelectAll
AS 
BEGIN
	SELECT*FROM dbo.BangDiemMon
END 

------------------------------------------------------------------


CREATE PROC BangDiemMon_SelectMaMon
(
	@MaMon nvarchar(50)
)
AS 
BEGIN
	SELECT*FROM dbo.BangDiemMon WHERE MaMon=@MaMon
END 

-------------------------------------------------------------------

CREATE PROC BangDiemMon_Insert
(	
	@MaHS NVARCHAR(10),
	@MaMon NVARCHAR(10),
	@KTMieng FLOAT,
	@KT15L1  FLOAT,
	@KT15L2	FLOAT,
	@KT45L1	FLOAT,
	@KT45L2  FLOAT,
	@KTHK1	FLOAT,
	@KTHK2	FLOAT
)
AS
BEGIN 
	INSERT INTO BangDiemMon VALUES(@MaHS,@MaMon,@KTMieng,@KT15L1,@KT15L2,@KT45L1,@KT45L2,@KTHK1,@KTHK2)
END 

CREATE PROC BangDiemMon_Update
(
	@MaHS NVARCHAR(10),
	@MaMon NVARCHAR(10),
	@KTMieng FLOAT,
	@KT15L1  FLOAT,
	@KT15L2	FLOAT,
	@KT45L1	FLOAT,
	@KT45L2  FLOAT,
	@KTHK1	FLOAT,
	@KTHK2	FLOAT
)
AS 
BEGIN
	UPDATE dbo.BangDiemMon SET KTMieng=@KTMieng,KT15L1=@KT15L1,KT15L2=@KT15L2,KT45L1=@KT45L2,KTHK1=@KTHK1,KTHK2=@KTHK2 WHERE MaHS=@MaHS AND MaMon=@MaMon 
END 

-------------------------------------------------------------------- 

CREATE PROC BangDiemMon_SelectMaHS_MaMon
(
	@MaHS	NVARCHAR(10),
	@MaMon  NVARChAR(10)	
)
AS
BEGIN
	SELECT*FROM dbo.BangDiemMon WHERE MaHS=@MaHS AND MaMon=@MaMon
END

------------------------------------------------------------------

CREATE PROC BangDiemMon_TimKiem
(
	@MaHS	NVARCHAR(10),
	@MaMon NVARCHAR(10)
)
AS
BEGIN
	SELECT*FROM dbo.BangDiemMon WHERE MaHS=@MaHS AND MaMon=@MaMon
  END

--------------------------------------------------------------------

CREATE PROC BangDiemMon_UpdateAll
(
	@MaHS NVARCHAR(10),
	@MaMon NVARCHAR(10),
	@KTMieng FLOAT,
	@KT15L1  FLOAT,
	@KT15L2	FLOAT,
	@KT45L1	FLOAT,
	@KT45L2  FLOAT,
	@KTHK1	FLOAT,
	@KTHK2	FLOAT
)
AS
BEGIN
	UPDATE dbo.BangDiemMon SET KTMieng=@KTMieng, KT15L1=@KT15L1,
							   KT15L2=@KT15L2, KT45L1=@KT45L1, 
							   KT45L2=@KT45L2, KTHK1=@KTHK1, KTHK2=@KTHK2
						   WHERE MaHS=@MaHS AND MaMon=@MaMon
END 

--------------------------------------------------------------------

CREATE PROC BangDiemMon_UpdateKTMieng
(
	@KTMieng FLOAT,
	@MaMon NVARCHAR(10),
	@MaHS NVARCHAR(10)	
)
AS
BEGIN 
	UPDATE dbo.BangDiemMon SET KTMieng=@KTMieng  WHERE  MaMon=@MaMon AND MaHS=@MaHS 
END 

--------------------------------------------------------------------

CREATE PROC MonHoc_SelectTenMon
(
	@MaMon NVARCHAR(10),
	@TenMon	NVARCHAR(50)
)
AS
BEGIN 
	SELECT*FROM dbo.MonHoc WHERE MaMon=@MaMon AND TenMon=@TenMon
END 

-----------------------------------------------------------------

CREATE PROC MonHoc_SelectAll
AS 
BEGIN 
	SELECT*FROM dbo.MonHoc
END

----------------------------------------------------------------

CREATE PROC MonHoc_SelectMaMon
(
	@MaMon NVARCHAR(10)
)
AS 
BEGIN 
	SELECT*FROM dbo.MonHoc WHERE MaMon=@MaMon
END 

-----------------------------------------------------------------

CREATE PROC MonHoc_InSert
(
	@MaMon NVARCHAR(10),
	@TenMon	NVARCHAR(50)
)
AS
BEGIN 
	INSERT INTO MonHoc VALUES(@MaMon,@TenMon)
END 

----------------------------------------------------------------

CREATE PROC MonHoc_Update
(
	@MaMon NVARCHAR(10),
	@TenMon	NVARCHAR(50)
)
AS
BEGIN
	UPDATE dbo.MonHoc SET TenMon=@TenMon where MaMon=@MaMon
END 

------------------------------------------------------------------

CREATE PROC MonHoc_Delete
(
	@MaMon NVARCHAR(10)
)
AS 
BEGIN
	DELETE dbo.MonHoc WHERE MaMon=@MaMon
END
    
-----------------------------------------------------------------
--proc tinh dtb--------------

---------------------------------------------------------------
CREATE PROC BangDiemMon_UpdateDTB
(
	@MaMon NVARCHAR(10),
	@MaHS NVARCHAR(10),
	@TBMon FLOAT	
)
AS
BEGIN 
	UPDATE dbo.BangDiemMon SET TBMon=(KTMieng + KT15L1 + KT15L2 + KT45L1*2 + KT45L2*2 + KTHK1*3 + KTHK2*3)/13
	WHERE MaHS=@MaHS AND MaMon=@MaMon
END 

------------------------------------------------------------------------------

CREATE PROC BangDiemTB_SelectAll
AS
BEGIN 
	SELECT*FROM dbo.BangDiemTB
END

------------------------------------------------------------------------------

SELECT KTMieng,KT15L1,KT15L2,KT45L1,KT45L2,KTHK1,KTHK2 FROM dbo.BangDiemMon



SELECT * FROM dbo.NguoiDung WHERE TaiKhoan='lehau' AND MatKhat='123'

---------------------------------------------------------------------------

CREATE PROC NguoiDung_InSert
(
	@TaiKhoan NVARCHAR(50),
	@MatKhat	NVARCHAR(50),
	@Quyen nvarchar(50)
)
AS 
BEGIN
       INSERT INTO NguoiDung VALUES(@TaiKhoan, @MatKhat ,@Quyen)
END
----------------------------------------------------------

CREATE PROC  NguoiDung_Update
(
	@TaiKhoan NVARCHAR(50),
	@MatKhat	NVARCHAR(50),
	@Quyen nvarchar(50)

)
AS 
BEGIN 
	UPDATE dbo.NguoiDung SET MatKhat=@MatKhat , Quyen=@Quyen  WHERE TaiKhoan=@TaiKhoan
END 
----------------------------------------------------------

CREATE PROC NguoiDung_Delete
(
	@TaiKhoan NVARCHAR(50)
)
AS 
BEGIN 
	DELETE FROM NguoiDung WHERE TaiKhoan=@TaiKhoan
END

----------------------------------------------------------------

CREATE PROC NguoiDung_SelectAll

AS 
BEGIN 
	SELECT*FROM dbo.NguoiDung
END


------------------------------------------------------------------------
CREATE PROC MonHoc_InSert
(
	@MaMon NVARCHAR(10),
	@TenMon	NVARCHAR(50)
)
AS
BEGIN 
	INSERT INTO MonHoc VALUES(@MaMon,@TenMon)
END 

----------------------------------------------------------------

CREATE PROC MonHoc_Update
(
	@MaMon NVARCHAR(10),
	@TenMon	NVARCHAR(50)
)
AS
BEGIN
	UPDATE dbo.MonHoc SET TenMon=@TenMon where MaMon=@MaMon
END

--------------------------------------------------------------------
INSERT INTO  dbo.BangDiemMon
(
    MaHS,
    MaMon,
    KTMieng,
    KT15L1,
    KT15L2,
    KT45L1,
    KT45L2,
    KTHK1,
    KTHK2,
    TBMon
)
VALUES
(   N'', -- MaHS - nvarchar(10)
    N'', -- MaMon - nvarchar(10)
    0.0, -- KTMieng - float
    0.0, -- KT15L1 - float
    0.0, -- KT15L2 - float
    0.0, -- KT45L1 - float
    0.0, -- KT45L2 - float
    0.0, -- KTHK1 - float
    0.0, -- KTHK2 - float
    0.0  -- TBMon - float
    )  


CREATE PROC BangDiemMon_InSert
(
	@MaMon NVARCHAR(10),
	@TenMon	NVARCHAR(50)
)
AS
BEGIN 
	INSERT INTO MonHoc VALUES(@MaMon,@TenMon)
END 