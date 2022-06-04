USE MAKROSTOK
GO
---ÜRÜN STOK EKLEME
CREATE PROCEDURE STOK.pURUNSTOK_EKLEME (@urunkodu AS NVARCHAR(10), @urunadý AS NVARCHAR(50), @urunboyutu AS NVARCHAR(5))
AS
BEGIN
INSERT INTO STOK.URUNSTOK(UrunKodu, UrunAdý, UrunBoyutu) VALUES (@urunkodu, @urunadý, @urunboyutu)
END
GO
---ÜRETÝM EKLEME
CREATE PROCEDURE STOK.pURETIM_EKLEME (@uretimadý AS NVARCHAR(50), @uretimboyutu AS NVARCHAR(5))
AS
BEGIN
INSERT INTO STOK.URETIM(UretimAdý, UretimBoyutu) VALUES (@uretimadý, @uretimboyutu)
END
GO
---ÜRETÝM STOK EKLEME
CREATE PROCEDURE STOK.pURETIMSTOK_EKLEME (@uretimstokadý AS NVARCHAR(50))
AS
BEGIN
INSERT INTO STOK.URETIMSTOK(UretStokAdý) VALUES (@uretimstokadý)
END
GO
---ÜRÜN KUTULAMA
CREATE PROCEDURE STOK.pURUN_KUTULAMA (@urunkodu AS NVARCHAR(10), @urunadý AS NVARCHAR(50), @urunboyutu AS NVARCHAR(5), @uretimadý AS NVARCHAR(50), @uretimboyutu AS NVARCHAR(5), @kutu AS BIT)
AS
BEGIN
INSERT INTO STOK.KUTULAMA VALUES ((SELECT UrunID FROM STOK.URUNSTOK WHERE UrunKodu = @urunkodu OR (UrunAdý = @urunadý AND UrunBoyutu = @urunboyutu)), (SELECT UretimID FROM STOK.URETIM WHERE UretimAdý = @uretimadý AND UretimBoyutu = @uretimboyutu), @kutu)
END
GO
---ÜRETÝM ÝÞLEMÝ
CREATE PROCEDURE STOK.pURETIM_ISLEMI (@uretimadý AS NVARCHAR(50), @uretimboyutu AS NVARCHAR(5), @uretimstokadý AS NVARCHAR(50), @punto AS BIT, @kapla AS BIT, @lastik AS BIT)
AS
BEGIN
INSERT INTO STOK.ISLEM VALUES ((SELECT UretStokID FROM STOK.URETIMSTOK WHERE UretStokAdý = @uretimstokadý), (SELECT UretimID FROM STOK.URETIM WHERE UretimAdý = @uretimadý AND UretimBoyutu = @uretimboyutu), @punto, @kapla, @lastik)
END
GO
---KUTULANMIÞ ÜRÜN ADEDÝ
CREATE PROCEDURE STOK.pKUTULANMIS_URUN (@urunkodu AS NVARCHAR(10), @urunadý AS NVARCHAR(50), @urunboyutu AS NVARCHAR(5))
AS
BEGIN
SELECT COUNT(*) AS N'Kutulanmýþ Ürün Adedi'
FROM STOK.URUNSTOK
INNER JOIN STOK.KUTULAMA ON UrunID = UrunnID
WHERE UrunKodu = @urunkodu OR (UrunAdý = @urunadý AND UrunBoyutu = @urunboyutu)
END
GO
---PUNTOLANMIÞ MAL ADEDÝ
CREATE PROCEDURE STOK.pPUNTO_MAL (@uretimstokadý AS NVARCHAR(50), @punto AS BIT)
AS
BEGIN
SELECT COUNT(*) AS N'Puntolanmýþ Mal Adedi'
FROM STOK.URETIMSTOK
INNER JOIN STOK.ISLEM ON UretStokID = UretimStokkID
WHERE UretStokAdý = @uretimstokadý AND MalPuntolandý = @punto
END
GO
---KAPLANMIÞ MAL ADEDÝ
CREATE PROCEDURE STOK.pKAPLA_MAL (@uretimstokadý AS NVARCHAR(50), @kapla AS BIT)
AS
BEGIN
SELECT COUNT(*) AS N'Kaplanmýþ Mal Adedi'
FROM STOK.URETIMSTOK
INNER JOIN STOK.ISLEM ON UretStokID = UretimStokkID
WHERE UretStokAdý = @uretimstokadý AND MalKaplandý = @kapla
END
GO
---LASTÝKLENMÝÞ MAL ADEDÝ
CREATE PROCEDURE STOK.pLASTIK_MAL (@uretimstokadý AS NVARCHAR(50), @lastik AS BIT)
AS
BEGIN
SELECT COUNT(*) AS N'Lastiklenmiþ Mal Adedi'
FROM STOK.URETIMSTOK
INNER JOIN STOK.ISLEM ON UretStokID = UretimStokkID
WHERE UretStokAdý = @uretimstokadý AND MalLastiklendi = @lastik
END
GO
---ÜRÜNÜ STOKTAN ÇIKARMA
CREATE PROCEDURE STOK.pURUNSTOK_CIKAR (@urunkodu AS NVARCHAR(10), @urunadý AS NVARCHAR(50), @urunboyutu AS NVARCHAR(5))
AS
BEGIN
DELETE FROM STOK.URUNSTOK WHERE UrunKodu = @urunkodu OR (UrunAdý = @urunadý AND UrunBoyutu = @urunboyutu)
END
GO
---ÜRETÝMÝ STOKTAN ÇIKARMA
CREATE PROCEDURE STOK.pURETIMI_CIKAR (@uretimadý AS NVARCHAR(50), @uretimboyutu AS NVARCHAR(5))
AS
BEGIN
DELETE FROM STOK.URETIM WHERE UretimAdý = @uretimadý AND UretimBoyutu = @uretimboyutu
END
GO
---ARAMAL_ÇIKARMA
CREATE PROCEDURE STOK.pURETIMSTOK_CIKAR (@uretimstokadý AS NVARCHAR(50))
AS
BEGIN
DELETE FROM STOK.URETIMSTOK WHERE UretStokAdý = @uretimstokadý
END
GO